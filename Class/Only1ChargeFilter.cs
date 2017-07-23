using Ennui.Api.Builder;
using Ennui.Api.Direct.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleESP.Class
{
    public class Only1ChargeFilter : Filter<IHarvestableObject>
    {
        public bool Ignore(IHarvestableObject t)
        {
            return t.Charges != 1;
        }
    }
}
