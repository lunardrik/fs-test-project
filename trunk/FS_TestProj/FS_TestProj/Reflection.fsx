open Microsoft.FSharp.Reflection

let rec printTupleType (x: obj) = 
    if FSharpType.IsTuple (x.GetType()) then
        let vals = FSharpValue.GetTupleFields (x)
        printf "("
        vals 
        |> Seq.iteri
            (fun i v ->
                let t = v.GetType()
                if FSharpType.IsTuple t then
                    printTupleType (v)
                else
                    if i <> Seq.length vals - 1 then
                        printf "%s * " t.Name
                    else
                        printf "%s" t.Name)
        printf ")"
    else
        printf "not a tuple"

printTupleType ("Hello", 2, 5, 4.7, 10e+13, 0b111100, (1.7, 2, 6, 4))