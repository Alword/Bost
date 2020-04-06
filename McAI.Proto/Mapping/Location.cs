using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McAI.Proto.Mapping
{

    public struct Location
    {

        public double X;

        public double Y;

        public double Z;

        public static Location Zero
        {
            get
            {
                return new Location(0, 0, 0);
            }
        }

        public Location(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Location(int chunkX, int chunkZ, int blockX, int blockY, int blockZ)
        {
            X = chunkX * ChunkColumn.SizeX + blockX;
            Y = blockY;
            Z = chunkZ * ChunkColumn.SizeZ + blockZ;
        }

        public int ChunkX
        {
            get
            {
                return (int)Math.Floor(X / ChunkColumn.SizeX);
            }
        }

        public int ChunkY
        {
            get
            {
                return (int)Math.Floor(Y / ChunkColumn.SizeY);
            }
        }

        public int ChunkZ
        {
            get
            {
                return (int)Math.Floor(Z / ChunkColumn.SizeZ);
            }
        }
        public int ChunkBlockX
        {
            get
            {
                return ((int)Math.Floor(X) % ChunkColumn.SizeX + ChunkColumn.SizeX) % ChunkColumn.SizeX;
            }
        }

        public int ChunkBlockY
        {
            get
            {
                return ((int)Math.Floor(Y) % ChunkColumn.SizeY + ChunkColumn.SizeY) % ChunkColumn.SizeY;
            }
        }

        public int ChunkBlockZ
        {
            get
            {
                return ((int)Math.Floor(Z) % ChunkColumn.SizeZ + ChunkColumn.SizeZ) % ChunkColumn.SizeZ;
            }
        }

        public double DistanceSquared(Location location)
        {
            return ((X - location.X) * (X - location.X))
                 + ((Y - location.Y) * (Y - location.Y))
                 + ((Z - location.Z) * (Z - location.Z));
        }

        public double Distance(Location location)
        {
            return Math.Sqrt(DistanceSquared(location));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Location)
            {
                return ((int)this.X) == ((int)((Location)obj).X)
                    && ((int)this.Y) == ((int)((Location)obj).Y)
                    && ((int)this.Z) == ((int)((Location)obj).Z);
            }
            return false;
        }

        public static bool operator ==(Location loc1, Location loc2)
        {
            if (loc1 == null && loc2 == null)
                return true;
            if (loc1 == null || loc2 == null)
                return false;
            return loc1.Equals(loc2);
        }

        public static bool operator !=(Location loc1, Location loc2)
        {
            if (loc1 == null && loc2 == null)
                return true;
            if (loc1 == null || loc2 == null)
                return false;
            return !loc1.Equals(loc2);
        }

        public static Location operator +(Location loc1, Location loc2)
        {
            return new Location
            (
                loc1.X + loc2.X,
                loc1.Y + loc2.Y,
                loc1.Z + loc2.Z
            );
        }

        public static Location operator -(Location loc1, Location loc2)
        {
            return new Location
            (
                loc1.X - loc2.X,
                loc1.Y - loc2.Y,
                loc1.Z - loc2.Z
            );
        }

        public static Location operator *(Location loc, double val)
        {
            return new Location
            (
                loc.X * val,
                loc.Y * val,
                loc.Z * val
            );
        }

        public static Location operator /(Location loc, double val)
        {
            return new Location
            (
                loc.X / val,
                loc.Y / val,
                loc.Z / val
            );
        }


        public override string ToString()
        {
            return $"XYZ:{X} {Y} {Z}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}