let rec readNumbers () =
    seq {
        let input = System.Console.ReadLine()

        match System.Int32.TryParse(input) with
        | (true, number) when number >= 1 && number <= 9 ->
            yield number
            yield! readNumbers ()
        | _ -> ()
    }

let toRoman number =
    match number with
    | 1 -> "I"
    | 2 -> "II"
    | 3 -> "III"
    | 4 -> "IV"
    | 5 -> "V"
    | 6 -> "VI"
    | 7 -> "VII"
    | 8 -> "VIII"
    | 9 -> "IX"
    | _ -> ""

[<EntryPoint>]
let main argv =
    printfn "Введите числа от 1 до 9 (для завершения введите любой другой символ):"

    let numbers = readNumbers ()

    let romanNumbers =
        numbers
        |> Seq.map toRoman

    printfn "Результат:"
    romanNumbers |> Seq.iter (printfn "%s")
    
    0