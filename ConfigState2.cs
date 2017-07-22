using Ennui.Api;
using Ennui.Api.Gui;
using Ennui.Api.Script;
using System;

namespace SimpleESP
{
    public class ConfigState: StateScript
    {
        private Configuration _configuration ;
        private ICheckBox _checkESPActivatedPlayers, _checkESPActivatedResources;
        private ICheckBox _checkResOre, _checkResFiber, _checkResTree, _checkResStone, _checkResLeather;
        private ICheckBox _checkT2, _checkT3,
            _checkT4, _checkT4_1, _checkT4_2, _checkT4_3,
            _checkT5, _checkT5_1, _checkT5_2, _checkT5_3,
            _checkT6, _checkT6_1, _checkT6_2, _checkT6_3,
            _checkT7, _checkT7_1, _checkT7_2, _checkT7_3,
            _checkT8, _checkT8_1, _checkT8_2, _checkT8_3;

        private IPanel _panel;

        public ConfigState(Configuration configuration)
        {
            _configuration = configuration;
        }

        public override bool OnStart(IScriptEngine se)
        {            
            Game.Sync(() =>
            {
                var screenSize = Game.ScreenSize;

                _panel = Factories.CreateGuiPanel();
                GuiScene.Add(_panel);
                _panel.SetSize(500, 600);
                _panel.SetPosition(Convert.ToInt32(screenSize.X * 0.5), Convert.ToInt32(screenSize.Y * 0.5), 0);
                _panel.SetAnchor(new Vector2f(0.0f, 0.0f), new Vector2f(0.0f, 0.0f));
               
                var label = Factories.CreateGuiLabel();
                _panel.Add(label);
                label.SetPosition(-60, 275, 0);
                label.SetText("Options");
                label.SetSize(100, 25);

                _checkESPActivatedPlayers = Factories.CreateGuiCheckBox();
                _panel.Add(_checkESPActivatedPlayers);
                _checkESPActivatedPlayers.SetPosition(-70, 255, 0);
                _checkESPActivatedPlayers.SetText("ESP Players");
                _checkESPActivatedPlayers.SetSize(50, 25);

                _checkESPActivatedResources = Factories.CreateGuiCheckBox();
                _panel.Add(_checkESPActivatedResources);
                _checkESPActivatedResources.SetPosition(-70, 235, 0);
                _checkESPActivatedResources.SetText("ESP Resources");
                _checkESPActivatedResources.SetSize(50, 25);

                _checkResOre = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResOre);
                _checkResOre.SetPosition(-50, 215, 0);
                _checkResOre.SetText("Ore");
                _checkResOre.SetSize(50, 25);

                _checkResFiber = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResFiber);
                _checkResFiber.SetPosition(-50, 195, 0);
                _checkResFiber.SetText("Fiber");
                _checkResFiber.SetSize(50, 25);

                _checkResTree = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResTree);
                _checkResTree.SetPosition(-50, 175, 0);
                _checkResTree.SetText("Tree");
                _checkResTree.SetSize(50, 25);

                _checkResStone = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResStone);
                _checkResStone.SetPosition(-50, 155, 0);
                _checkResStone.SetText("Stone");
                _checkResStone.SetSize(50, 25);

