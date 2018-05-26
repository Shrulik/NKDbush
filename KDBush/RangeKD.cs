using System;
using System.Collections.Generic;
using System.Linq;

namespace Shrulik.NKDBush
{
    public class RangeKD
    {
        public static List<int> Range(int[] ids, double[] coords, double minX, double minY, double maxX, double maxY,
            int nodeSize)
        {
            var stack = new Stack<int>(new[] {0, ids.Length - 1, 0});
            var result = new List<int>();
            double x, y;

            while (stack.Any())
            {
                var axis = stack.Pop();
                var right = stack.Pop();
                var left = stack.Pop();

                if (right - left <= nodeSize)
                {
                    for (var i = left; i <= right; i++)
                    {
                        x = coords[2 * i];
                        y = coords[2 * i + 1];
                        if (x >= minX && x <= maxX && y >= minY && y <= maxY) result.Add(ids[i]);
                    }
                    continue;
                }

                var m = (int) Math.Floor(((double) left + right) / 2);

                x = coords[2 * m];
                y = coords[2 * m + 1];

                if (x >= minX && x <= maxX && y >= minY && y <= maxY) result.Add(ids[m]);

                var nextAxis = (axis + 1) % 2;

                if (axis == 0 ? minX <= x : minY <= y)
                {
                    stack.Push(left);
                    stack.Push(m - 1);
                    stack.Push(nextAxis);
                }
                if (axis == 0 ? maxX >= x : maxY >= y)
                {
                    stack.Push(m + 1);
                    stack.Push(right);
                    stack.Push(nextAxis);
                }
            }

            return result;
        }
    }
}
