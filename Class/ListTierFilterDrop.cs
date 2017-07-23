using Ennui.Api.Builder;
using Ennui.Api.Direct.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleESP.Class
{
    public class ListTierAndRarityFilterDrop : Filter<MobHarvestableDrop>
    {
        private List<string> _tierAndRarity;

        public ListTierAndRarityFilterDrop(List<string> tierAndRarity)
        {
            _tierAndRarity = tierAndRarity;
        }

        public bool Ignore(MobHarvestableDrop t)
        {
            return !_tierAndRarity.Contains(t.Tier + "." + t.Rarity);
        }
    }
}
