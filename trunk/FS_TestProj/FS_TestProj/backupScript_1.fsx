
// Learn more about F# at http://fsharp.net


//printf "Hello World";;
//
//let xyz = seq { for x in 1 .. 10 -> x, x * x}
//
//let bytearr = "0123456789ABCDEF"B;;
//
//let myAdd = fun x y -> x + y;
//
//let halfWay a b =
//    let dif = b - a
//    let mid = dif / 2
//    mid + a
//
//let main() =
//    //printf "%A" bytearr;;
//    //printf "%A" xyz;;
//    //let result = myAdd 12 15;;
//    //printf "%i" result;;
//    printf "\n%i\n" (halfWay 5 11);;
//    printf "\n%i\n" (halfWay 11 5);;
//
//main();;

//let calculatePrefixFunction prefix = 
//    let prefix' = Printf.sprintf "[%s]: " prefix
//    let prefixFunction appendee = 
//        Printf.sprintf "%s%s\n" prefix' appendee
//    prefixFunction
//
//let rec fib n =
//    match n with
//    | 1 -> 1
//    | 2 -> 1
//    | n -> fib(n - 1) + fib(n - 2)
//
//let add = (+)
//
////let (+) a b = a - b
//
//
//let findRoot (a:float) (b:float) (c:float) = 
//    match a, b, c with
//    | 0.0, 0.0, _ -> "The equation has no root"
//    | _, 0.0, _ -> 
//        match a with
//        | a when a < 0.0 -> ((-c/a) |> System.Math.Sqrt) |> string
//        | _ -> "The equation has no root"
//    | 0.0, _, _ -> (-c/b) |> string
//    | _, _, _ -> 
//        let delta = b*b - 4.0*a*c
//        match delta with
//        | delta when delta < 0.0 -> "The equation has no root"
//        | 0.0 -> Printf.sprintf "The equation has 1 root x = %.2f" (-b / (2.0*a))
//        | _ -> Printf.sprintf "The equation has 2 root x1 = %.2f, x2 = %.2f" ((-b - (delta |> System.Math.Sqrt)) / (2.0*a)) ((-b + (delta |> System.Math.Sqrt)) / (2.0*a))
//
//
//let prefixer = calculatePrefixFunction "DEBUG"
//
//let rec concatList =
//    function head :: tail -> head + concatList tail
//            | [] -> 0
//
//printf "%i" (concatList [1; 2; 3])

//let sub a b = a - b
//
//let rec findSq l = 
//    match l with
//    | [x; y; z] -> 
//        printf "last three items %i %i %i \n" x y z
//    | 1 :: 2 :: 3:: tail -> 
//        printf "found [1 2 3] in list\n"
//        findSq tail
//    | head :: tail -> findSq tail
//    | [] -> ()
//
//let rec sumOfList l =
//    match l with
//    | head :: tail -> (head + (sumOfList tail))
//    | [] -> 0.0
//
//let rec toFloatList sl =
//    match sl with
//    | h :: t -> (h |> float) :: toFloatList t
//    | [] -> []
//
//let rec addOneAll l = 
//    match l with
//    | h :: r -> h + 1.0 :: addOneAll r
//    | [] -> []
//
//
//let sampleList = [1; 2; 3; 4; 5; 6; 7; 8; 9; 8; 7; 6; 5; 4; 3; 2; 1]
//
//let partial = sub 5
//
//let rec map func list =
//    match list with
//    | head :: rest ->
//        func head :: map func rest
//    | [] -> []
//
////let sequ n = seq { for x in 1 .. n -> x, x * x}
//
//let sequ n = seq { for x in 1 .. n do 
//                        if x % 2 = 0 then yield x }

//printf "%s" (prefixer "My Message")
//printf "%s" (prefixer ((fib 3).ToString()))
//printf "%i\n" (add 1 1)
//printf "%i\n" (add 6 7 |> add 4 |> add 5)
//printf "%s\n" (findRoot -10.0 0.0 2.0)
//printf "%i\n" (partial 4)
//printfn "%A" (sequ 10)
//findSq sampleList

//printf "%f\n" (sumOfList (toFloatList sampleList))
//printf "%A" (toFloatList sampleList)
//printf "%A" (addOneAll (toFloatList sampleList))
//printf "%A" (map ((+) 1) [1; 2; 3])

