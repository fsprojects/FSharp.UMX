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
    let f = UMX.tag<km>  10.0f
    let w = sprintf "%O %s %d %f" (UMX.untag x) (UMX.untag y) z f
    ()

[<Fact>]
let ``Simple unit of measure conversions with cast operator``() =
    let x : Guid<skuId> = % Guid.NewGuid()
    let y : string<skuId> = % (%x).ToString()
    let z : int<km> = % 42
    let uz : uint<km> = % 42u
    let uz32 : uint32<km> = % 42u
    let c : char<foo> = % 'c'
    let w : string<foo> = % sprintf "%O %s %d" %x %y %z
    let b : byte<foo> = % 1uy
    let sb : sbyte<foo> = % 1y
    let s : int16<foo> = % 1s
    let us : uint16<foo> = % 1us
    let l : int64<km> = % 42L
    let ul : uint64<km> = % 42UL
    let f : float32<foo> = % 10.0f
    let d : DateTime<foo> = % DateTime.Now
    let don : DateOnly<foo> = % DateOnly.FromDateTime(DateTime.Now)
    let ton : TimeOnly<foo> = % TimeOnly.FromDateTime(DateTime.Now)
    ()

[<Fact>]
let ``Simple unit of measure conversions with UMX.tag function``() =
    let x = UMX.tag<skuId> (Guid.NewGuid())
    let y = UMX.tag<skuId> ((%x).ToString())
    let z = UMX.tag<km> (42)
    let uz = UMX.tag<km> (42u)
    let c = UMX.tag<km> ('c')
    let w = UMX.tag<foo> (sprintf "%O %s %d" %x %y %z)
    let b = UMX.tag<foo> (1uy)
    let sb = UMX.tag<foo> (1y)
    let s = UMX.tag<foo> (1s)
    let us = UMX.tag<foo> (1us)
    let l = UMX.tag<foo> (1l)
    let ul = UMX.tag<foo> (1UL)
    let f = UMX.tag<foo> (10.0f)
    let d = UMX.tag<foo> DateTime.Now
    let don = UMX.tag<foo> (DateOnly.FromDateTime(DateTime.Now))
    let ton = UMX.tag<foo> (TimeOnly.FromDateTime(DateTime.Now))
    ()

[<Fact>]
let ``Record with units of measure``() =
    let record = { skuId = % "skuId" ; foo = % "foo" ; distance = % 42 }
    let x = sprintf "%s %s %d" %record.skuId %record.foo %record.distance
    ()
