using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Autodesk.Navisworks.Api;
using App = Autodesk.Navisworks.Api.Application;

namespace AddinRibbon.Ctr
{
    public partial class UcProperties : UserControl
    {
        public UcProperties()
        {
            InitializeComponent();

            ListenSelection(null, null);
            App.ActiveDocumentChanged += ListenSelection;
        }

        private void ListenSelection(object sender, EventArgs e)
        {
            App.ActiveDocument.CurrentSelection.Changed += GetProperties;
        }

        private void GetProperties(object sender, EventArgs e)
        {
            tbOut.Clear();

            var result = new List<string>();

            foreach (var item in App.ActiveDocument.CurrentSelection.SelectedItems)
            {
                result.Add(item.DisplayName);

                foreach (var cat in item.PropertyCategories)
                {
                    result.Add(string.Concat(".     ", cat.DisplayName));

                    foreach (var prop in cat.Properties)
                    {
                        result.Add(string.Concat(".     .     ", prop.DisplayName, "> ", GetPropertyValue(prop)));
                    }
                }

                result.Add(Environment.NewLine);
            }

            tbOut.Text = string.Join(Environment.NewLine, result);
        }

        private string GetPropertyValue(DataProperty prop)
        {
            return prop.Value.IsDisplayString ? prop.Value.ToDisplayString() : prop.Value.ToString().Split(':')[1];
        }

        private void btFind_MouseUp(object sender, MouseEventArgs e)
        {
            var r = new List<ModelItem>();

            foreach (var item in App.ActiveDocument.CurrentSelection.SelectedItems)
            {
                var cat = item.DescendantsAndSelf.Where(i => i.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text) != null);

                var pro = cat.Where(m => m.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text).Properties.FindPropertyByDisplayName(tbPropertyName.Text) != null);

                r.AddRange(pro.Where(m => GetPropertyValue(m.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text).Properties.FindPropertyByDisplayName(tbPropertyName.Text)) == tbPropertyValue.Text));
            }

            App.ActiveDocument.CurrentSelection.Clear();
            App.ActiveDocument.CurrentSelection.AddRange(r);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }

        private void tbCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbCategoryName_Click(object sender, EventArgs e)
        {

        }

        private void btFind_Click(object sender, EventArgs e)
        {

        }

        private void btCreateSet_MouseUp(object sender, MouseEventArgs e)
        {
            var ac = App.ActiveDocument;
            var cs = ac.CurrentSelection;
            var se = ac.SelectionSets;

            var fn = "Selection Sets";
            var sn = Guid.NewGuid().ToString();

            try
            {
                var fi = se.Value.IndexOfDisplayName(fn);

                if (fi == -1)
                {
                    se.AddCopy(new FolderItem() { DisplayName = fn });
                }

                var set = new SelectionSet(cs.SelectedItems) { DisplayName = sn };
                se.AddCopy(set);

                var fo = se.Value[se.Value.IndexOfDisplayName(fn)] as FolderItem;
                var ns = se.Value[se.Value.IndexOfDisplayName(fn)] as SavedItem;

                se.Move(ns.Parent,se.Value.IndexOfDisplayName(sn), fo, 0);
            }
            catch (Exception)
            {
            }
        }

        private void btCreateSearch_MouseUp(object sender, MouseEventArgs e)
        {
            var ac = App.ActiveDocument;
            var cs = ac.CurrentSelection;
            var se = ac.SelectionSets;

            var fn = "Search Sets";
            var sn = Guid.NewGuid().ToString();

            try
            {
                var fi = se.Value.IndexOfDisplayName(fn);

                if (fi == -1)
                {
                    se.AddCopy(new FolderItem() { DisplayName = fn });
                }

                var s = new Search();
                s.Locations = SearchLocations.DescendantsAndSelf;
                s.Selection.SelectAll();

                var sc = SearchCondition.HasPropertyByDisplayName(tbCategoryName.Text, tbPropertyName.Text);
                s.SearchConditions.Add(sc.EqualValue(VariantData.FromDisplayString(tbPropertyValue.Text)));

                var set = new SelectionSet(s) { DisplayName = sn };
                
                se.AddCopy(set);

                var fo = se.Value[se.Value.IndexOfDisplayName(fn)] as FolderItem;
                var ns = se.Value[se.Value.IndexOfDisplayName(fn)] as SavedItem;

                se.Move(ns.Parent, se.Value.IndexOfDisplayName(sn), fo, 0);
            }
            catch (Exception)
            {
            }
        }
    }
}
