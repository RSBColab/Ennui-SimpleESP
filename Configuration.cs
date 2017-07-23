using Ennui.Api.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleESP
{
    public class Configuration
    {        
        public bool ESPActivatedResources { get; set; }
        public bool ESPActivatedPlayers { get; set; }
        public ResourceType[] Resources { get; set; }   
        public List<string> TierAndRarity { get; set; }        
        public bool OnlyResourcesWithMoreThan1 { get; set; }

        public Configuration()
        {
            TierAndRarity = new List<string>();
        }
    }
}
