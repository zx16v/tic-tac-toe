using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace MixDrix
{
    class Program
    {
      
        static void ShowErrorMessage(object sender, MessageEventArgs e) { MessageBox.Show(e.Message); }
        static void Main(string[] args)
        {
            Game game = new Game();
            game.NonValidInputMessage += ShowErrorMessage;
            game.Play();
            Console.Read();
            
        }
        
    }
}

