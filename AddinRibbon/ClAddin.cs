using System;
using System.Windows.Forms;
using AddinRibbon.Ctr;
using Autodesk.Navisworks.Api.Plugins;

namespace AddinRibbon
{
    [Plugin("EHandling", "VeRLab", DisplayName = "EHandling")]
    [RibbonLayout("AddinRibbon.xaml")]
    [RibbonTab("ID_EHandling_tab", DisplayName = "EHandling")]
    [Command("ID_Botao_Equipamentos", Icon = "1_16.png", LargeIcon = "1_32.png", DisplayName = "Equipamentos", ToolTip = "Abre a interface com comandos customizados.")]

    public class ClAddin : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            switch (name)
            {
                case "ID_Botao_Equipamentos":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("ClDockPanelUpdate.VeRLab");

                        if (pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin) (pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
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
    [Plugin("ClDockPanelUpdate", "VeRLab", DisplayName = "EHandling")]
    [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
    public class ClDockPanelUpdate : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            var tc = new TabControl();
            tc.ParentChanged += SetDockStyle;

            var tp1 = new TabPage("Auto Update");
            tp1.Controls.Add(new UcUpdate());
            tc.TabPages.Add(tp1);

            var tp2 = new TabPage("Properties");
            tp2.Controls.Add(new UcProperties());
            tc.TabPages.Add(tp2);

            var tp3 = new TabPage("Tools");
            tp3.Controls.Add(new UcTools());
            tc.TabPages.Add(tp3);

            return tc;
        }

        private void SetDockStyle(object sender, EventArgs e)
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