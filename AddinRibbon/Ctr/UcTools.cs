using System.Linq;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using App = Autodesk.Navisworks.Api.Application;
using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.ComApi;
using Autodesk.Navisworks.Api.Clash;
using System;
using Autodesk.Navisworks.Api.Data;
using System.Collections.Generic;

namespace AddinRibbon.Ctr
{
    public partial class UcTools : UserControl
    {
        public Timer TranslateTime { get; } = new Timer() { Enabled = true, Interval = 50 };
        public System.Drawing.Color FocusedColor { get; } = System.Drawing.Color.ForestGreen;
        public ModelItemCollection LastIsolated { get; private set; }
        public string LastIsolatedName { get; private set; }

        public UcTools()
        {
            InitializeComponent();

            MapLabels();

            TranslateTime.Tick += Translate;
        }

        private void lbIsolateSelection_MouseUp(object sender, MouseEventArgs e)
        {
            IsolateSelection();
        }

        private void IsolateSelection()
        {
            var acd = App.ActiveDocument;

            var se = acd.CurrentSelection.SelectedItems.First;

            var all = acd.Models.CreateCollectionFromRootItems().SelectMany(i => i.DescendantsAndSelf);

            try
            {
                acd.Models.SetHidden(all, false);
                acd.State.InvertSelection();
                acd.Models.SetHidden(acd.CurrentSelection.SelectedItems, true);
                acd.ActiveView.LookFromFrontRightTop();

                var sel = new ModelItemCollection();
                sel.AddRange(se.DescendantsAndSelf);
                sel.AddRange(se.Ancestors);

                LastIsolated = sel;
                LastIsolatedName = se.DisplayName;
            }
            catch (System.Exception)
            {
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }

        private void lbSaveVp_MouseUp(object sender, MouseEventArgs e)
        {
            SaveCurrentViewPoint();
        }

        private void SaveCurrentViewPoint()
        {
            var acd = App.ActiveDocument;

            try
            {
                acd.Models.OverridePermanentColor(LastIsolated, new Color(1, 0, 0));
                //acd.Models.OverridePermanentTransparency(LastIsolated, 0.5);

                var state = ComApiBridge.State;
                var cv = state.CurrentView.Copy();
                var vp = state.ObjectFactory(nwEObjectType.eObjectType_nwOpView);
                var view = vp as InwOpView;

                if (view != null) view.ApplyHideAttribs = true;
                view.ApplyMaterialAttribs = true;

                vp.Name = LastIsolatedName;
                vp.anonview = cv;

                state.SavedViews().Add(vp);
            }
            catch (Exception)
            {
            }
        }

        private void lbIsolateAndSave_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                IsolateSelection();
                SaveCurrentViewPoint();
            }
            catch (Exception)
            {
            }
        }

        private void MapLabels()
        {
            var lbs = Controls.OfType<Label>();

            foreach (var l in lbs)
            {
                l.MouseLeave += LabelUnFocused;
                l.MouseEnter += LabelFocused;
            }

        }

        private void LabelFocused(object sender, EventArgs e)
        {
            try
            {
                (sender as Label).BackColor = FocusedColor;
            }
            catch (Exception)
            {
            }
        }

        private void LabelUnFocused(object sender, EventArgs e)
        {
            try
            {
                (sender as Label).BackColor = Label.DefaultBackColor;
            }
            catch (Exception)
            {
            }
        }

        private void Translate(object sender, EventArgs e)
        {
            if (!MouseButtons.Equals(MouseButtons.Left)) return;

            MoveElements();

            RotateElements();

            if (lbReset.BackColor.Equals(FocusedColor))
            {
                try
                {
                    var acd = App.ActiveDocument;
                    var se = acd.CurrentSelection.SelectedItems;

                    acd.Models.ResetPermanentTransform(se);
                }
                catch (Exception)
                {
                }
            }
        }

