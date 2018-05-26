using System;
using System.Collections.Generic;

namespace Shrulik.NKDBush
{
    public class KDBush<T> : IKDBush<T>
    {
        public double[] coords { get; }
        public int[] ids { get; }
        public int nodeSize { get; }
        public T[] points { get; }


        private readonly Func<T, double> DefaultGetX = p =>
        {
            var asDoubles = (double[]) (object) p;
            return asDoubles[0];
        };

        private readonly Func<T, double> DefaultGetY = p =>
        {
            var asDoubles = (double[]) (object) p;
            return asDoubles[1];
        };

        public KDBush(T[] points, Func<T, double> getX = null, Func<T, double> getY = null,
            int nodeSize = 64)
        {
            getX = getX ?? DefaultGetX;
            getY = getY ?? DefaultGetY;

            this.nodeSize = nodeSize;
            this.points = points;

            ids = new int[points.Length];
            coords = new double[points.Length * 2];

            for (var i = 0; i < points.Length; i++)
            {
                this.ids[i] = i;
                this.coords[2 * i] = getX(points[i]);
                this.coords[2 * i + 1] = getY(points[i]);
            }

            SortKD.Sort(ids, coords, nodeSize, 0, ids.Length - 1, 0);
        }

        public List<int> Range(double minX, double minY, double maxX, double maxY)
        {
            return RangeKD.Range(this.ids, this.coords, minX, minY, maxX, maxY, this.nodeSize);
        }

        public List<int> Within(double x, double y, double r)
        {
            return WithinKD.Within(this.ids, this.coords, x, y, r, this.nodeSize);
        }
    }
}
