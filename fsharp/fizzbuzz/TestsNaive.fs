module TestsNaive

open System
open Xunit
open Naive


let executeTest n expected =
    let result = fizzbuzz n
    Assert.Equal (expected,result)

[<Theory>]
[<InlineData(3,"fizz")>]
[<InlineData(6,"fizz")>]
[<InlineData(9,"fizz")>]
let ``When multiple of 3 should return fizz`` n expected =
    executeTest n expected

[<Theory>]
[<InlineData(5,"buzz")>]
[<InlineData(10,"buzz")>]
[<InlineData(20,"buzz")>]
let ``When multiple of 5 should return buzz`` n expected =
    executeTest n expected

[<Theory>]
[<InlineData(15,"fizzbuzz")>]
[<InlineData(30,"fizzbuzz")>]
[<InlineData(45,"fizzbuzz")>]
let ``When multiple of 3 and 5 should return fizzbuzz`` n expected =
    executeTest n expected

[<Theory>]
[<InlineData(1,"1")>]
[<InlineData(2,"2")>]
[<InlineData(8,"8")>]
let ``When 1 should return 1 as string`` n expected =
    executeTest n expected



