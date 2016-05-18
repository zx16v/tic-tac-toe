using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixDrix
{
  
    class Player 
    {  
         private  char Symbole;
         public char CellSign 
         { 
             get  { return Symbole;}
             set  {}
         }

         public int CellVal { get; set; }
         public int row           { get; set; }
         public int column        { get; set; }

         public Player( int Num, char Cell) { Symbole = Cell; CellVal = Num; }
      //  public getSelection { return p};
    }
}
