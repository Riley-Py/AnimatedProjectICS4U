namespace AnimatedProjectICS4U
/*
 * Author: Riley Cant
 * Course: ICS4U
 * Program: Dinosaur game summative
 * Date of submission: 10/04/23
 * Description of game: made a copy of Google's popular "Dinosaur game" in C# to demonstrate classes/objects
 * */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent(); 

            ChangeScreen(this, new MenuScreen());
        }
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }
        
    }
}