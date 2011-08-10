module TestApp

open System
open System.Windows.Forms
open System.Drawing
open System.Threading
open System.IO

let rand = new Random()
let n, k = 128, 4;
let mutable sleepingTime = 300;

let mutable img:Image = new Bitmap(n*k, n*k) :> Image

let init = fun () ->
    Array2D.init n n (fun _ _ -> rand.Next 2 = 0) |> ref

let mutable a = init()

let count (a: _ [,]) i j =
    let m, n = a.GetLength 0, a.GetLength 1
    let mutable c = 0
    for x in -1 .. 1 do
        for y in -1 .. 1 do
            if (i + x) > 0 && (i + x) < n && (j + y) > 0 && (j + y) < m && a.[i + x, j + y] then 
                c <- c + 1
    if a.[i, j] then c - 1 else c


let rule (a: _ [,]) i j =
    match a.[i, j], count a i j with
    | true, (2 | 3) | false, 3 ->
        true
    | _ -> 
        false

let draw (g:Graphics) (pos:Point) = 
    g.DrawRectangle(Pens.Blue, pos.X*k, pos.Y*k, k, k)
    g.FillRectangle(Brushes.White, pos.X*k, pos.Y*k, k, k)

let Threaddo(frm:obj) =
    let form = frm :?> Form
    while true do
        let mutable c = 0
        let b = Array2D.create n n true
        img <- (new Bitmap(n*k, n*k)) :> Image
        let grh = Graphics.FromImage(img)
        for i = 0 to n - 1 do
            for j = 0 to n - 1 do
                b.[i,j] <- rule !a i j
                if b.[i, j] then 
                    c <- c + 1
                    draw grh (new Point(i, j))
            done
        done
        a := b
        form.Text <- Printf.sprintf "%i" c
        form.Invalidate()
        Thread.Sleep sleepingTime

let thread = new Thread(new ParameterizedThreadStart(Threaddo))

let mainForm() =
    let form = new Form()
    form.Width <- n*k + 100
    form.Height <- n*k + 100
    form.Paint.Add(fun e ->
            e.Graphics.DrawImage(img, 0, 0))
    let textBox = new TextBox()
    textBox.Location <- new Point(10, form.Height - 70) 
    textBox.Text <- sleepingTime |> string
    textBox.TextChanged.Add(fun e ->
                        let ok, value  = textBox.Text |> Int32.TryParse
                        if ok then
                            sleepingTime <- value
                        else MessageBox.Show("Please Enter Valid Value!") |> ignore)
    let btnReset = new Button()
    btnReset.Click.Add(fun e ->
                    a <- init())
    btnReset.Text <- "Reset"
    btnReset.Location <- new Point(textBox.Width + 10 + 20, form.Height - 70) 
    form.Controls.Add(textBox);
    form.Controls.Add(btnReset)
    thread.Start(form)

    form
    
[<STAThread>]
do Application.Run(mainForm())
thread.Abort() |> ignore