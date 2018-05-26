## NKdbush 

A static spatial index for 2D points based on a flat KD-tree for .Net 
Ported direclty from a JS library [kdbush](https://github.com/mourner/kdbush) :

- points only — no rectangles
- static — you can't add/remove items


```csharp
var index = new KDBush<double[]>(pointsData, nodeSize: 10); // make an index
var ids1 = index.Range(20, 30, 50, 70);  // bbox search - minX, minY, maxX, maxY
var ids2 = index.Within(10, 10, 5);      // radius search - x, y, radius
```

## API

#### KDBush(T[] points, Func<T, double> getX = null, Func<T, double> getY = null, int nodeSize = 64)

Creates an index from the given points.

- `points`: Input array of points of type T.
- `getX`, `getY`: Functions to get `x` and `y` from an input point. By default, it assumes `[x, y]` format.
- `nodeSize`: Size of the KD-tree node, `64` by default. Higher means faster indexing but slower search, and vise versa.

```csharp
var index = new KDBush<double[]>(pointsData, getX: p => p[0], getY: p => p[1], nodeSize: 64);
```

#### Range(double minX, double minY, double maxX, double maxY)  

Finds all items within the given bounding box and returns a List<int> of indices that refer to the items in the original `points` input array.

```csharp
var index = new KDBush<double[]>(points);
var results = index.Range(20, 30, 50, 70).Select(id => points[id]);
```

#### Within(double x, double y, double r)

Finds all items within a given radius from the query point and returns a List<int> of indices.

```csharp
var index = new KDBush<double[]>(points);
var queryPoint = new double[] {50, 50};
var r = 20;
var results = index.Within(queryPoint[0], queryPoint[1], r);
```
