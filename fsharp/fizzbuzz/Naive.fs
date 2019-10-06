module Naive
//In my opinion one of the most simple implementation for FizzBuzz kata.
//The weaknesses of the implementation :
// 1) some kind of duplication since the n%15 case is a combination of n%3 and n%5
// 2) respect of Open-Closed Principle. What if I'm asked to handle more rules based on other 
//    prime factors by example 3:fizz; 5:buzz; 7:baz; 11:qix. 
//    The patten matching with hardcoded rules is not the best option to handle all the combinations.

let fizzbuzz n =
    match n with
    |_ when n%15=0 -> "fizzbuzz"
    |_ when n%3=0 -> "fizz"
    |_ when n%5=0 -> "buzz"
    |_ -> n.ToString()