using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public enum CollisionType { Passable = 0, Impassable = 1 }

    public class CollisionLayer
    {
        public const int CollisionRadius = 0;

        private readonly Dictionary<Point, CollisionType> collisions;

        public Dictionary<Point, CollisionType> Collisions
        {
            get { return collisions; }
        }

        public CollisionLayer()
        {
            collisions = new Dictionary<Point, CollisionType>();
        }
    }
}
