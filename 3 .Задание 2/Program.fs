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

    let digitsToNumber =
        originaldigits
        |> Seq.fold (fun acc digit -> acc * 10 + digit) 0

    printfn "Полученное число: %d" digitsToNumber

    0