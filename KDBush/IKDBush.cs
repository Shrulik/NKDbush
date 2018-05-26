using System.Collections.Generic;

namespace Shrulik.NKDBush
{
    public interface IKDBush<T>
    {
        T[] points { get; }
        double[] coords { get; }
        int[] ids { get; }
        int nodeSize { get; }
        List<int> Range(double minX, double minY, double maxX, double maxY);
        List<int> Within(double x, double y, double r);
    }
}
