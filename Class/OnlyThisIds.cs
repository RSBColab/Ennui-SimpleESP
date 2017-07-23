using Ennui.Api.Builder;
using Ennui.Api.Direct.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleESP.Class
{
    public class OnlyThisIds<T> : Filter<T> where T : ISimulationObject
    {
        private long[] ids;

        public OnlyThisIds(params long[] ids)
        {
            this.ids = ids;
        }

        public bool Ignore(T t)
        {
            var id = t.Id;
            foreach (var cur in ids)
            {
                if (id == cur)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