                _checkResLeather = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResLeather);
                _checkResLeather.SetPosition(-50, 135, 0);
                _checkResLeather.SetText("Leather");
                _checkResLeather.SetSize(50, 25);

                _checkT2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT2);
                _checkT2.SetPosition(30, 215, 0);
                _checkT2.SetText("T2");
                _checkT2.SetSize(50, 25);

                _checkT3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT3);
                _checkT3.SetPosition(30, 195, 0);
                _checkT3.SetText("T3");
                _checkT3.SetSize(50, 25);

                _checkT4 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT4);
                _checkT4.SetPosition(30, 175, 0);
                _checkT4.SetText("T4");
                _checkT4.SetSize(50, 25);

                _checkT4_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT4_1);
                _checkT4_1.SetPosition(50, 155, 0);
                _checkT4_1.SetText("T4.1");
                _checkT4_1.SetSize(50, 25);

                _checkT4_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT4_2);
                _checkT4_2.SetPosition(50, 135, 0);
                _checkT4_2.SetText("T4.2");
                _checkT4_2.SetSize(50, 25);

                _checkT4_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT4_3);
                _checkT4_3.SetPosition(50, 115, 0);
                _checkT4_3.SetText("T4.3");
                _checkT4_3.SetSize(50, 25);

                _checkT5 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5);
                _checkT5.SetPosition(30, -5+100, 0);
                _checkT5.SetText("T5");
                _checkT5.SetSize(50, 25);

                _checkT5_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_1);
                _checkT5_1.SetPosition(50, -25 + 100, 0);
                _checkT5_1.SetText("T5.1");
                _checkT5_1.SetSize(50, 25);

                _checkT5_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_2);
                _checkT5_2.SetPosition(50, -45 + 100, 0);
                _checkT5_2.SetText("T5.2");
                _checkT5_2.SetSize(50, 25);

                _checkT5_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_3);
                _checkT5_3.SetPosition(50, -65 + 100, 0);
                _checkT5_3.SetText("T5.3");
                _checkT5_3.SetSize(50, 25);

                _checkT6 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6);
                _checkT6.SetPosition(30, -85 + 100, 0);
                _checkT6.SetText("T6");
                _checkT6.SetSize(50, 25);

                _checkT6_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_1);
                _checkT6_1.SetPosition(50, -105 + 100, 0);
                _checkT6_1.SetText("T6.1");
                _checkT6_1.SetSize(50, 25);

                _checkT6_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_2);
                _checkT6_2.SetPosition(50, -125 + 100, 0);
                _checkT6_2.SetText("T6.2");
                _checkT6_2.SetSize(50, 25);

                _checkT6_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_3);
                _checkT6_3.SetPosition(50, -145 + 100, 0);
                _checkT6_3.SetText("T6.3");
                _checkT6_3.SetSize(50, 25);

                _checkT7 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7);
                _checkT7.SetPosition(30, -175 + 100, 0);
                _checkT7.SetText("T7");
                _checkT7.SetSize(50, 25);

                _checkT7_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_1);
                _checkT7_1.SetPosition(50, -195 + 100, 0);
                _checkT7_1.SetText("T7.1");
                _checkT7_1.SetSize(50, 25);

                _checkT7_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_2);
                _checkT7_2.SetPosition(50, -215 + 100, 0);
                _checkT7_2.SetText("T7.2");
                _checkT7_2.SetSize(50, 25);

                _checkT7_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_3);
                _checkT7_3.SetPosition(50, -235 + 100, 0);
                _checkT7_3.SetText("T7.3");
                _checkT7_3.SetSize(50, 25);

                _checkT8 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8);
                _checkT8.SetPosition(30, -255 + 100, 0);
                _checkT8.SetText("T8");
                _checkT8.SetSize(50, 25);

                _checkT8_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_1);
                _checkT8_1.SetPosition(50, -275 + 100, 0);
                _checkT8_1.SetText("T8.1");
                _checkT8_1.SetSize(50, 25);

                _checkT8_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_2);
                _checkT8_2.SetPosition(50, -295 + 100, 0);
                _checkT8_2.SetText("T8.2");
                _checkT8_2.SetSize(50, 25);

                _checkT8_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_3);
                _checkT8_3.SetPosition(50, -315 + 100, 0);
                _checkT8_3.SetText("T8.3");
                _checkT8_3.SetSize(50, 25);

                var button = Factories.CreateGuiButton();
                _panel.Add(button);
                button.SetPosition(30, -350 + 100, 0);
                button.SetText("Accept");
                button.SetSize(100, 45);
                button.AddActionListener((e) =>
                {
                    _configuration.ESPActivatedPlayers = _checkESPActivatedPlayers.IsSelected();
                    _configuration.ESPActivatedResources = _checkESPActivatedResources.IsSelected();
                    _configuration.ResOre = _checkResOre.IsSelected();
                    _configuration.ResFiber = _checkResFiber.IsSelected();
                    _configuration.ResStone = _checkResStone.IsSelected();
                    _configuration.ResTree = _checkResTree.IsSelected();
                    _configuration.ResLeather = _checkResLeather.IsSelected();
                    _configuration.ResT2 = _checkT2.IsSelected();
                    _configuration.ResT3 = _checkT3.IsSelected();
                    _configuration.ResT4 = _checkT4.IsSelected();
                    _configuration.ResT4_1 = _checkT4_1.IsSelected();
                    _configuration.ResT4_2 = _checkT4_2.IsSelected();
                    _configuration.ResT4_3 = _checkT4_3.IsSelected();
                    _configuration.ResT5_1 = _checkT5_1.IsSelected();
                    _configuration.ResT5_2 = _checkT5_2.IsSelected();
                    _configuration.ResT5_3 = _checkT5_3.IsSelected();
                    _configuration.ResT6_1 = _checkT6_1.IsSelected();
                    _configuration.ResT6_2 = _checkT6_2.IsSelected();
                    _configuration.ResT6_3 = _checkT6_3.IsSelected();
                    _configuration.ResT7_1 = _checkT7_1.IsSelected();
                    _configuration.ResT7_2 = _checkT7_2.IsSelected();
                    _configuration.ResT7_3 = _checkT7_3.IsSelected();
                    _configuration.ResT8_1 = _checkT8_1.IsSelected();
                    _configuration.ResT8_2 = _checkT8_2.IsSelected();
                    _configuration.ResT8_3 = _checkT8_3.IsSelected();

                    _panel.Destroy();

                    parent.EnterState("work");
                });
            });

            Logging.Log("Menu loaded", LogLevel.Info);

            return base.OnStart(se);            
        }        
    }
}

