namespace Solids.Logics
open System.Net
open System
open System.IO
open Microsoft.FSharp.Control.CommonExtensions
open NUnit.Framework
open FsUnit

module Objects =
    /// Global variables to catch data
    let mutable ExistIntersection = false
    let mutable ResultText = ""
    let mutable InterWidth = 0.0
    let mutable InterLength = 0.0
    let mutable InterHeight = 0.0
    let mutable InterPointX = 0.0
    let mutable InterPointY = 0.0
    let mutable InterPointZ = 0.0

    [<AbstractClass>]
    /// Base class for Rectangular Solid Object 
    type Solids() =        
        abstract member Name : string with get
        abstract member Width : float with get
        abstract member Length : float with get
        abstract member Height : float with get
        abstract member X : float with get
        abstract member Y : float with get
        abstract member Z : float with get
        
        /// Virtual Method Volume
        member this.Volume = this.Width * this.Length * this.Height

        /// Virtual Method Coords Implementation
       
        abstract member Xl : float with get
        default this.Xl = this.X - this.Width / 2.0
        
        abstract member Yl : float with get
        default this.Yl = this.Y - this.Length / 2.0
        
        abstract member Zl : float with get
        default this.Zl = this.Z - this.Height / 2.0
        
        abstract member Xu : float with get
        default this.Xu = this.X + this.Width / 2.0
        
        abstract member Yu : float with get
        default this.Yu = this.Y + this.Length / 2.0
        
        abstract member Zu : float with get
        default this.Zu = this.Z + this.Height / 2.0

        abstract member setX : Set<float> with get
        default this.setX = Set.ofList [ this.Xl .. this.Xu ]

        abstract member setY : Set<float> with get
        default this.setY = Set.ofList [ this.Yl .. this.Yu ]

        abstract member setZ : Set<float> with get
        default this.setZ = Set.ofList [ this.Zl .. this.Zu ]

        abstract member Values : string with get
        default this.Values = 
            "\r ----------------------------" +
            "\r Name: " + (string this.Name) +
            "\r Width: " + (string this.Width) +
            "\r Length: " + (string this.Length) +
            "\r Height: " + (string this.Height) +
            "\r x: " + (string this.X) +
            "\r y: " + (string this.Y) +
            "\r z: " + (string this.Z) +
            "\r Lower x point: " + (string this.Xl) +
            "\r Lower y point: " + (string this.Yl) +
            "\r Lower z point: " + (string this.Zl) +
            "\r Upper x point: " + (string this.Xu) +
            "\r Upper y point: " + (string this.Yu) +
            "\r Upper z point: " + (string this.Zu) +
            "\r Volume: " + (string this.Volume)

        abstract member Print : unit -> unit
        default this.Print () = 
            printfn "-------------------------"
            printfn "Name: %s" this.Name 
            printfn "Width: %f" this.Width
            printfn "Length: %f" this.Length
            printfn "Height: %f" this.Height 
            printfn "x: %f" this.X
            printfn "y: %f" this.Y
            printfn "z: %f" this.Z              
            printfn "Xl:  %f" this.Xl
            printfn "Xu:  %f" this.Xu
            printfn "Yl:  %f" this.Yl
            printfn "Yu:  %f" this.Yu
            printfn "Yl:  %f" this.Zl
            printfn "Yu:  %f" this.Yu
            printfn "setX:  %b" this.setX.IsEmpty
            printfn "setY:  %b" this.setY.IsEmpty
            printfn "setZ:  %b" this.setZ.IsEmpty
            printfn "Volume:  %f" this.Volume


    /// Individual class inherit base class and overload
    type Solid(n:string, a:float, b:float, c:float, x:float, y:float, z:float) =
        inherit Solids()
        override this.Name = n
        override this.Width = a
        override this.Length = b
        override this.Height = c
        override this.X = x
        override this.Y = y
        override this.Z = z

    // Unit Test Object creation and data
    [<TestFixture>]
        type ``Solid_1 object test`` ()=
            let solid1 = new Solid("solid_1", 4.0, 4.0, 4.0, 2.0, 2.0, 2.0)

            [<Test>] member x.
             ``Check if attributes are pasing to object`` ()=
                    float solid1.Width |> should equal 4.0

            [<Test>] member x.
             ``Check if volume calculus is Ok".`` ()=
                    solid1.Volume |> should equal 64
    [<TestFixture>]
        type ``Solid_2 object test`` ()=
            let solid2 = new Solid("solid_2", 3.0, 3.0, 3.0, 3.0, 3.0, 3.0)

            [<Test>] member Width.
             ``Check if attributes are pasing to object`` ()=
                    float solid2.Width |> should equal 4.0

            [<Test>] member Volume.
             ``Check if volume calculus is Ok".`` ()=
                    solid2.Volume |> should equal 27.0

module Functions =
    // Set list of coords x,y,z and get intersection
    let Intersect (setX1, setY1, setZ1, setX2, setY2, setZ2) =
        let setInterX = Set.intersect setX1 setX2        
        let setInterY = Set.intersect setY1 setY2       
        let setInterZ = Set.intersect setZ1 setZ2
        if(setInterX.IsEmpty = false && setInterY.IsEmpty = false && setInterZ.IsEmpty = false) then                         
             do Objects.ExistIntersection <- true
             do Objects.ResultText <- "Intersection!!!"
             printfn "Intersection!"
             do Objects.InterWidth <- (Set.maxElement setInterX) - (Set.minElement setInterX)
             do Objects.InterLength <- (Set.maxElement setInterY) - (Set.minElement setInterY)
             do Objects.InterHeight <- (Set.maxElement setInterZ) - (Set.minElement setInterZ)
             do Objects.InterPointX <- (Set.minElement setInterX) + (Objects.InterWidth / 2.0)
             do Objects.InterPointY <- (Set.minElement setInterY) + (Objects.InterLength / 2.0)
             do Objects.InterPointZ <- (Set.minElement setInterZ) + (Objects.InterHeight / 2.0)
        else 
            do Objects.ResultText <- "No intersection..."
            printfn "No Intersection..."
    Intersect
    /// Unit Test Object creation and data
    [<Test>]
    let ``Check getting intersection sequence``() =
        let sX1 = Set.ofList [ 1.0 .. 3.0 ]
        let sX2 = Set.ofList [ 2.0 .. 4.0 ]
        let sInterX = Set.intersect sX1 sX2 
        sInterX.IsEmpty |> should equal false

    [<Test>]
    let ``Check dimension of intersection sequence``() =
        let sX1 = Set.ofList [ 1.0 .. 3.0 ]
        let sX2 = Set.ofList [ 2.0 .. 4.0 ]
        let sInterX = Set.intersect sX1 sX2 
        sInterX.Count |> should equal 2.0

    [<Test>]
    let ``Check fiiling variable of intersection sequence``() =
        let sX1 = Set.ofList [ 1.0 .. 3.0 ]
        let sX2 = Set.ofList [ 2.0 .. 4.0 ]
        let sInterX = Set.intersect sX1 sX2
        let IWidth = (Set.maxElement sInterX) - (Set.minElement sInterX)
        IWidth |> should equal 1.0