//type 'a Binarytree =
//| Binarynode of 'a Binarytree * 'a * 'a Binarytree
//| Binaryvalue of 'a
//
//let rec printBintree tree = 
//    match tree with
//    | Binarynode(l, x, r) ->
//        printBintree l
//        printf "%A, " x
//        printBintree r
//    | Binaryvalue x -> printf "%A, " x
//
//let tree =
//    Binarynode(
//        Binarynode(
//            Binarynode(Binaryvalue 6, 7, Binaryvalue 8), 
//            2, 
//            Binarynode(Binaryvalue 4, 3, Binaryvalue 5)
//         ), 
//         1, 
//         Binarynode(Binaryvalue 9, 10, Binaryvalue 11))
//
//printBintree tree


//let fibs = 
//    Seq.unfold
//        (fun (n0, n1) ->
//        Some(n0, (n1, n0 + n1)))
//        (1I,1I)
//
//let fib = fun (n0, n1) ->
//    Some(n0, (n1, n0 + n1))
//
//printf "%A" (fib (1I, 1I))

//[<Measure>]type m
//[<Measure>]type cm
//
//let length1 = 1.0<m>
//let length2 = 20.0<cm>
//
//let ratio = 1.0<m> / 100.0<cm>
//
//let length = length1*(1.0/ratio) + length2
//
//printf "%A\n" length
//
//let arr = [| "banana"; "orage"; "apple"|]
//
//match arr with
//    |[| _; x; _|] -> 
//        printf "%s\n" x
//        printf "%s\n" arr.[1]
//    |_ -> printf "%A" arr
//
////-----------For sample::Like Pascal for stlye
//for x = 1 to 10 do
//    printf "%i\n" x
////-----------For sample::Like F# style + Pascal style with in
//for x in 1 .. 10 do
//    printf "%i\n" x
////-----------For sample::Like foreach style
//for x in arr do
//    printf "%s\n" x

////============================================================================================
////-----------Open namespace sample--------------------
//open System.IO
//
//let filelist = [@"D:\file1.txt"; "file2.txt"; "file3.txt"]
////-----------Using static methods sample--------------
//let resultset = List.map File.Exists filelist
//
//printf "%A" resultset
//
//type fileandcontents = {path : string; contents : string[]}
//let writelist:list<fileandcontents> = [ {path = @"D:\file1.txt"; contents = [|"who are you?"|]};
//                  { path = @"D:\file2.txt"; contents = [|"I am FSharp\n"; "Testing writing!"|]};
//                  { path = @"D:\Temp\Fs.txt"; contents = [||]}]
//
////File.WriteAllLines (@"D:\baka.txt",["baka"])
////List.iter File.WriteAllLines writelist
////---------------Error???? WHY?------------------------
//
//open System.IO
//// list of files names and desired contents
//let files2 = [  "test1.bin", [| 0uy |];
//                "test2.bin", [| 1uy |];
//                "test3.bin", [| 1uy; 2uy |]]
//// iterator over the list of files creating each one
//List.iter File.WriteAllBytes files2

//open System
//// how to wrap a method that take a delegate with an F# function
//let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))
//// define an array literal
//let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat" |]
//// print index of the first word ending in 'at'
//printfn "First word ending in 'at' in the array: %i" (rhyme |> findIndex (fun w -> w.Contains("a")))


//open System.Windows.Forms
//open System.Timers
//
//let timer =
//    let temp = new Timer(Interval = 3000.0)
//    let messageNo = ref 0
//
//    let messages = ["bet"; "this"; "gets"; "annoying"; "very"; "quickly"]
//
//    temp.Elapsed.Add( fun _ -> 
//                        MessageBox.Show(List.nth messages !messageNo) |> ignore
//                        messageNo := (!messageNo + 1) % (List.length messages))
//
//    temp
//
//
//timer.Enabled <- true
//timer.Start |> ignore
//
//printf "Press enter to stop"
//System.Console.ReadLine |> ignore
//
//timer.Enabled <- false

