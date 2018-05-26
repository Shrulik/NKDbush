using Xunit;

namespace Shrulik.NKDBush.Tests
{
    public class KDBushTests
    {
        private static double[][] pointsData =
        {
            new double[] {54, 1}, new double[] {97, 21}, new double[] {65, 35}, new double[] {33, 54},
            new double[] {95, 39}, new double[] {54, 3}, new double[] {53, 54}, new double[] {84, 72},
            new double[] {33, 34}, new double[] {43, 15}, new double[] {52, 83}, new double[] {81, 23},
            new double[] {1, 61}, new double[] {38, 74},
            new double[] {11, 91}, new double[] {24, 56}, new double[] {90, 31}, new double[] {25, 57},
            new double[] {46, 61}, new double[] {29, 69}, new double[] {49, 60}, new double[] {4, 98},
            new double[] {71, 15}, new double[] {60, 25}, new double[] {38, 84}, new double[] {52, 38},
            new double[] {94, 51}, new double[] {13, 25},
            new double[] {77, 73}, new double[] {88, 87}, new double[] {6, 27}, new double[] {58, 22},
            new double[] {53, 28}, new double[] {27, 91}, new double[] {96, 98}, new double[] {93, 14},
            new double[] {22, 93}, new double[] {45, 94}, new double[] {18, 28}, new double[] {35, 15},
            new double[] {19, 81}, new double[] {20, 81},
            new double[] {67, 53}, new double[] {43, 3}, new double[] {47, 66}, new double[] {48, 34},
            new double[] {46, 12}, new double[] {32, 38}, new double[] {43, 12}, new double[] {39, 94},
            new double[] {88, 62}, new double[] {66, 14}, new double[] {84, 30}, new double[] {72, 81},
            new double[] {41, 92}, new double[] {26, 4},
            new double[] {6, 76}, new double[] {47, 21}, new double[] {57, 70}, new double[] {71, 82},
            new double[] {50, 68}, new double[] {96, 18}, new double[] {40, 31}, new double[] {78, 53},
            new double[] {71, 90}, new double[] {32, 14}, new double[] {55, 6}, new double[] {32, 88},
            new double[] {62, 32}, new double[] {21, 67},
            new double[] {73, 81}, new double[] {44, 64}, new double[] {29, 50}, new double[] {70, 5},
            new double[] {6, 22}, new double[] {68, 3}, new double[] {11, 23}, new double[] {20, 42},
            new double[] {21, 73}, new double[] {63, 86}, new double[] {9, 40}, new double[] {99, 2},
            new double[] {99, 76}, new double[] {56, 77},
            new double[] {83, 6}, new double[] {21, 72}, new double[] {78, 30}, new double[] {75, 53},
            new double[] {41, 11}, new double[] {95, 20}, new double[] {30, 38}, new double[] {96, 82},
            new double[] {65, 48}, new double[] {33, 18}, new double[] {87, 28}, new double[] {10, 10},
            new double[] {40, 34},
            new double[] {10, 20}, new double[] {47, 29}, new double[] {46, 78}
        };

        private static int[] ids =
        {
            97, 74, 95, 30, 77, 38, 76, 27, 80, 55, 72, 90, 88, 48, 43, 46, 65, 39, 62, 93, 9, 96, 47, 8, 3, 12, 15, 14,
            21, 41, 36, 40, 69, 56, 85, 78, 17, 71, 44,
            19, 18, 13, 99, 24, 67, 33, 37, 49, 54, 57, 98, 45, 23, 31, 66, 68, 0, 32, 5, 51, 75, 73, 84, 35, 81, 22,
            61, 89, 1, 11, 86, 52, 94, 16, 2, 6, 25, 92,
            42, 20, 60, 58, 83, 79, 64, 10, 59, 53, 26, 87, 4, 63, 50, 7, 28, 82, 70, 29, 34, 91
        };

