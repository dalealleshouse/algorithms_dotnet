```

BenchmarkDotNet v0.13.10, Pengwin WSL
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  Job-IMCEUH : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

IterationCount=3  

```
| Method      | ListType             | N     | Mean               | Error             | StdDev           |
|------------ |--------------------- |------ |-------------------:|------------------:|-----------------:|
| **Insert**      | **LinkedList**           | **100**   |         **2,499.9 ns** |         **298.99 ns** |         **16.39 ns** |
| Enumerate   | LinkedList           | 100   |           251.6 ns |          18.88 ns |          1.03 ns |
| Max         | LinkedList           | 100   |        29,375.6 ns |       5,362.62 ns |        293.94 ns |
| Predecessor | LinkedList           | 100   |        48,164.2 ns |       9,486.40 ns |        519.98 ns |
| Search      | LinkedList           | 100   |        42,619.9 ns |      17,269.11 ns |        946.58 ns |
| Delete      | LinkedList           | 100   |        59,761.3 ns |      10,232.02 ns |        560.85 ns |
| **Insert**      | **LinkedList**           | **1000**  |        **25,255.9 ns** |       **5,730.39 ns** |        **314.10 ns** |
| Enumerate   | LinkedList           | 1000  |         2,345.7 ns |         266.98 ns |         14.63 ns |
| Max         | LinkedList           | 1000  |     2,768,157.2 ns |     332,630.44 ns |     18,232.60 ns |
| Predecessor | LinkedList           | 1000  |     6,445,411.1 ns |     356,101.63 ns |     19,519.13 ns |
| Search      | LinkedList           | 1000  |     4,204,637.9 ns |   1,442,100.11 ns |     79,046.37 ns |
| Delete      | LinkedList           | 1000  |     6,382,513.2 ns |     533,709.45 ns |     29,254.42 ns |
| **Insert**      | **LinkedList**           | **10000** |       **278,885.8 ns** |      **57,249.27 ns** |      **3,138.03 ns** |
| Enumerate   | LinkedList           | 10000 |        24,879.4 ns |       2,617.28 ns |        143.46 ns |
| Max         | LinkedList           | 10000 |   275,838,643.3 ns |  39,513,858.61 ns |  2,165,887.92 ns |
| Predecessor | LinkedList           | 10000 |   678,095,791.0 ns |  73,415,061.65 ns |  4,024,127.26 ns |
| Search      | LinkedList           | 10000 |   411,631,192.7 ns |  42,344,858.12 ns |  2,321,064.56 ns |
| Delete      | LinkedList           | 10000 |   646,550,593.3 ns | 331,533,966.77 ns | 18,172,495.43 ns |
| **Insert**      | **SortedArray**          | **100**   |        **42,466.9 ns** |       **6,896.54 ns** |        **378.02 ns** |
| Enumerate   | SortedArray          | 100   |           194.5 ns |          55.93 ns |          3.07 ns |
| Max         | SortedArray          | 100   |         1,339.4 ns |         148.96 ns |          8.16 ns |
| Predecessor | SortedArray          | 100   |         6,154.9 ns |       1,275.77 ns |         69.93 ns |
| Search      | SortedArray          | 100   |         2,622.5 ns |         244.93 ns |         13.43 ns |
| Delete      | SortedArray          | 100   |         5,316.8 ns |         685.75 ns |         37.59 ns |
| **Insert**      | **SortedArray**          | **1000**  |     **2,963,570.7 ns** |     **463,221.73 ns** |     **25,390.75 ns** |
| Enumerate   | SortedArray          | 1000  |         2,616.1 ns |       5,943.32 ns |        325.77 ns |
| Max         | SortedArray          | 1000  |        19,350.8 ns |      13,409.39 ns |        735.01 ns |
| Predecessor | SortedArray          | 1000  |       136,769.2 ns |     125,737.57 ns |      6,892.10 ns |
| Search      | SortedArray          | 1000  |        62,040.9 ns |      41,472.34 ns |      2,273.24 ns |
| Delete      | SortedArray          | 1000  |       130,077.7 ns |     131,534.66 ns |      7,209.86 ns |
| **Insert**      | **SortedArray**          | **10000** |   **294,101,933.7 ns** |  **97,010,955.46 ns** |  **5,317,497.82 ns** |
| Enumerate   | SortedArray          | 10000 |        23,228.4 ns |      32,789.41 ns |      1,797.30 ns |
| Max         | SortedArray          | 10000 |       143,676.9 ns |      27,214.06 ns |      1,491.69 ns |
| Predecessor | SortedArray          | 10000 |     1,208,013.9 ns |     490,577.67 ns |     26,890.22 ns |
| Search      | SortedArray          | 10000 |       410,758.5 ns |      89,120.76 ns |      4,885.01 ns |
| Delete      | SortedArray          | 10000 |     1,129,628.2 ns |     312,991.22 ns |     17,156.10 ns |
| **Insert**      | **RandomArray**          | **100**   |         **3,354.4 ns** |       **1,924.27 ns** |        **105.48 ns** |
| Enumerate   | RandomArray          | 100   |           196.1 ns |          53.50 ns |          2.93 ns |
| Max         | RandomArray          | 100   |       237,188.8 ns |      50,712.15 ns |      2,779.70 ns |
| Predecessor | RandomArray          | 100   |       290,040.2 ns |      13,227.20 ns |        725.03 ns |
| Search      | RandomArray          | 100   |       113,913.5 ns |      41,664.31 ns |      2,283.76 ns |
| Delete      | RandomArray          | 100   |       140,892.3 ns |      22,531.48 ns |      1,235.03 ns |
| **Insert**      | **RandomArray**          | **1000**  |       **135,497.1 ns** |      **23,146.90 ns** |      **1,268.76 ns** |
| Enumerate   | RandomArray          | 1000  |         1,702.0 ns |          62.68 ns |          3.44 ns |
| Max         | RandomArray          | 1000  |    22,003,807.9 ns |   3,423,460.39 ns |    187,651.42 ns |
| Predecessor | RandomArray          | 1000  |    27,278,611.6 ns |     891,820.77 ns |     48,883.71 ns |
| Search      | RandomArray          | 1000  |    10,173,756.8 ns |   3,547,906.80 ns |    194,472.74 ns |
| Delete      | RandomArray          | 1000  |    14,695,616.7 ns |  10,522,017.63 ns |    576,747.29 ns |
| **Insert**      | **RandomArray**          | **10000** |    **10,695,229.0 ns** |   **1,066,795.48 ns** |     **58,474.66 ns** |
| Enumerate   | RandomArray          | 10000 |        16,927.2 ns |       2,246.23 ns |        123.12 ns |
| Max         | RandomArray          | 10000 | 2,260,070,212.3 ns | 665,044,764.02 ns | 36,453,347.61 ns |
| Predecessor | RandomArray          | 10000 | 2,737,446,192.3 ns | 497,870,517.28 ns | 27,289,963.04 ns |
| Search      | RandomArray          | 10000 | 1,018,558,428.0 ns | 557,895,595.89 ns | 30,580,140.15 ns |
| Delete      | RandomArray          | 10000 | 1,387,309,174.3 ns | 146,320,153.73 ns |  8,020,301.36 ns |
| **Insert**      | **UnbalancedBinaryTree** | **100**   |         **7,195.0 ns** |       **2,584.95 ns** |        **141.69 ns** |
| Enumerate   | UnbalancedBinaryTree | 100   |           499.8 ns |       2,504.59 ns |        137.28 ns |
| Max         | UnbalancedBinaryTree | 100   |           781.0 ns |         140.31 ns |          7.69 ns |
| Predecessor | UnbalancedBinaryTree | 100   |         5,492.0 ns |         689.44 ns |         37.79 ns |
| Search      | UnbalancedBinaryTree | 100   |         2,024.1 ns |         480.17 ns |         26.32 ns |
| Delete      | UnbalancedBinaryTree | 100   |         6,191.4 ns |       1,500.12 ns |         82.23 ns |
| **Insert**      | **UnbalancedBinaryTree** | **1000**  |        **97,467.6 ns** |      **19,686.20 ns** |      **1,079.07 ns** |
| Enumerate   | UnbalancedBinaryTree | 1000  |         3,651.1 ns |         365.37 ns |         20.03 ns |
| Max         | UnbalancedBinaryTree | 1000  |         8,977.4 ns |         929.21 ns |         50.93 ns |
| Predecessor | UnbalancedBinaryTree | 1000  |        85,491.8 ns |         946.78 ns |         51.90 ns |
| Search      | UnbalancedBinaryTree | 1000  |        25,515.1 ns |       3,053.77 ns |        167.39 ns |
| Delete      | UnbalancedBinaryTree | 1000  |       103,352.3 ns |      17,940.36 ns |        983.37 ns |
| **Insert**      | **UnbalancedBinaryTree** | **10000** |     **1,450,610.3 ns** |     **161,379.24 ns** |      **8,845.74 ns** |
| Enumerate   | UnbalancedBinaryTree | 10000 |       125,572.1 ns |      18,270.13 ns |      1,001.45 ns |
| Max         | UnbalancedBinaryTree | 10000 |        84,361.3 ns |      31,899.10 ns |      1,748.50 ns |
| Predecessor | UnbalancedBinaryTree | 10000 |     1,453,919.8 ns |      98,393.99 ns |      5,393.31 ns |
| Search      | UnbalancedBinaryTree | 10000 |       458,725.0 ns |     149,322.15 ns |      8,184.85 ns |
| Delete      | UnbalancedBinaryTree | 10000 |     1,845,202.6 ns |     544,666.21 ns |     29,854.99 ns |
| **Insert**      | **RedBlackTree**         | **100**   |         **8,833.5 ns** |       **1,180.40 ns** |         **64.70 ns** |
| Enumerate   | RedBlackTree         | 100   |           382.9 ns |          70.57 ns |          3.87 ns |
| Max         | RedBlackTree         | 100   |           782.3 ns |          65.88 ns |          3.61 ns |
| Predecessor | RedBlackTree         | 100   |         5,388.6 ns |         559.69 ns |         30.68 ns |
| Search      | RedBlackTree         | 100   |         3,183.9 ns |         528.22 ns |         28.95 ns |
| Delete      | RedBlackTree         | 100   |         5,837.2 ns |         483.17 ns |         26.48 ns |
| **Insert**      | **RedBlackTree**         | **1000**  |       **113,312.6 ns** |       **5,015.07 ns** |        **274.89 ns** |
| Enumerate   | RedBlackTree         | 1000  |         3,617.9 ns |         301.36 ns |         16.52 ns |
| Max         | RedBlackTree         | 1000  |        11,368.6 ns |          56.35 ns |          3.09 ns |
| Predecessor | RedBlackTree         | 1000  |        81,179.0 ns |      19,301.01 ns |      1,057.95 ns |
| Search      | RedBlackTree         | 1000  |        34,346.0 ns |       8,121.90 ns |        445.19 ns |
| Delete      | RedBlackTree         | 1000  |        94,713.7 ns |       2,603.49 ns |        142.71 ns |
| **Insert**      | **RedBlackTree**         | **10000** |     **1,634,328.9 ns** |     **947,330.72 ns** |     **51,926.39 ns** |
| Enumerate   | RedBlackTree         | 10000 |        94,366.3 ns |       8,433.21 ns |        462.25 ns |
| Max         | RedBlackTree         | 10000 |       172,969.8 ns |      15,618.49 ns |        856.10 ns |
| Predecessor | RedBlackTree         | 10000 |     1,339,888.5 ns |     254,232.94 ns |     13,935.37 ns |
| Search      | RedBlackTree         | 10000 |       557,590.3 ns |      39,863.55 ns |      2,185.06 ns |
| Delete      | RedBlackTree         | 10000 |     1,465,076.3 ns |     453,964.66 ns |     24,883.33 ns |
