```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3007/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method      | Mean | Error | Ratio | RatioSD |
|------------ |-----:|------:|------:|--------:|
| ToListAsync |   NA |    NA |     ? |       ? |
| ToList      |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  BenchMarkService.ToListAsync: DefaultJob
  BenchMarkService.ToList: DefaultJob
