using Ennui.Api;
using Ennui.Api.Direct.Object;
using Ennui.Api.Script;
using System;
using System.Linq;
using System.Collections.Generic;
using SimpleESP.Class;

namespace SimpleESP
{    
    public class WorkState: StateScript
    {
        private Configuration _configuration;

        public WorkState(Configuration configuration)
        {
            _configuration = configuration;
        }
        
        public override void OnPaint(IScriptEngine se, GraphicContext g)
        {
            if (Players.LocalPlayer == null)
                return;

            
            if (_configuration.ESPActivatedPlayers)
            {                
                var otherPlayers = Players.RemotePlayers;
                foreach (var otherPlayer in otherPlayers)
                {
                    if (otherPlayer?.ScreenLocation != null)
                    {
                        if (otherPlayer.IsPvpEnabled)
                            g.SetColor(Color.Orange);
                        else
                            g.SetColor(Color.Green);


                        g.DrawLine(Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X),
                            Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y),
                            Convert.ToInt32(otherPlayer.ScreenLocation.X),
                            Convert.ToInt32(otherPlayer.ScreenLocation.Y));
                    }
                }
            }
            
            if (_configuration.ESPActivatedResources)
            {
                var harvestables = Objects.AllHarvestables.FindAll(x => !x.Depleted && x.ScreenLocation != null);                
                var harvestablesValid = new List<ObjectHarvestable>();
                foreach (var harvestable in harvestables)
                {
                    if (harvestable != null)
                    {
                        if ((_configuration.ResFiber && harvestable.Type == Ennui.Api.Meta.ResourceType.Fiber) ||
                            (_configuration.ResOre && harvestable.Type == Ennui.Api.Meta.ResourceType.Ore) ||
                            (_configuration.ResStone && harvestable.Type == Ennui.Api.Meta.ResourceType.Rock) ||
                            (_configuration.ResTree && harvestable.Type == Ennui.Api.Meta.ResourceType.Wood) ||
                            (_configuration.ResLeather && harvestable.Type == Ennui.Api.Meta.ResourceType.Hide))
                        {
                            if ((harvestable.Tier == 2 && _configuration.ResT2) ||
                               (harvestable.Tier == 3 && _configuration.ResT3) ||
                               (harvestable.Tier == 4 && harvestable.RareState == 0 && _configuration.ResT4) ||
                               (harvestable.Tier == 4 && harvestable.RareState == 1 && _configuration.ResT4_1) ||
                               (harvestable.Tier == 4 && harvestable.RareState == 2 && _configuration.ResT4_2) ||
                               (harvestable.Tier == 4 && harvestable.RareState == 3 && _configuration.ResT4_3) ||
                               (harvestable.Tier == 5 && harvestable.RareState == 0 && _configuration.ResT5) ||
                               (harvestable.Tier == 5 && harvestable.RareState == 1 && _configuration.ResT5_1) ||
                               (harvestable.Tier == 5 && harvestable.RareState == 2 && _configuration.ResT5_2) ||
                               (harvestable.Tier == 5 && harvestable.RareState == 3 && _configuration.ResT5_3) ||
                               (harvestable.Tier == 6 && harvestable.RareState == 0 && _configuration.ResT6) ||
                               (harvestable.Tier == 6 && harvestable.RareState == 1 && _configuration.ResT6_1) ||
                               (harvestable.Tier == 6 && harvestable.RareState == 2 && _configuration.ResT6_2) ||
                               (harvestable.Tier == 6 && harvestable.RareState == 3 && _configuration.ResT6_3) ||
                               (harvestable.Tier == 7 && harvestable.RareState == 0 && _configuration.ResT7) ||
                               (harvestable.Tier == 7 && harvestable.RareState == 1 && _configuration.ResT7_1) ||
                               (harvestable.Tier == 7 && harvestable.RareState == 2 && _configuration.ResT7_2) ||
                               (harvestable.Tier == 7 && harvestable.RareState == 3 && _configuration.ResT7_3) ||
                               (harvestable.Tier == 8 && harvestable.RareState == 0 && _configuration.ResT8) ||
                               (harvestable.Tier == 8 && harvestable.RareState == 1 && _configuration.ResT8_1) ||
                               (harvestable.Tier == 8 && harvestable.RareState == 2 && _configuration.ResT8_2) ||
                               (harvestable.Tier == 8 && harvestable.RareState == 3 && _configuration.ResT8_3))
                            {                                
                                harvestablesValid.Add(new ObjectHarvestable(harvestable));
                            }
                        }
                    }                    
                }

                if (_configuration.ResLeather)
                {
                    var mobsWithDrops = Entities.Mobs.FindAll(x => x.HarvestableDrops.Count > 0 && x.ScreenLocation != null);
                    foreach (var mob in mobsWithDrops)
                    {
                        if ((_configuration.ResT2 && mob.HarvestableDrops.Any(x => x.Tier == 2)) ||
                            (_configuration.ResT3 && mob.HarvestableDrops.Any(x => x.Tier == 3)) ||
                            (_configuration.ResT4 && mob.HarvestableDrops.Any(x => x.Tier == 4 && x.Rarity == 0)) ||
                            (_configuration.ResT4_1 && mob.HarvestableDrops.Any(x => x.Tier == 4 && x.Rarity == 1)) ||
                            (_configuration.ResT4_2 && mob.HarvestableDrops.Any(x => x.Tier == 4 && x.Rarity == 2)) ||
                            (_configuration.ResT4_3 && mob.HarvestableDrops.Any(x => x.Tier == 4 && x.Rarity == 3)) ||
                            (_configuration.ResT5_1 && mob.HarvestableDrops.Any(x => x.Tier == 5 && x.Rarity == 1)) ||
                            (_configuration.ResT5_2 && mob.HarvestableDrops.Any(x => x.Tier == 5 && x.Rarity == 2)) ||
                            (_configuration.ResT5_3 && mob.HarvestableDrops.Any(x => x.Tier == 5 && x.Rarity == 3)) ||
                            (_configuration.ResT6_1 && mob.HarvestableDrops.Any(x => x.Tier == 6 && x.Rarity == 1)) ||
                            (_configuration.ResT6_2 && mob.HarvestableDrops.Any(x => x.Tier == 6 && x.Rarity == 2)) ||
                            (_configuration.ResT6_3 && mob.HarvestableDrops.Any(x => x.Tier == 6 && x.Rarity == 3)) ||
                            (_configuration.ResT7_1 && mob.HarvestableDrops.Any(x => x.Tier == 7 && x.Rarity == 1)) ||
                            (_configuration.ResT7_2 && mob.HarvestableDrops.Any(x => x.Tier == 7 && x.Rarity == 2)) ||
                            (_configuration.ResT7_3 && mob.HarvestableDrops.Any(x => x.Tier == 7 && x.Rarity == 3)) ||
                            (_configuration.ResT8_1 && mob.HarvestableDrops.Any(x => x.Tier == 8 && x.Rarity == 1)) ||
                            (_configuration.ResT8_2 && mob.HarvestableDrops.Any(x => x.Tier == 8 && x.Rarity == 2)) ||
                            (_configuration.ResT8_3 && mob.HarvestableDrops.Any(x => x.Tier == 8 && x.Rarity == 3)))
                        {
                            harvestablesValid.Add(new ObjectHarvestable(mob));
                        }
                    }
                }

                foreach (var harvestable in harvestablesValid)
                {
                    switch (harvestable.Type)
                    {
                        case Ennui.Api.Meta.ResourceType.Fiber:
                            g.SetColor(Color.Yellow);
                            break;
                        case Ennui.Api.Meta.ResourceType.Ore:
                            g.SetColor(Color.Black);
                            break;
                        case Ennui.Api.Meta.ResourceType.Hide:
                            g.SetColor(Color.Orange);
                            break;
                        case Ennui.Api.Meta.ResourceType.Wood:
                            g.SetColor(Color.Purple);
                            break;
                        case Ennui.Api.Meta.ResourceType.Rock:
                            g.SetColor(Color.Cyan);
                            break;
                        default:
                            g.SetColor(Color.Blue);
                            break;
                    }
                    g.DrawLine(Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X),
                        Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y),
                        harvestable.ScreenX,
                        harvestable.ScreenY);

