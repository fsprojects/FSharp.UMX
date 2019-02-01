module UnitsOfMeasure.Extra.Tests

open System
open Xunit
open UnitsOfMeasure.Extra

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
    let x = Guid.NewGuid() |> UoM.tag<skuId>
    let y = (UoM.untag x).ToString("N") |> UoM.tag<skuId>
    let z = UoM.tag<km> 42
    let w = sprintf "%O %s %d" (UoM.untag x) (UoM.untag y) z
    ()

[<Fact>]
let ``Simple unit of measure conversions with cast operator``() =
    let x : Guid<skuId> = % Guid.NewGuid()
    let y : string<skuId> = % (%x).ToString()
    let z : int<km> = % 42
    let w : string<foo> = % sprintf "%O %s %d" %x %y %z
    ()

[<Fact>]
let ``Record with units of measure``() =
    let record = { skuId = % "skuId" ; foo = % "foo" ; distance = % 42 }
    let x = sprintf "%s %s %d" %record.skuId %record.foo %record.distance
    ()
