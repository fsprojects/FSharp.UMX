# FSharp.UMX [![Build & Tests](https://github.com/fsprojects/FSharp.UMX/actions/workflows/build.yml/badge.svg)](https://github.com/fsprojects/FSharp.UMX/actions/workflows/build.yml) [![NuGet](https://img.shields.io/nuget/vpre/FSharp.UMX.svg)](https://www.nuget.org/packages/FSharp.UMX/) ![code size](https://img.shields.io/github/languages/code-size/fsprojects/FSharp.UMX.svg) [![license](https://img.shields.io/github/license/fsprojects/FSharp.UMX.svg)](LICENSE) 

F# Units of Measure for primitive non-numeric types by Eirik Tsarpalis. Compatible with Fable.

## Installing

Add the `FSharp.UMX` package from Nuget or just copy the `src/FSharp.UMX.fs` file.

## Publishing to Nuget

Run `npm i && npm run build publish`.

## Usage

```fsharp
open FSharp.UMX

[<Measure>] type customerId
[<Measure>] type orderId
[<Measure>] type kg

type Order =
    {
        id : string<orderId>
        customer : string<customerId>
        quantity : int<kg>
    }

let order =
    {
        id = % "orderId"
        customer = % "customerId"
        quantity = % 42
    }

let printOrder (order : Order) =
    printfn "orderId=%s customerId=%s quantity=%d" %order.id %order.customer %order.quantity

let lookupById (orders : Order list) (id : string<orderId>) = orders |> List.tryFind (fun o -> o.id = id)

lookupById [] order.id // compiles
lookupById [] order.customer // compiler error
// stdin(94,15): error FS0001: Type mismatch. Expecting a
//     'string<orderId>'
// but given a
//     'string<customerId>'
// The unit of measure 'orderId' does not match the unit of measure 'customerId'
```

[Example in Fable REPL](https://fable.io/repl/#?code=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&html=DwQgJg9gxgLgngBwKYAIAWMC2AbAfAKGAxwOAHpi98g&css=Q)
