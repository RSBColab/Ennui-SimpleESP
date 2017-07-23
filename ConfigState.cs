using Ennui.Api;
using Ennui.Api.Gui;
using Ennui.Api.Meta;
using Ennui.Api.Script;
using System;
using System.Collections.Generic;

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
            _checkT8, _checkT8_1, _checkT8_2, _checkT8_3,
            _checkOnlyShowMorethan1;

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
                label.SetPosition(0, 275, 0);
                label.SetText("Options");
                label.SetSize(100, 25);

                _checkESPActivatedPlayers = Factories.CreateGuiCheckBox();
                _panel.Add(_checkESPActivatedPlayers);
                _checkESPActivatedPlayers.SetPosition(-200, 255, 0);
                _checkESPActivatedPlayers.SetText("ESP Players");
                _checkESPActivatedPlayers.SetSize(50, 25);

                _checkESPActivatedResources = Factories.CreateGuiCheckBox();
                _panel.Add(_checkESPActivatedResources);
                _checkESPActivatedResources.SetPosition(-200, 235, 0);
                _checkESPActivatedResources.SetText("ESP Resources");
                _checkESPActivatedResources.SetSize(50, 25);

                _checkResOre = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResOre);
                _checkResOre.SetPosition(-150, 215, 0);
                _checkResOre.SetText("Ore");
                _checkResOre.SetSize(50, 25);

                _checkResFiber = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResFiber);
                _checkResFiber.SetPosition(-150, 195, 0);
                _checkResFiber.SetText("Fiber");
                _checkResFiber.SetSize(50, 25);

                _checkResTree = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResTree);
                _checkResTree.SetPosition(-150, 175, 0);
                _checkResTree.SetText("Tree");
                _checkResTree.SetSize(50, 25);

                _checkResStone = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResStone);
                _checkResStone.SetPosition(-150, 155, 0);
                _checkResStone.SetText("Stone");
                _checkResStone.SetSize(50, 25);

                _checkResLeather = Factories.CreateGuiCheckBox();
                _panel.Add(_checkResLeather);
                _checkResLeather.SetPosition(-150, 135, 0);
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
                _checkT5.SetPosition(30, 95, 0);
                _checkT5.SetText("T5");
                _checkT5.SetSize(50, 25);

                _checkT5_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_1);
                _checkT5_1.SetPosition(50, 75, 0);
                _checkT5_1.SetText("T5.1");
                _checkT5_1.SetSize(50, 25);

                _checkT5_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_2);
                _checkT5_2.SetPosition(50, 55, 0);
                _checkT5_2.SetText("T5.2");
                _checkT5_2.SetSize(50, 25);

                _checkT5_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT5_3);
                _checkT5_3.SetPosition(50, 35, 0);
                _checkT5_3.SetText("T5.3");
                _checkT5_3.SetSize(50, 25);

                _checkT6 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6);
                _checkT6.SetPosition(30, 15, 0);
                _checkT6.SetText("T6");
                _checkT6.SetSize(50, 25);

                _checkT6_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_1);
                _checkT6_1.SetPosition(50, -5, 0);
                _checkT6_1.SetText("T6.1");
                _checkT6_1.SetSize(50, 25);

                _checkT6_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_2);
                _checkT6_2.SetPosition(50, -25, 0);
                _checkT6_2.SetText("T6.2");
                _checkT6_2.SetSize(50, 25);

                _checkT6_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT6_3);
                _checkT6_3.SetPosition(50, -45, 0);
                _checkT6_3.SetText("T6.3");
                _checkT6_3.SetSize(50, 25);

                _checkT7 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7);
                _checkT7.SetPosition(30, -65, 0);
                _checkT7.SetText("T7");
                _checkT7.SetSize(50, 25);

                _checkT7_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_1);
                _checkT7_1.SetPosition(50, -85, 0);
                _checkT7_1.SetText("T7.1");
                _checkT7_1.SetSize(50, 25);

                _checkT7_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_2);
                _checkT7_2.SetPosition(50, -105, 0);
                _checkT7_2.SetText("T7.2");
                _checkT7_2.SetSize(50, 25);

                _checkT7_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT7_3);
                _checkT7_3.SetPosition(50, -125, 0);
                _checkT7_3.SetText("T7.3");
                _checkT7_3.SetSize(50, 25);

                _checkT8 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8);
                _checkT8.SetPosition(30, -145, 0);
                _checkT8.SetText("T8");
                _checkT8.SetSize(50, 25);

                _checkT8_1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_1);
                _checkT8_1.SetPosition(50, -165, 0);
                _checkT8_1.SetText("T8.1");
                _checkT8_1.SetSize(50, 25);

                _checkT8_2 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_2);
                _checkT8_2.SetPosition(50, -185, 0);
                _checkT8_2.SetText("T8.2");
                _checkT8_2.SetSize(50, 25);

                _checkT8_3 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkT8_3);
                _checkT8_3.SetPosition(50, -205, 0);
                _checkT8_3.SetText("T8.3");
                _checkT8_3.SetSize(50, 25);

                _checkOnlyShowMorethan1 = Factories.CreateGuiCheckBox();
                _panel.Add(_checkOnlyShowMorethan1);
                _checkOnlyShowMorethan1.SetPosition(-100, -225, 0);
                _checkOnlyShowMorethan1.SetText("Only show harvestables with more than 1 charge");
                _checkOnlyShowMorethan1.SetSize(250, 25);

                var button = Factories.CreateGuiButton();
                _panel.Add(button);
                button.SetPosition(0, -270, 0);
                button.SetText("Accept");
                button.SetSize(100, 45);
                button.AddActionListener((e) =>
                {
                    _configuration.ESPActivatedPlayers = _checkESPActivatedPlayers.IsSelected();
                    _configuration.ESPActivatedResources = _checkESPActivatedResources.IsSelected();

                    var list = new List<ResourceType>();
                    list.Add(ResourceType.Coins);
                    if (_checkResOre.IsSelected())
                        list.Add(ResourceType.Ore);
                    if (_checkResFiber.IsSelected())
                        list.Add(ResourceType.Fiber);
                    if (_checkResStone.IsSelected())
                        list.Add(ResourceType.Rock);
                    if (_checkResTree.IsSelected())
                        list.Add(ResourceType.Wood);
                    if (_checkResLeather.IsSelected())
                        list.Add(ResourceType.Hide);

                    _configuration.Resources = list.ToArray();
                    if (_checkT2.IsSelected())
                        _configuration.TierAndRarity.Add("2.0");
                    if (_checkT3.IsSelected())
                        _configuration.TierAndRarity.Add("3.0");
                    if (_checkT4.IsSelected())
                        _configuration.TierAndRarity.Add("4.0");
                    if (_checkT4_1.IsSelected())
                        _configuration.TierAndRarity.Add("4.1");
                    if (_checkT4_2.IsSelected())
                        _configuration.TierAndRarity.Add("4.2");
                    if (_checkT4_3.IsSelected())
                        _configuration.TierAndRarity.Add("4.3");
                    if (_checkT5.IsSelected())
                        _configuration.TierAndRarity.Add("5.0");
                    if (_checkT5_1.IsSelected())
                        _configuration.TierAndRarity.Add("5.1");
                    if (_checkT5_2.IsSelected())
                        _configuration.TierAndRarity.Add("5.2");
                    if (_checkT5_3.IsSelected())
                        _configuration.TierAndRarity.Add("5.3");
                    if (_checkT4.IsSelected())
                        _configuration.TierAndRarity.Add("6.0");
                    if (_checkT4_1.IsSelected())
                        _configuration.TierAndRarity.Add("6.1");
                    if (_checkT4_2.IsSelected())
                        _configuration.TierAndRarity.Add("6.2");
                    if (_checkT4_3.IsSelected())
                        _configuration.TierAndRarity.Add("6.3");
                    if (_checkT7.IsSelected())
                        _configuration.TierAndRarity.Add("7.0");
                    if (_checkT7_1.IsSelected())
                        _configuration.TierAndRarity.Add("7.1");
                    if (_checkT7_2.IsSelected())
                        _configuration.TierAndRarity.Add("7.2");
                    if (_checkT7_3.IsSelected())
                        _configuration.TierAndRarity.Add("7.3");
                    if (_checkT8.IsSelected())
                        _configuration.TierAndRarity.Add("8.0");
                    if (_checkT8_1.IsSelected())
                        _configuration.TierAndRarity.Add("8.1");
                    if (_checkT8_2.IsSelected())
                        _configuration.TierAndRarity.Add("8.2");
                    if (_checkT8_3.IsSelected())
                        _configuration.TierAndRarity.Add("8.3");
                    
                    _configuration.OnlyResourcesWithMoreThan1 = _checkOnlyShowMorethan1.IsSelected();

                    _panel.Destroy();

                    parent.EnterState("work");
                });
            });

            Logging.Log("Menu loaded", LogLevel.Info);

            return base.OnStart(se);            
        }        
    }
}

