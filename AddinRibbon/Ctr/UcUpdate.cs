using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinRibbon.Ctr
{
    public partial class UcUpdate : UserControl
    {
        public Timer UpTimer = new Timer { Enabled = true, Interval = 1000};

        public List<FileInfo> ListInfo = new List<FileInfo>();

        public UcUpdate()
        {
            InitializeComponent();
            btUpdate.Enabled = false;

            UpTimer.Tick += UpTimerOnTick;

            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ApplicationOnActiveDocumentChanged;
        }

        private void ApplicationOnActiveDocumentChanged(object sender, EventArgs e)
        {
            ListInfo.Clear();
        }

        //metodo executado em cada tick do timer
        private void UpTimerOnTick(object sender, EventArgs e)
        {
            //update pausado
            if (cbPause.Checked)
            {
                return;
            }

            //nenhum documento ativo
            if (Autodesk.Navisworks.Api.Application.ActiveDocument == null)
            {
                return;
            }

            var activeDocument = Autodesk.Navisworks.Api.Application.ActiveDocument;

            foreach (var model in activeDocument.Models)
            {
                var currentInfo = new FileInfo(model.SourceFileName);

                var lastInfo = ListInfo.FirstOrDefault(i => i.FullName == currentInfo.FullName);

                if (lastInfo != null)
                {
                    var time = Math.Abs((lastInfo.LastWriteTime - currentInfo.LastWriteTime).TotalSeconds);

                    if (time > 1)
                    {
                        btUpdate.Enabled = true;

                        ListInfo.Remove(lastInfo);
                        ListInfo.Add(currentInfo);

                        tbLog.AppendText(string.Concat(currentInfo.Name, " was updated!", Environment.NewLine));

                        if (cbAutoUpdate.Checked)
                        {
                            UpdateModel();
                        }
                    }
                }
                else
                {
                    ListInfo.Add(currentInfo);
                }
            }

        }

        private void UpdateModel()
        {
            Autodesk.Navisworks.Api.Application.ActiveDocument.UpdateFiles();
            tbLog.AppendText(string.Concat("The active document was updated!", Environment.NewLine));
            btUpdate.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UcUpdate_Load(object sender, EventArgs e)
        {

        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }

        private void btUpdate_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateModel();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btClearLog_MouseUp(object sender, MouseEventArgs e)
        {
            tbLog.Clear();
        }
    }
}
