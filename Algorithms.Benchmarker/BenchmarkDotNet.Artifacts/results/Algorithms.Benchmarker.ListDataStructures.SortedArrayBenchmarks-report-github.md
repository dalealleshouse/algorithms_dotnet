```

BenchmarkDotNet v0.13.10, Pengwin WSL
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  Job-HPDGDT : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

IterationCount=3  

```
| Method      | N     | Mean             | Error            | StdDev          |
|------------ |------ |-----------------:|-----------------:|----------------:|
| **Insert**      | **100**   |      **84,018.5 ns** |      **45,139.7 ns** |     **2,474.26 ns** |
| Search      | 100   |       3,238.6 ns |       2,601.3 ns |       142.59 ns |
| Max         | 100   |         761.3 ns |         604.5 ns |        33.13 ns |
| Predecessor | 100   |       5,357.7 ns |       4,714.7 ns |       258.43 ns |
| Rank        | 100   |       1,156.1 ns |         854.4 ns |        46.83 ns |
| **Insert**      | **1000**  |   **7,400,629.7 ns** |   **3,309,684.0 ns** |   **181,414.95 ns** |
| Search      | 1000  |      48,248.2 ns |      96,465.6 ns |     5,287.60 ns |
| Max         | 1000  |       7,494.8 ns |       3,535.0 ns |       193.76 ns |
| Predecessor | 1000  |      62,202.2 ns |      57,598.1 ns |     3,157.14 ns |
| Rank        | 1000  |      11,992.3 ns |       8,946.6 ns |       490.40 ns |
| **Insert**      | **10000** | **653,879,787.7 ns** | **154,391,360.7 ns** | **8,462,711.45 ns** |
| Search      | 10000 |     641,480.1 ns |     162,835.4 ns |     8,925.56 ns |
| Max         | 10000 |      74,488.2 ns |      54,744.7 ns |     3,000.74 ns |
| Predecessor | 10000 |     679,476.9 ns |     404,279.9 ns |    22,159.94 ns |
| Rank        | 10000 |     125,407.3 ns |     121,563.5 ns |     6,663.31 ns |
