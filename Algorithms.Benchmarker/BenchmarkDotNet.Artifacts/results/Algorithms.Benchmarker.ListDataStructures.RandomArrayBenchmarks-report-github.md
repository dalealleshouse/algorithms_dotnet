```

BenchmarkDotNet v0.13.10, Pengwin WSL
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  Job-SLGRKP : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

IterationCount=3  

```
| Method       | N    | Mean          | Error          | StdDev        |
|------------- |----- |--------------:|---------------:|--------------:|
| **InsertAtHead** | **100**  |      **4.343 μs** |      **6.8432 μs** |     **0.3751 μs** |
| InsertAtTail | 100  |      4.106 μs |      0.9803 μs |     0.0537 μs |
| Search       | 100  |    173.516 μs |    174.7729 μs |     9.5799 μs |
| Max          | 100  |    334.814 μs |    257.2868 μs |    14.1028 μs |
| Predecessor  | 100  |    405.117 μs |    410.2119 μs |    22.4851 μs |
| Rank         | 100  |    144.487 μs |    547.9261 μs |    30.0337 μs |
| **InsertAtHead** | **1000** |    **185.712 μs** |    **416.0343 μs** |    **22.8042 μs** |
| InsertAtTail | 1000 |    271.797 μs |    780.8676 μs |    42.8020 μs |
| Search       | 1000 | 23,282.012 μs | 88,807.5220 μs | 4,867.8399 μs |
| Max          | 1000 | 32,717.572 μs | 37,342.3019 μs | 2,046.8576 μs |
| Predecessor  | 1000 | 40,814.786 μs | 81,557.4463 μs | 4,470.4388 μs |
| Rank         | 1000 | 14,466.105 μs | 21,825.1924 μs | 1,196.3124 μs |
