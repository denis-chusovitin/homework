//Chusovitin Denis Copyrights (c) 2014
//Chat with bot

module Chat

open elizaBotLibrary
open System.Windows.Forms
open System.Drawing

let rec chat() =
    let frm = new Form(Text = "Chat", Width = 640, Height = 360)
    let tb = new TextBox(Width = 440, Top = 280, Left = 50)
    let bt = new Button(Text = "Send", Top = 280, Left = 500)
    let chatb = new RichTextBox(Width = 440, Height = 260, Top = 10, Left = 50)
    
    frm.Icon <- new Icon(fileName = "Chat.ico")

    let answer() = chatb.AppendText("I: " + tb.Text + "\n")    
                   chatb.AppendText("Eliza: " + meliza_response tb.Text)
                   tb.Text <- ""

    chatb.ReadOnly <- true
    chatb.AppendText("Enter your message...\n")
        
    tb.KeyDown.Add(fun x -> match x.KeyCode with
                             | Keys.Enter -> answer()
                             | Keys.Escape -> frm.Close()
                                              Application.Exit()
                             | _ -> ()
                    )
    bt.Click.Add (fun _ -> answer())

    frm.Controls.AddRange [| tb; bt; chatb |]
    frm.Show()
    Application.Run()
    frm.SetDesktopLocation(100, 100)
 
chat()
