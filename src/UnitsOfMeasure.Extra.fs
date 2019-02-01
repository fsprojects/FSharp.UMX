namespace UnitsOfMeasure.Extra

open System

[<MeasureAnnotatedAbbreviation>] type bool<[<Measure>] 'm> = bool
[<MeasureAnnotatedAbbreviation>] type uint64<[<Measure>] 'm> = uint64
[<MeasureAnnotatedAbbreviation>] type Guid<[<Measure>] 'm> = Guid
[<MeasureAnnotatedAbbreviation>] type string<[<Measure>] 'm> = string
[<MeasureAnnotatedAbbreviation>] type TimeSpan<[<Measure>] 'm> = TimeSpan
[<MeasureAnnotatedAbbreviation>] type DateTime<[<Measure>] 'm> = DateTime
[<MeasureAnnotatedAbbreviation>] type DateTimeOffset<[<Measure>] 'm> = DateTimeOffset

type UnitOfMeasureTC =
    // Method signatures declare a type relationship between
    // units of measure of the same underlying type
    // NB underlying types in UoM arguments should always match
    static member IsUnitOfMeasure(_ : bool<'a>, _ : bool<'b>) = ()
    static member IsUnitOfMeasure(_ : int<'a>, _ : int<'b>) = ()
    static member IsUnitOfMeasure(_ : int64<'a>, _ : int64<'b>) = ()
    static member IsUnitOfMeasure(_ : uint64<'a>, _ : uint64<'b>) = ()
    static member IsUnitOfMeasure(_ : float<'a>, _ : float<'b>) = ()
    static member IsUnitOfMeasure(_ : decimal<'a>, _ : decimal<'b>) = ()
    static member IsUnitOfMeasure(_ : Guid<'a>, _ : Guid<'b>) = ()
    static member IsUnitOfMeasure(_ : string<'a>, _ : string<'b>) = ()
    static member IsUnitOfMeasure(_ : TimeSpan<'a>, _ : TimeSpan<'b>) = ()
    static member IsUnitOfMeasure(_ : DateTime<'a>, _ : DateTime<'b>) = ()
    static member IsUnitOfMeasure(_ : DateTimeOffset<'a>, _ : DateTimeOffset<'b>) = ()

#nowarn "42"

[<RequireQualifiedAccess>]
module UoC =
    let inline private _cast< ^TC, ^a, ^b when (^TC or ^a or ^b) : (static member IsUnitOfMeasure : ^a * ^b -> unit)> (t : ^a) =
    #if !FABLE_COMPILER
      (# "" t : ^b #)
    #else
      unbox< ^b > t
    #endif

    /// Generic unit of measure cast function
    let inline cast (x : ^a) : ^b = _cast<UnitOfMeasureTC,^a,^b> x

[<AutoOpen>]
module Operators =

    /// Generic unit of measure cast operator
    let inline (~%%) x = UoC.cast x
