namespace Solids.FrontEnd
open System.Drawing
open System.Windows.Forms
open System
open Solids.Logics

module Main =
    open Functions
    
    //Create labes
    let labelC1 =
        let temp = new Label()
        do temp.Text<- "Coordinates Solid 1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(20,22)
        temp
    
    let labelX1 =
        let temp = new Label()
        do temp.Text<- "x1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,40)
        temp

    let labelY1 =
        let temp = new Label()
        do temp.Text<- "y1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,60)
        temp

    let labelZ1 =
        let temp = new Label()
        do temp.Text<- "z1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,80)
        temp

    let labelD1 =
        let temp = new Label()
        do temp.Text<- "Dimensions Solid 1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(20,102)
        temp

    let labelW1 =
        let temp = new Label()
        do temp.Text<- "w1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,120)
        temp

    let labelL1 =
        let temp = new Label()
        do temp.Text<- "l1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,140)
        temp

    let labelH1 =
        let temp = new Label()
        do temp.Text<- "h1"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(5,160)
        temp

    let labelC2 =
        let temp = new Label()
        do temp.Text<- "Coordinates Solid 2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(170,22)
        temp

    let labelX2 =
        let temp = new Label()
        do temp.Text<- "x2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,40)
        temp

    let labelY2 =
        let temp = new Label()
        do temp.Text<- "y2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,60)
        temp

    let labelZ2 =
        let temp = new Label()
        do temp.Text<- "z2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,80)
        temp

    let labelD2 =
        let temp = new Label()
        do temp.Text<- "Dimensions Solid 2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(170,102)
        temp

    let labelW2 =
        let temp = new Label()
        do temp.Text<- "w2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,120)
        temp

    let labelL2 =
        let temp = new Label()
        do temp.Text<- "l2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,140)
        temp

    let labelH2 =
        let temp = new Label()
        do temp.Text<- "h2"
        do temp.AutoSize <- true
        do temp.Location <- new Drawing.Point(145,160)
        temp

    //Create textboxes 
    let textboxX1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,40)
        temp
 
    let textboxY1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,60)
        temp   
 
    let textboxZ1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,80)
        temp   
 
    let textboxW1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,120)
        temp
 
    let textboxL1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,140)
        temp
 
    let textboxH1 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(25,160)
        temp

    let textboxX2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,40)
        temp
 
    let textboxY2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,60)
        temp
 
    let textboxZ2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,80)
        temp   
 
    let textboxW2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,120)
        temp
 
    let textboxL2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,140)
        temp   
 
    let textboxH2 =
        let temp = new TextBox()
        do temp.Text <- "0"
        do temp.Location <- new Drawing.Point(165,160)
        temp  
    
    // Create button
    let button1 =
        let temp = new Button()
        do temp.Text <- "Calculate"
        do temp.Location <- new Drawing.Point(120,200)
        temp  

    //Create Form and Add Controls   
    let form = new Form(BackColor = Color.AntiqueWhite, Text = "Calculate Intersection Between 2 Solids", AutoSize = true)
    form.Controls.Add(labelC1)
    form.Controls.Add(labelX1)
    form.Controls.Add(labelY1)
    form.Controls.Add(labelZ1)
    form.Controls.Add(labelD1)
    form.Controls.Add(labelW1)
    form.Controls.Add(labelL1)
    form.Controls.Add(labelH1)
    form.Controls.Add(labelC2)
    form.Controls.Add(labelX2)
    form.Controls.Add(labelY2)
    form.Controls.Add(labelZ2)
    form.Controls.Add(labelD2)
    form.Controls.Add(labelW2)
    form.Controls.Add(labelL2)
    form.Controls.Add(labelH2)  
    form.Controls.Add(textboxX1)
    form.Controls.Add(textboxY1)
    form.Controls.Add(textboxZ1)
    form.Controls.Add(textboxW1)
    form.Controls.Add(textboxL1)
    form.Controls.Add(textboxH1)
    form.Controls.Add(textboxX2)
    form.Controls.Add(textboxY2)
    form.Controls.Add(textboxZ2)
    form.Controls.Add(textboxW2)
    form.Controls.Add(textboxL2)
    form.Controls.Add(textboxH2)
    form.Controls.Add(button1)
  
    //Trigger function 
    let Calculate evArgs = 
        let Solid_1 = new Solids.Logics.Objects.Solid("Solid 1",float textboxW1.Text,float textboxL1.Text,float textboxH1.Text, float textboxX1.Text, float textboxY1.Text, float textboxZ1.Text)  
        let Solid_2 = new Solids.Logics.Objects.Solid("Solid 2",float textboxW2.Text,float textboxL2.Text,float textboxH2.Text, float textboxX2.Text, float textboxY2.Text, float textboxZ2.Text) 
        Solid_1.Print()
        Solid_2.Print()
        let MyIntersect = Functions.Intersect(Solid_1.setX, Solid_1.setY, Solid_1.setZ, Solid_2.setX, Solid_2.setY, Solid_2.setZ) 
        if Objects.ExistIntersection = true then 
            let InterSolid = new Solids.Logics.Objects.Solid("Intersection", Objects.InterWidth, Objects.InterLength, Objects.InterHeight, Objects.InterPointX, Objects.InterPointY, Objects.InterPointZ)            
            InterSolid.Print()
            MessageBox.Show(Solid_1.Values + Solid_2.Values + InterSolid.Values, Objects.ResultText) |> ignore
        else
            MessageBox.Show(Solid_1.Values + Solid_2.Values, Objects.ResultText) |> ignore
    Calculate
    //Define Action
    button1.Click.Add(Calculate)

    //Show Form
    Application.Run(form)