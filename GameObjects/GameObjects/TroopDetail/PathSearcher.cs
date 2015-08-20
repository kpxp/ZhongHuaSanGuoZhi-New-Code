namespace GameObjects.TroopDetail
{
    using GameObjects;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class PathSearcher
    {
        internal event CheckPosition OnCheckPosition;

        internal bool Search(Troop troop, int startingIndex, int count)
        {
            return false;
        }

        internal delegate PathResult CheckPosition(Point position, List<Point> middlePath, MilitaryKind kind);
    }
}

