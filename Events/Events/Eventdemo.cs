using System;
using System.Drawing;
using System.Windows.Forms;

// custom delegate
public delegate void Startdelegate();

class Eventdemo :Form {
    // custom event
    public event Startdelegate StartEvent;    

    public Eventdemo() {
        this.Text = "testar en massa!";

        Button clickMe = new Button();
        Button doubleClik = new Button();

        clickMe.Parent = this;
        clickMe.Text = "Click Me";
        clickMe.Location = new Point((ClientSize.Width - clickMe.Width) / 2, (ClientSize.Height - clickMe.Height) / 2);

        doubleClik.Parent = this;
        doubleClik.Text = "dubbelklicka!";
        doubleClik.Location = new Point((ClientSize.Width - clickMe.Width) / 3, (ClientSize.Height - clickMe.Height) / 3);
        

        // an EventHandler delegate is assigned
        // to the button's Click event
        clickMe.Click += new EventHandler(OnClickMeClicked);
        doubleClik.Click += new EventHandler(doubleClick);

        // our custom "Startdelegate" delegate is assigned
        // to our custom "StartEvent" event.
        StartEvent += new Startdelegate(OnStartEvent);

        // fire our custom event
        StartEvent();
    }

    // this method is called when the "clickMe" button is pressed
    public void OnClickMeClicked(object sender, EventArgs ea) {
        MessageBox.Show("You Clicked My Button!");
    }

    public void doubleClick(object sender, EventArgs ea) {
        Form formSvar = new Form();
        Button bt = new Button();
        formSvar.Activate();
        formSvar.Size = this.ClientSize;
        formSvar.Show();
        bt.Parent = formSvar;
        bt.Height = 35;
        bt.Width = 150;
        bt.BackColor = Color.Azure;
        bt.Location = new Point((ClientSize.Width - bt.Width) / 2, (ClientSize.Height - bt.Height) / 2);
        bt.Text = "Close!";
        bt.Click += bt_Click;
    }

    void bt_Click(object sender, EventArgs e) {
        Close();
    }

    // this method is called when the "StartEvent" Event is fired
    public void OnStartEvent() {
        MessageBox.Show("I Just Started!");
    }

    static void Main(string[] args) {
        Application.Run(new Eventdemo());
    }
}