#load "node_modules/fable-publish-utils/PublishUtils.fs"
open PublishUtils

run "dotnet test"

match args with
| IgnoreCase "publish"::_ ->
    pushNuget "src/FSharp.UMX.fsproj"
| _ -> ()
