# Eager vs lazy evaluation

The two approaches differ in terms of performance and usage, focusing on the concepts of lazy and eager evaluation:

## Lazy Evaluation (FibLazy)

**Execution Model**: Each Fibonacci number is generated only when requested, using the yield return statement.

**Memory Efficiency**: Since it doesn’t generate all Fibonacci numbers at once, it can work with lower memory usage. Only one Fibonacci number needs to be held in memory at a time during iteration.

**Speed**: Lazy evaluation can be faster initially if you only need a few elements, as it avoids the overhead of creating and filling a list. However, if you need to iterate over all elements (or many elements repeatedly), the performance can become similar to eager evaluation since it generates each number on demand.

**Use Cases**: Ideal for cases where you may not need all the Fibonacci numbers at once or want to potentially deal with a very large (or even infinite) series. Examples include streaming data, handling large datasets, or scenarios where you may stop early.

## Eager Evaluation (FibEager)

Execution Model: All x Fibonacci numbers are calculated immediately, stored in a list, and returned once fully generated.

**Memory Usage**: Requires more memory than lazy evaluation, especially if x is large, since all generated numbers are stored in the list.

**Speed**: If you need all x Fibonacci numbers, eager evaluation can be faster in the sense that all numbers are generated and stored in memory, making subsequent access to any element O(1). However, the initial computation takes more time compared to lazy evaluation if you need only a few elements.

**Use Cases**: Suitable when you know you need exactly x numbers and will access them multiple times. It's efficient for cases where random access to specific elements is necessary, as lists allow for O(1) access.

## Summary

Use FibLazy for scenarios where memory efficiency is important and not all numbers are necessarily needed, or for infinite sequences.
Use FibEager when you need a fixed number of elements upfront and might want to access any of them multiple times.

## Benchmark data

BenchmarkDotNet v0.14.0
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.8 (8.0.824.36612), Arm64 RyuJIT AdvSIMD

| Method     | N        | Mean             | Error          | StdDev         |
|----------- |--------- |-----------------:|---------------:|---------------:|
| BenchLazy  | 10       |         10.40 ns |       0.190 ns |       0.178 ns |
| BenchEager | 10       |         46.24 ns |       0.151 ns |       0.142 ns |
| BenchLazy  | 10000    |         11.19 ns |       0.043 ns |       0.039 ns |
| BenchEager | 10000    |     11,296.02 ns |      42.638 ns |      39.884 ns |
| BenchLazy  | 10000000 |         10.14 ns |       0.032 ns |       0.030 ns |
| BenchEager | 10000000 | 19,299,251.56 ns | 268,365.467 ns | 251,029.224 ns |