//open System
//open System.Windows.Forms
//// define a form
//let form =
//    // the temporary form defintion
//    let temp = new Form(Text = "Events example")
//    // define an event handler
//    let stuff _ _ = MessageBox.Show("This is \"Doing Stuff\"") |> ignore
//    let stuffHandler = new EventHandler(stuff)
//    // define a button and the event handler
//    let event = new Button(Text = "Do Stuff", Left = 8, Top = 40, Width = 80)
//    event.Click.AddHandler(stuffHandler)
//    // label to show the event status
//    let label = new Label(Top = 8, Left = 96)
//    // bool to hold the event status and function
//    // to print the event status to the label
//    let eventAdded = ref true
//    let setText b = label.Text <- (Printf.sprintf "Event is on: %b" !b)
//    setText eventAdded
//    // define a second button and it's click event handler
//    let toggle = new Button(Text = "Toggle Event",
//    Left = 8, Top = 8, Width = 80)
//    toggle.Click.Add(fun _ ->
//    if !eventAdded then
//    event.Click.RemoveHandler(stuffHandler)
//    else
//    event.Click.AddHandler(stuffHandler)
//    eventAdded := not !eventAdded
//    setText eventAdded)
//    // add the controls to the form
//    let dc c = (c :> Control)
//    temp.Controls.AddRange([| dc toggle; dc event; dc label; |])
//
//    // return the form to the top level
//    temp
//
//do Application.Run form

// grab a list of all methods in memory
//let methods = System.AppDomain.CurrentDomain.GetAssemblies()
//            |> List.ofArray
//            |> List.map ( fun assm -> assm.GetTypes() )
//            |> Array.concat
//            |> List.ofArray
//            |> List.map ( fun t -> t.GetMethods() )
//            |> Array.concat
//// print the list
//printfn "%A" methods

//===============================================OOP========================================
//open System.Drawing
//
//type Shape = 
//            {Reposition: Point -> unit;
//             Draw: unit -> unit}
//
//let makeShape initPos draw =
//    let currPos = ref initPos
//    { Reposition =
//        (fun newPos -> currPos := newPos);
//      Draw =
//        (fun () -> draw !currPos); }
//
//let draw shape (pos: Point) =
//    printf "%s, with x = %i and y = %i" shape pos.X pos.Y
//
//let circle initPos = 
//    makeShape initPos (draw "Circle")
//
//let square initPos =
//    makeShape initPos (draw "Square")
//
//let shapes = 
//    [ circle (new Point(10, 10));
//      square (new Point(30, 30)) ]
//
//let drawShapes() = 
//    shapes |> List.iter (fun s -> s.Draw())
//
//let main() = 
//    drawShapes()
//    shapes |> List.iter (fun s -> s.Reposition(new Point(40, 40)))
//    drawShapes()
//
//do main()

//open System
//open System.Drawing
//open System.Windows.Forms
//
//type Shape = 
//    { Reposition : Point ->unit;
//      Draw : Graphics -> unit }
//
//let movingShape initPos draw =
//    let currPos = ref initPos
//    { Reposition = (fun newPos -> currPos := newPos);
//      Draw = (fun g -> draw !currPos g); }
//
//let movingCircle initPos diam = 
//    movingShape initPos (fun pos g ->
//                            g.DrawEllipse(Pens.Blue, pos.X, pos.Y, diam, diam))
//
//let movingSquare initPos size =
//    movingShape initPos (fun pos g ->
//                            g.DrawRectangle(Pens.Blue, pos.X, pos.Y, size, size))
//
//
//let shapes = 
//      [ movingCircle (new Point(10, 10)) 10;
//        movingSquare (new Point(50, 50)) 20;
//        movingCircle (new Point(80, 80)) 30;
//        movingSquare (new Point(20, 10)) 10; ]
//
//let mainForm() =
//    let form = new Form()
//    let rand = new Random()
//
//    form.Paint.Add(fun e ->
//                    shapes |> List.iter (fun s -> s.Draw e.Graphics))
//
//    form.Click.Add(fun e ->
//                    shapes |> List.iter (fun s ->
//                                            s.Reposition(new Point(rand.Next(form.Width), (rand.Next(form.Height))))
//                                            form.Invalidate()))
//    form
//
//[<STAThread>]
//do Application.Run(mainForm())
