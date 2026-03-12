open System
open System.IO

[<EntryPoint>]
let main argv =
    printfn "Введите путь к каталогу:"

    let path = Console.ReadLine()

    if not (Directory.Exists(path)) then
        printfn "Каталог не существует."
    else
        let files =
            Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
            |> Seq.map Path.GetExtension

        let mostOften =
            files
            |> Seq.groupBy id
            |> Seq.map (fun (ext, group) -> ext, Seq.length group)
            |> Seq.maxBy snd

        printfn "Наиболее часто встречающееся расширение: %s" (fst mostOften)
        printfn "Количество файлов: %d" (snd mostOften)

    0
