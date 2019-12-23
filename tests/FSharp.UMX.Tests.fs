module FSharp.UMX.Tests

open System
open Xunit
open FSharp.UMX

[<Measure>] type skuId
[<Measure>] type km
[<Measure>] type foo

type Record =
    {
        skuId : string<skuId>
        foo : string<foo>
        distance : int<km>
    }

// Tests intentionally without assertions

[<Fact>]
let ``Simple unit of measure conversions``() =
    let x = Guid.NewGuid() |> UMX.tag<skuId>
    let y = (UMX.untag x).ToString("N") |> UMX.tag<skuId>
    let z = UMX.tag<km> 42
    let w = sprintf "%O %s %d" (UMX.untag x) (UMX.untag y) z
    ()

[<Fact>]
let ``Simple unit of measure conversions with cast operator``() =
    let x : Guid<skuId> = % Guid.NewGuid()
    let y : string<skuId> = % (%x).ToString()
    let z : int<km> = % 42
    let w : string<foo> = % sprintf "%O %s %d" %x %y %z
    let b : byte<foo> = % 1uy
    let s : int16<foo> = % 1s
    ()

[<Fact>]
let ``Simple unit of measure conversions with UMX.tag function``() =
    let x = UMX.tag<skuId> (Guid.NewGuid())              
    let y = UMX.tag<skuId> ((%x).ToString())             
    let z = UMX.tag<km> (42)                          
    let w = UMX.tag<foo> (sprintf "%O %s %d" %x %y %z) 
    let b = UMX.tag<foo> (1uy)                         
    let s = UMX.tag<foo> (1s)                         
    ()

[<Fact>]
let ``Record with units of measure``() =
    let record = { skuId = % "skuId" ; foo = % "foo" ; distance = % 42 }
    let x = sprintf "%s %s %d" %record.skuId %record.foo %record.distance
    ()
