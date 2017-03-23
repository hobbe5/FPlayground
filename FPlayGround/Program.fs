open System

let area (coefficients:List<int>) (powers:List<int>) (x:double) =
    Seq.zip coefficients powers 
    |> Seq.map (fun (c,p) -> (pown x p) * Convert.ToDouble(c))
    |> Seq.sum

let volume (coefficients:List<int>) (powers:List<int>) (x:double) = 
    let a = area coefficients powers x
    Math.PI * a * a

let summation f (upperLimit:double) (lowerLimit:double) (coefficients:List<int>) (powers:List<int>) =
    let delta = 0.001
    [lowerLimit .. delta .. upperLimit] 
    |> Seq.map (fun x -> delta * (f coefficients powers x))
    |> Seq.sum

let splitLine = (fun (line : string) -> Seq.toList (line.Split ' '))

[<EntryPoint>]
let main argv =
    let alphas = Console.ReadLine() |> splitLine |> List.map Int32.Parse
    let betas = Console.ReadLine() |> splitLine |> List.map Int32.Parse
    let nums = Console.ReadLine() |> splitLine |> List.map Double.Parse
    printfn "Area: %.1f" (summation area nums.[1] nums.[0] alphas betas)
    printfn "Volume: %.1f" (summation volume nums.[1] nums.[0] alphas betas)
    Console.ReadLine() |> ignore
    0
