using System;
using System.Collections.Generic;
using System.Linq;

namespace Shrulik.NKDBush
{
    public class WithinKD
    {
        public static List<int> Within(int[] ids, double[] coords, double qx, double qy, double r, int nodeSize)
        {
            var stack = new Stack<int>(new[] {0, ids.Length - 1, 0});
            var result = new List<int>();
            var r2 = r * r;

            while (stack.Any())
            {
                var axis = stack.Pop();
                var right = stack.Pop();
                var left = stack.Pop();

                if (right - left <= nodeSize)
                {
                    for (var i = left; i <= right; i++)
                    {
                        if (SquareDistance(coords[2 * i], coords[2 * i + 1], qx, qy) <= r2)
                            result.Add(ids[i]);
                    }
                    continue;
                }

                var m = (int) Math.Floor(((double) left + right) / 2);

                var x = coords[2 * m];
                var y = coords[2 * m + 1];

                if (SquareDistance(x, y, qx, qy) <= r2)
                    result.Add(ids[m]);

                var nextAxis = (axis + 1) % 2;

                if (axis == 0 ? qx - r <= x : qy - r <= y)
                {
                    stack.Push(left);
                    stack.Push(m - 1);
                    stack.Push(nextAxis);
                }
                if (axis == 0 ? qx + r >= x : qy + r >= y)
                {
                    stack.Push(m + 1);
                    stack.Push(right);
                    stack.Push(nextAxis);
                }
            }

            return result;
        }

        static double SquareDistance(double ax, double ay, double bx, double by)
        {
            var dx = ax - bx;
            var dy = ay - by;
            return dx * dx + dy * dy;
        }
    }
}
