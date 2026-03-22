let rec readDigits () =
    seq {
        let input = System.Console.ReadLine()

        match System.Int32.TryParse(input) with
        | (true, digit) when digit >= 0 && digit <= 9 ->
            yield digit
            yield! readDigits ()
        | _ -> ()
    }

[<EntryPoint>]
let main argv =
    printfn "Введите десятичные цифры (для завершения любой другой символ):"

    let originaldigits = readDigits ()

    let numberAsString =
        originaldigits
        |> Seq.map string
        |> String.concat ""

    printfn "Полученное число: %s" numberAsString
    
    0