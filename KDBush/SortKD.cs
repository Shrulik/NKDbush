using System;

namespace Shrulik.NKDBush
{
    public class SortKD
    {
        public static void Sort(int[] ids, double[] coords, int nodeSize, int left, int right, int depth)
        {
            if (right - left <= nodeSize) return;

            var m = (int) Math.Floor(((double) right + left) / 2);

            Select(ids, coords, m, left, right, depth % 2);

            Sort(ids, coords, nodeSize, left, m - 1, depth + 1);
            Sort(ids, coords, nodeSize, m + 1, right, depth + 1);
        }

        public static void Select(int[] ids, double[] coords, int k, int left, int right, int inc)
        {
            while (right > left)
            {
                if (right - left > 600)
                {
                    var n = right - left + 1;
                    var m = k - left + 1;
                    var z = Math.Log(n);
                    var s = 0.5 * Math.Exp(2 * z / 3);
                    var sd = 0.5 * Math.Sqrt(z * s * (n - s) / n) * (m - n / 2 < 0 ? -1 : 1);
                    var newLeft = (int) Math.Max(left, Math.Floor(k - m * s / n + sd));
                    var newRight = (int) Math.Min(right, Math.Floor(k + (n - m) * s / n + sd));
                    Select(ids, coords, k, newLeft, newRight, inc);
                }

                var t = coords[2 * k + inc];
                var i = left;
                var j = right;

                SwapItem(ids, coords, left, k);
                if (coords[2 * right + inc] > t) SwapItem(ids, coords, left, right);

                while (i < j)
                {
                    SwapItem(ids, coords, i, j);
                    i++;
                    j--;
                    while (coords[2 * i + inc] < t) i++;
                    while (coords[2 * j + inc] > t) j--;
                }

                if (coords[2 * left + inc] == t) SwapItem(ids, coords, left, j);
                else
                {
                    j++;
                    SwapItem(ids, coords, j, right);
                }

                if (j <= k) left = j + 1;
                if (k <= j) right = j - 1;
            }
        }

        private static void Swap<T>(T[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        private static void SwapItem(int[] ids, double[] coords, int i, int j)
        {
            Swap(ids, i, j);
            Swap(coords, 2 * i, 2 * j);
            Swap(coords, 2 * i + 1, 2 * j + 1);
        }
    }
}
