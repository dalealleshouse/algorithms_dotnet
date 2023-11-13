```

BenchmarkDotNet v0.13.10, Pengwin WSL
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  Job-SLGRKP : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

IterationCount=3  

```
| Method      | N    | Mean           | Error          | StdDev        |
|------------ |----- |---------------:|---------------:|--------------:|
| **Insert**      | **100**  |    **84,072.4 ns** |    **54,288.5 ns** |   **2,975.73 ns** |
| Search      | 100  |     3,380.6 ns |     5,432.5 ns |     297.77 ns |
| Max         | 100  |       773.9 ns |       631.0 ns |      34.59 ns |
| Predecessor | 100  |     5,470.5 ns |     3,418.0 ns |     187.35 ns |
| Rank        | 100  |     1,223.0 ns |       883.5 ns |      48.43 ns |
| **Insert**      | **1000** | **8,243,654.7 ns** | **2,991,057.3 ns** | **163,949.94 ns** |
| Search      | 1000 |    46,537.3 ns |   103,285.2 ns |   5,661.41 ns |
| Max         | 1000 |     8,146.2 ns |    11,457.3 ns |     628.01 ns |
| Predecessor | 1000 |    73,939.2 ns |    47,923.9 ns |   2,626.87 ns |
| Rank        | 1000 |    12,225.9 ns |    10,426.9 ns |     571.53 ns |
