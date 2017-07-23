using Ennui.Api.Builder;
using Ennui.Api.Direct.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleESP.Class
{
    public class ListTierAndRarityFilter : Filter<IHarvestableObject>
    {
        private List<string> _tierAndRarity;

        public ListTierAndRarityFilter(List<string> tierAndRarity)
        {
            _tierAndRarity = tierAndRarity;
        }

        public bool Ignore(IHarvestableObject t)
        {
            return !_tierAndRarity.Contains(t.Tier + "." + t.RareState);
        }
    }
}
