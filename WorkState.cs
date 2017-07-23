using Ennui.Api;
using Ennui.Api.Direct.Object;
using Ennui.Api.Script;
using System;
using System.Linq;
using System.Collections.Generic;
using SimpleESP.Class;
using Ennui.Api.Meta;

namespace SimpleESP
{    
    public class WorkState: StateScript
    {
        private Configuration _configuration;
        private List<long> _players;
        private List<long> _harvestable;
        private List<long> _mobs;

        public WorkState(Configuration configuration)
        {
            _players = new List<long>();
            _harvestable = new List<long>();
            _mobs = new List<long>();
            _configuration = configuration;            
        }

        public override int OnLoop(IScriptEngine se)
        {
            if (Players.LocalPlayer == null)
                return 1000;
            
            var currentPlayers = new List<long>();
            var currentHarvestables = new List<long>();
            var currentMobs = new List<long>();

            var localLocation = Players.LocalPlayer.ThreadSafeLocation;



            if (_configuration.ESPActivatedPlayers)
            {                
                var otherPlayers = Players.RemotePlayers.OrderBy(x => x.ThreadSafeLocation.SimpleDistance(localLocation));
                var i = 0;
                foreach (var otherPlayer in otherPlayers)
                {
                    if (i == 10)
                        break;
                    currentPlayers.Add(otherPlayer.Id);
                    i++;                                       
                }
            }

            if (_configuration.ESPActivatedResources)
            {
                var harvestableChain = Objects.HarvestableChain
                    .FilterDepleted()
                    .FilterByType(_configuration.Resources)
                    .Filter(new ListTierAndRarityFilter(_configuration.TierAndRarity));

                IOrderedEnumerable<IHarvestableObject> harvestables;
                if (_configuration.OnlyResourcesWithMoreThan1)
                {
                    harvestables = harvestableChain
                    .Filter(new Only1ChargeFilter())
                    .AsList
                    .OrderBy(x => x.ThreadSafeLocation.SimpleDistance(localLocation));
                }
                else
                {
                    harvestables = harvestableChain
                    .AsList
                    .OrderBy(x => x.ThreadSafeLocation.SimpleDistance(localLocation));
                }

                var i = 0;
                foreach (var harvestable in harvestables)
                {
                    if (i == 10)
                        break;
                    currentHarvestables.Add(harvestable.Id);
                    i++;
                }

                foreach (var mob in Entities.Mobs)
                {
                    if (i == 10)
                        break;

                    var mobDrop = mob.HarvestableDropChain
                        .FilterByType(_configuration.Resources)
                        .Filter(new ListTierAndRarityFilterDrop(_configuration.TierAndRarity))
                        .AsList;

                    if (mobDrop.Count > 0)
                    {
                        currentMobs.Add(mob.Id);
                        i++;
                    }
                }
            }

            _players = currentPlayers;
            _harvestable = currentHarvestables;
            _mobs = currentMobs;
            return 100;
        }

        private void DrawDistance(Vector2<float> localPlayerPos, Vector2<float> targetPos, GraphicContext g)
        {
            g.DrawLine(Convert.ToInt32(localPlayerPos.X),
                           Convert.ToInt32(localPlayerPos.Y),
                           Convert.ToInt32(targetPos.X),
                           Convert.ToInt32(targetPos.Y));

            // Calculate distance
            var distance = localPlayerPos.SimpleDistance(localPlayerPos);

            if (Math.Abs(targetPos.X) >= Math.Abs(targetPos.Y))
            {
                if (localPlayerPos.X < targetPos.X)
                {
                    var y = ((targetPos.Y - localPlayerPos.Y) / (targetPos.X - localPlayerPos.X)) * 100;
                    g.DrawString(distance.ToString(), Convert.ToInt32(localPlayerPos.X + 100), Convert.ToInt32(localPlayerPos.Y + y));
                }
                else if (localPlayerPos.X > targetPos.X)
                {
                    var y = ((targetPos.Y - localPlayerPos.Y) / (targetPos.X - localPlayerPos.X)) * -100;
                    g.DrawString(distance.ToString(), Convert.ToInt32(localPlayerPos.X - 100), Convert.ToInt32(localPlayerPos.Y + y));
                }
            }
            else
            {
                if (localPlayerPos.Y < targetPos.Y)
                {
                    var x = (targetPos.X - localPlayerPos.X) * 100 / (targetPos.Y - localPlayerPos.Y);
                    g.DrawString(distance.ToString(), Convert.ToInt32(localPlayerPos.X + x), Convert.ToInt32(localPlayerPos.Y + 100));
                }
                else if (localPlayerPos.Y > targetPos.Y)
                {
                    var x = (targetPos.X - localPlayerPos.X) * -100 / (targetPos.Y - localPlayerPos.Y);
                    g.DrawString(distance.ToString(), Convert.ToInt32(localPlayerPos.X + x), Convert.ToInt32(localPlayerPos.Y - 100));
                }
            }
        }

        public override void OnPaint(IScriptEngine se, GraphicContext g)
        {
            if (Players.LocalPlayer == null)
                return;

            var localPlayerPos = Players.LocalPlayer.ScreenLocation;
            
            if (_players.Count > 0)
            {                
                var playerList = Players.RemotePlayerChain
                    .Filter(new OnlyThisIds<IRemotePlayerObject>(_players.ToArray()))                  
                    .AsList;

                foreach (var otherPlayer in playerList)
                {
                    var screenPosition = otherPlayer.ScreenLocation;
                    if (screenPosition != null)
                    {
                        if (otherPlayer.IsPvpEnabled)
                            g.SetColor(Color.Orange);
                        else
                            g.SetColor(Color.Green);

                        DrawDistance(localPlayerPos, screenPosition, g);
                    }
                }
            }

            if (_harvestable.Count > 0)
            {                
                var harvestableList = Objects.HarvestableChain.Filter(new OnlyThisIds<IHarvestableObject>(_harvestable.ToArray())).AsList;

                foreach (var harvestable in harvestableList)
                {
                    var screenPosition = harvestable.ScreenLocation;
                    if (screenPosition != null)
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
                            case Ennui.Api.Meta.ResourceType.Coins:
                                g.SetColor(Color.White);
                                break;
                            default:
                                g.SetColor(Color.Blue);
                                break;
                        }
                       

                        DrawDistance(localPlayerPos, screenPosition, g);
                    }
                }
            }

            if (_mobs.Count > 0)
            {
                var harvestableList = Entities.MobChain.Filter(new OnlyThisIds<IMobObject>(_mobs.ToArray())).AsList;

                foreach (var harvestable in harvestableList)
                {
                    var screenPosition = harvestable.ScreenLocation;
                    if (screenPosition != null)
                    {
                        g.SetColor(Color.SkyBlue);                         
                        DrawDistance(localPlayerPos, screenPosition, g);
                    }
                }
            }
        }
    }
}