        private void RotateElements()
        {
            var acd = App.ActiveDocument;

            double a = 0;
            double inc = 3;

            if (lbTurnR.BackColor.Equals(FocusedColor))
            {
                a = inc * (Math.PI / 180.0);
            }

            if (lbTurnL.BackColor.Equals(FocusedColor))
            {
                a = -inc * (Math.PI / 180.0);
            }

            if (a == 0) return;

            try
            {
                var se = acd.CurrentSelection.SelectedItems;

                foreach (var item in se)
                {
                    var loc = item.BoundingBox().Center;
                    var mb = new Vector3D(loc.X, loc.Y, loc.Z);
                    var mo = new Vector3D(-loc.X, -loc.Y, -loc.Z);
                    var transvec = Transform3D.CreateTranslation(mo);

                    acd.Models.OverridePermanentTransform(new List<ModelItem> { item }, transvec, true);

                    var rt = new Rotation3D(new UnitVector3D(0, 0, 1), a);
                    var tr = new Transform3D(rt, mb);

                    acd.Models.OverridePermanentTransform(new List<ModelItem> { item }, tr, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void MoveElements()
        {
            var acd = App.ActiveDocument;

            var x = 0;
            var y = 0;
            var z = 0;
            var inc = 5;

            if (LbX.BackColor.Equals(FocusedColor))
            {
                x = inc;
            }

            if (LbXm.BackColor.Equals(FocusedColor))
            {
                x = -inc;
            }

            if (LbY.BackColor.Equals(FocusedColor))
            {
                y = inc;
            }

            if (LbYm.BackColor.Equals(FocusedColor))
            {
                y = -inc;
            }

            if (LbZ.BackColor.Equals(FocusedColor))
            {
                z = inc;
            }

            if (LbZm.BackColor.Equals(FocusedColor))
            {
                z = -inc;
            }

            if (x == 0 && y == 0 && z == 0) return;

            try
            {
                var se = acd.CurrentSelection.SelectedItems;

                foreach (var item in se)
                {
                    var im = item.AncestorsAndSelf.First(i => i.Model != null);
                    var sc = UnitConversion.ScaleFactor(Units.Millimeters, im.Model.Units);
                    var mv = new Vector3D(x * sc, y * sc, z * sc);
                    var transVec = Transform3D.CreateTranslation(mv);

                    acd.Models.OverridePermanentTransform(new List<ModelItem> { item }, transVec, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void lbCheckSelection_MouseUp(object sender, MouseEventArgs e)
        {
            var acd = App.ActiveDocument;
            DocumentClash dc = acd.Clash as DocumentClash;
            DocumentClashTests oDCT = dc.TestsData;

            var allItems = new ModelItemCollection();
            allItems.AddRange(acd.CurrentSelection.SelectedItems);

            var cb = new ModelItemCollection();

            foreach (var modelItem in allItems)
            {
                cb.Clear();
                cb.AddRange(allItems);
                cb.Remove(modelItem);

                var ct = new ClashTest { CustomTestName = modelItem.DisplayName };

                ct.DisplayName = ct.CustomTestName;
                ct.TestType = ClashTestType.Hard;

                var sc = UnitConversion.ScaleFactor(acd.Models.First.Units, Units.Millimeters);

                ct.Tolerance = Convert.ToDouble(1 / sc);

                ct.SelectionA.SelfIntersect = false;
                ct.SelectionA.PrimitiveTypes = PrimitiveTypes.Triangles;
                ct.SelectionB.SelfIntersect = false;
                ct.SelectionB.PrimitiveTypes = PrimitiveTypes.Triangles;

                ct.SelectionA.Selection.CopyFrom(new ModelItemCollection() { modelItem });
                ct.SelectionB.Selection.CopyFrom(cb);
                
                dc.TestsData.TestsAddCopy(ct);
            }

            try
            {
                oDCT.TestsRunAllTests();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
