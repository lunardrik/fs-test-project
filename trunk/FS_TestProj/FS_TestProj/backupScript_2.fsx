//type myPoint = { Top : int;
//                 Left : int }
//    with
//        member x.Swap() =
//            { Top = x.Left;
//              Left = x.Top  }
//        override x.ToString() =
//            Printf.sprintf "The rectangle with Top = %i and Left = %i" x.Top x.Left
//
//let a:myPoint = { Top = 3; Left = 7 }
//
//printf "%A %s\n" (a.Swap()) (a.ToString())

//-------------------------------INTERFACE AND CLASSES----------------------
//type IUser = 
//    abstract Authenticate: evidence: string -> bool
//    abstract LoginMessage: unit -> unit
//
//type myLogin(username, passwordHash) = 
//    interface IUser with
//        member x.Authenticate(password) =
//            let hashResult = hash (password, "sha1")
//            passwordHash = hashResult
//        member x.LoginMessage() = 
//            printf "Hello Mr/Mrs. %s\n" username
//    override x.ToString() = 
//        Printf.sprintf "%i" passwordHash
//    static member CreateUser(username, password) =
//        let hashResult = hash (password, "sha1")
//        new myLogin(username, hashResult)
//
//
//let user = myLogin.CreateUser("Myth", "dumbass") :> IUser
//
//if (user.Authenticate("dumbass")) then
//    user.LoginMessage()
//if (user.Authenticate("baka") <> true) then
//    printf "%s" (user.ToString())

//-----------------------------INHERITANCE AND CLASSES----------------------
//type Base() = 
//    member x.GetBaseState() = 0
//    abstract GetOtherBaseState: unit -> int
//    default x.GetOtherBaseState() = 10
//    abstract GetOtherBaseStateV2: unit -> int
//    default x.GetOtherBaseStateV2() = 11
//
//type Sub() = 
//    inherit Base()
//        override x.GetOtherBaseStateV2() = 12 // Override
//    member x.GetBaseState() = 1 // Overshadow
//    member x.GetSubState() = 0
//
//let sub = new Sub()
//
//printf "Base(OverShadowed): %i\nSub: %i\nOtherBase(Abstract Default): %i\nOtherBaseV2(Abstract Override): %i" 
//    (sub.GetBaseState()) 
//    (sub.GetSubState()) 
//    (sub.GetOtherBaseState()) 
//    (sub.GetOtherBaseStateV2())

//-----------------------------INHERITANCE AND PROPERTIY--------------------
//type IAbstractProp =
//    abstract myProp: int
//        with get, set
//
//type myClass(?def:int) =
//    let mutable stat = 
//        match def with
//        | Some x -> x
//        | None -> 0
//    
//    interface IAbstractProp with
//        member x.myProp 
//            with get() = stat
//            and set(y) = stat <- y
//
//let myObj = new myClass() :> IAbstractProp
//let myObjWithParam = new myClass(12) :> IAbstractProp
//
//printf "myObject\n\tget(): %i" myObj.myProp
//myObj.myProp <- 12
//printf "\n\tset(12): %i" myObj.myProp
//
//printf "\nmyObjectWithParam\n\tget(): %i" myObjWithParam.myProp
//myObjWithParam.myProp <- 13
//printf "\n\tset(13): %i" myObjWithParam.myProp


//-------------------------------STATIC METHODS AND OPERTATORS--------------
//type myInt(state:int) = class
//    member x.State = state
//    static member (+) (x:myInt, y:myInt) = new myInt(x.State + y.State)
//    override x.ToString() = Printf.sprintf "%i" x.State
//end
//
//let x, y = new myInt(1), new myInt(1)
//
//printf "%A" (x + y)

//--------------------------------TYPE TEST---------------------------------
//let myObj = ("this is a text" :> obj)
//
//let result x = 
//    match (x :> obj) with
//    | :? string -> "This is a string"
//    | :? int -> "This is an int"
//    | :? double -> "This is a double"
//    | :? bool -> "This is a bool"
//    | _ -> "This is not anything that we can know!"
//
//printf "%s" (result myObj)



//type flag = 
//| A = 0b00000001
//| B = 0b00000010
//| C = 0b00000100
//| D = 0b00001000
//| E = 0b00010000
//| F = 0b00100000
//| G = 0b01000000
//| H = 0b10000000
//
//let a:flag = flag.A ^^^ flag.B
//
//printf "%A %A %A" ((flag.A &&& a) |> int) (flag.B &&& a) (flag.C &&& a)