        private static double[] coords =
        {
            10, 20, 6, 22, 10, 10, 6, 27, 20, 42, 18, 28, 11, 23, 13, 25, 9, 40, 26, 4, 29, 50, 30, 38, 41, 11, 43, 12,
            43, 3, 46, 12, 32, 14, 35, 15, 40, 31, 33, 18,
            43, 15, 40, 34, 32, 38, 33, 34, 33, 54, 1, 61, 24, 56, 11, 91, 4, 98, 20, 81, 22, 93, 19, 81, 21, 67, 6, 76,
            21, 72, 21, 73, 25, 57, 44, 64, 47, 66, 29,
            69, 46, 61, 38, 74, 46, 78, 38, 84, 32, 88, 27, 91, 45, 94, 39, 94, 41, 92, 47, 21, 47, 29, 48, 34, 60, 25,
            58, 22, 55, 6, 62, 32, 54, 1, 53, 28, 54, 3,
            66, 14, 68, 3, 70, 5, 83, 6, 93, 14, 99, 2, 71, 15, 96, 18, 95, 20, 97, 21, 81, 23, 78, 30, 84, 30, 87, 28,
            90, 31, 65, 35, 53, 54, 52, 38, 65, 48, 67,
            53, 49, 60, 50, 68, 57, 70, 56, 77, 63, 86, 71, 90, 52, 83, 71, 82, 72, 81, 94, 51, 75, 53, 95, 39, 78, 53,
            88, 62, 84, 72, 77, 73, 99, 76, 73, 81, 88,
            87, 96, 98, 96, 82
        };

        [Fact]
        public void CreateKDBushIndex_TestIds()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            Assert.Equal(ids, index.ids);
        }

        [Fact]
        public void CreateKDBushIndex_TestsCoords()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);
            Assert.Equal(coords, index.coords);
        }

        [Fact]
        public void CreateKDBushIndex_RangeSearch_CorrectPointsReturned()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var result = index.Range(20, 30, 50, 70);            

            Assert.Equal(new[] {60, 20, 45, 3, 17, 71, 44, 19, 18, 15, 69, 90, 62, 96, 47, 8, 77, 72},
                result);
        }

        [Fact]
        public void CreateKDBushIndex_RangeSearch_AllReturnedPointsInRange()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var result = index.Range(20, 30, 50, 70);

            foreach (int pIdx in result)
            {
                var p = pointsData[pIdx];
                Assert.False(p[0] < 20 || p[0] > 50 || p[1] < 30 || p[1] > 70);
            }
        }

        [Fact]
        public void CreateKDBushIndex_RangeSearch_UnReturnedPointsAreOutsideRange()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var result = index.Range(20, 30, 50, 70);

            for (var i = 0; i < ids.Length; i++)
            {
                var p = pointsData[ids[i]];
                var pointIsNotInResult = result.IndexOf(ids[i]) < 0;
                Assert.False(pointIsNotInResult && p[0] >= 20 && p[0] <= 50 && p[1] >= 30 && p[1] <= 70);
            }
        }

        [Fact]
        public void CreateKDBushIndex_RadiusSearch_CorrectPointsReturned()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var qp = new double[] {50, 50};
            var r = 20;

            var result = index.Within(qp[0], qp[1], r);

            Assert.Equal(new[] {60, 6, 25, 92, 42, 20, 45, 3, 71, 44, 18, 96}, result);
        }

        [Fact]
        public void CreateKDBushIndex_RadiusSearch_AllReturnedPointsInRadius()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var qp = new double[] {50, 50};
            var r = 20;
            var r2 = 20 * 20;

            var result = index.Within(qp[0], qp[1], r);

            for (var i = 0; i < result.Count; i++)
            {
                var p = pointsData[result[i]];
                Assert.False(SqDist(p, qp) > r2);
            }
        }

        [Fact]
        public void CreateKDBushIndex_RadiusSearch_AllUnReturnedPointsOutsideRadius()
        {
            var index = new KDBush<double[]>(pointsData, nodeSize: 10);

            var qp = new double[] {50, 50};
            var r = 20;
            var r2 = 20 * 20;

            var result = index.Within(qp[0], qp[1], r);

            for (var i = 0; i < ids.Length; i++)
            {
                var p = pointsData[ids[i]];
                Assert.False(result.IndexOf(ids[i]) < 0 && SqDist(p, qp) <= r2);
            }
        }


        private double SqDist(double[] a, double[] b)
        {
            var dx = a[0] - b[0];

            var dy = a[1] - b[1];
            return dx * dx + dy * dy;
        }     
    }
}
