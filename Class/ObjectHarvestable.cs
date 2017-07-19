using Ennui.Api.Direct.Object;
using Ennui.Api.Meta;
using System;

namespace SimpleESP.Class
{
    class ObjectHarvestable
    {
        public ResourceType Type { get; set; }
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }

        public ObjectHarvestable(IHarvestableObject harvestableObject)
        {
            ScreenX = Convert.ToInt32(harvestableObject.ScreenLocation.X);
            ScreenY = Convert.ToInt32(harvestableObject.ScreenLocation.Y);
            Type = harvestableObject.Type;
        }

        public ObjectHarvestable(IMobObject mobObject)
        {
            ScreenX = Convert.ToInt32(mobObject.ScreenLocation.X);
            ScreenY = Convert.ToInt32(mobObject.ScreenLocation.Y);
            Type = ResourceType.Hide;
        }
    }
}
