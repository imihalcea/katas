module TestsRuleBased

open System
open Xunit
open RuleBased

let fizzbuzz = fizzbuzzWithRules [(3,"fizz");(5,"buzz");(7,"baz")]

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
[<InlineData(7,"baz")>]
[<InlineData(14,"baz")>]
[<InlineData(28,"baz")>]
let ``When multiple of 7 should return baz`` n expected =
    executeTest n expected

[<Theory>]
[<InlineData(15,"fizzbuzz")>]
[<InlineData(30,"fizzbuzz")>]
[<InlineData(45,"fizzbuzz")>]
let ``When multiple of 3 and 5 should return fizzbuzz`` n expected =
    executeTest n expected

[<Theory>]
[<InlineData(21,"fizzbaz")>]
[<InlineData(42,"fizzbaz")>]
[<InlineData(63,"fizzbaz")>]
let ``When multiple of 3 and 7 should return fizzbaz`` n expected =
    executeTest n expected


[<Theory>]
[<InlineData(35,"buzzbaz")>]
[<InlineData(70,"buzzbaz")>]
[<InlineData(140,"buzzbaz")>]
let ``When multiple of 5 and 7 should return fizzbaz`` n expected =
    executeTest n expected

[<Fact>]
let ``When multiple of 3 of 5 and 7 should return fizzbuzzbaz`` () =
    let result = fizzbuzz 105
    Assert.Equal ("fizzbuzzbaz",result)

[<Theory>]
[<InlineData(1,"1")>]
[<InlineData(2,"2")>]
[<InlineData(8,"8")>]
let ``When not multiple of 3,5 or 7 should return the given number as string`` n expected =
    executeTest n expected