                    // Calculate distance
                    var absX = Math.Abs(Players.LocalPlayer.ScreenLocation.X - harvestable.ScreenX);
                    var absY = Math.Abs(Players.LocalPlayer.ScreenLocation.Y - harvestable.ScreenY);
                    var distance = absX + absY;

                    if (distance > 500)
                    {
                        if (Math.Abs(harvestable.ScreenX) >= Math.Abs(harvestable.ScreenY))
                        {
                            if (Players.LocalPlayer.ScreenLocation.X < harvestable.ScreenX)
                            {
                                var y = ((harvestable.ScreenY - Players.LocalPlayer.ScreenLocation.Y) / (harvestable.ScreenX - Players.LocalPlayer.ScreenLocation.X)) * 100;
                                g.DrawString(distance.ToString(), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X + 100), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y + y));
                            }
                            else if (Players.LocalPlayer.ScreenLocation.X > harvestable.ScreenX)
                            {
                                var y = ((harvestable.ScreenY - Players.LocalPlayer.ScreenLocation.Y) / (harvestable.ScreenX - Players.LocalPlayer.ScreenLocation.X)) * -100;
                                g.DrawString(distance.ToString(), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X - 100), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y + y));
                            }
                        }
                        else
                        {
                            if (Players.LocalPlayer.ScreenLocation.Y < harvestable.ScreenY)
                            {
                                var x = (harvestable.ScreenX - Players.LocalPlayer.ScreenLocation.X) * 100 / (harvestable.ScreenY - Players.LocalPlayer.ScreenLocation.Y);
                                g.DrawString(distance.ToString(), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X + x), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y + 100));
                            }
                            else if (Players.LocalPlayer.ScreenLocation.Y > harvestable.ScreenY)
                            {
                                var x = (harvestable.ScreenX - Players.LocalPlayer.ScreenLocation.X) * -100 / (harvestable.ScreenY - Players.LocalPlayer.ScreenLocation.Y);
                                g.DrawString(distance.ToString(), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X + x), Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y - 100));
                            }
                        }
                    }
                }
            }
        }
    }
}
