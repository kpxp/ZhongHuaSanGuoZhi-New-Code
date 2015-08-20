namespace GameObjects
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using System;

    public class RoutePoint
    {
        public int ActiveFundCost;
        public Routeway BelongedRouteway;
        public int BuildFundCost;
        public int BuildWorkCost;
        public float ConsumptionRate;
        public SimpleDirection Direction;
        public int Index;
        public Point Position;
        public SimpleDirection PreviousDirection;
    }
}

