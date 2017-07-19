using Ennui.Api;
using Ennui.Api.Direct.Object;
using Ennui.Api.Script;
using System;
using System.Collections.Generic;

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
                var harvestables = Objects.AllHarvestables.FindAll(x => !x.Depleted);
                var harvestablesValid = new List<IHarvestableObject>();
                foreach (var harvestable in harvestables)
                {
                    if (harvestable != null)
                    {
                        if ((_configuration.ResFiber && harvestable.Type == Ennui.Api.Meta.ResourceType.Fiber) ||
                            (_configuration.ResOre && harvestable.Type == Ennui.Api.Meta.ResourceType.Ore) ||
                            (_configuration.ResStone && harvestable.Type == Ennui.Api.Meta.ResourceType.Rock) ||
                            (_configuration.ResTree && harvestable.Type == Ennui.Api.Meta.ResourceType.Wood))
                        {
                            if ((harvestable.Tier == 2 && _configuration.ResT2) ||
                               (harvestable.Tier == 3 && _configuration.ResT3) ||
                               (harvestable.Tier == 4 && _configuration.ResT4) ||
                               (harvestable.Tier == 5 && _configuration.ResT5) ||
                               (harvestable.Tier == 6 && _configuration.ResT6) ||
                               (harvestable.Tier == 7 && _configuration.ResT7) ||
                               (harvestable.Tier == 8 && _configuration.ResT8))
                            harvestablesValid.Add(harvestable);
                        }
                    }
                }

                foreach (var harvestable in harvestablesValid)
                {
                    if(harvestable.ScreenLocation != null)
                    {
                        g.SetColor(Color.Blue);
                        g.DrawLine(Convert.ToInt32(Players.LocalPlayer.ScreenLocation.X),
                            Convert.ToInt32(Players.LocalPlayer.ScreenLocation.Y),
                            Convert.ToInt32(harvestable.ScreenLocation.X),
                            Convert.ToInt32(harvestable.ScreenLocation.Y));
                    }
                }
            }
        }
    }
}
