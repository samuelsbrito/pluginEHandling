using System;
using System.Windows.Forms;
using AddinRibbon.Ctr;
using Autodesk.Navisworks.Api.Plugins;

namespace AddinRibbon
{

    /// <summary>
    /// Aula/Lesson 3
    /// </summary>
    [Plugin("AddinRibbon", "CONN", DisplayName = "AddinRibbon")]
    [RibbonLayout("AddinRibbon.xaml")]
    [RibbonTab("ID_CustomTab_1", DisplayName = "CONNESSIONI")]
    [Command("ID_Button_1", Icon = "1_16.png", LargeIcon = "1_32.png", ToolTip = "Monitore a atualização dos links do modelo")]
    public class ClAddin : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {

            switch (name)
            {
                case "ID_Button_1":

                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClDockPanelUpdate.CONN");

                        if (pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                            docPanel.ActivatePane();
                        }
                    }

                    break;
            }

            return 0;
        }
    }

}

namespace AddinDockPanel
{

    /// <summary>
    /// Aula/Lesson 4
    /// </summary>
    [Plugin("ClDockPanelUpdate", "CONN", DisplayName = "Conn Tools")]
    [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
    public class ClDockPanelUpdate : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //Create a tabControl to store more user controls (Aula/Lesson 6)
            var tc = new TabControl();
            tc.ParentChanged += SetDockStile;

            //Store UcUpdate in the TabControl (Aula/Lesson 6)
            var tp1 = new TabPage("Auto Update");
            tp1.Controls.Add(new UcUpdate());
            tc.TabPages.Add(tp1);

            //Store UcUpdate in the TabControl (Aula/Lesson 6)
            var tp2 = new TabPage("Out Properties");
            tp2.Controls.Add(new UcProperties());
            tc.TabPages.Add(tp2);

            //Store UcUpdate in the TabControl (Aula/Lesson 6)
            var tp3 = new TabPage("Tools");
            tp3.Controls.Add(new UcTools());
            tc.TabPages.Add(tp3);

            return tc;
        }

        /// <summary>
        /// Aula/Lesson 6
        /// </summary>
        private void SetDockStile(object sender, EventArgs e)
        {
            try
            {
                var tc = sender as TabControl;
                tc.Dock = DockStyle.Fill;
            }
            catch (Exception)
            {
                
            }
        }

        public override void DestroyControlPane(Control pane)
        {
            try
            {
                var ctr = (UcUpdate)pane;
                ctr?.Dispose();
            }
            catch (Exception)
            {
                //
            }
        }
    }

}