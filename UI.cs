using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixDrix
{

static  class UI
  {
    public static void AnanuceGameResult(string gameResult) { Console.WriteLine( gameResult); }

    public static void getPlayerSelectedCell(Player player)
    {
        bool NotValidRow=true;
        bool NotValidColumn = true;
        while (NotValidRow || NotValidColumn)
        {
            int result, ro1=0,ro2=0;
            Console.WriteLine("\n\n\n write your row Index");
            NotValidRow = !(Int32.TryParse(Console.ReadLine(), out result));
            if (!NotValidRow)
             player.row = result;
             ro1 = Console.CursorTop-1; 
            Console.WriteLine("\n write your Column Index");
            NotValidColumn = !(Int32.TryParse(Console.ReadLine(), out result));

            if (!NotValidColumn)
                player.column = result;
            ro2 = Console.CursorTop-1;

            ClearCurrentConsoleLine (ro2);
            ClearCurrentConsoleLine (ro1);
            ClearCurrentConsoleLine(ro2-1);
            ClearCurrentConsoleLine(ro1-1);
            Console.SetCursorPosition(0, 6);
           
         }
        
        Console.Clear();
    }

    public static void ClearCurrentConsoleLine( int currentLineCursor)
    {
        Console.SetCursorPosition(0, currentLineCursor);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    public static  char cell(int BoardVal)
    {
         if ( BoardVal==-6)
              return ' ';
         else if (BoardVal==0)
              return '0';
         return 'X';
    }

    public static void DrawBoard(int [][]jagg)
    {
        Console.Clear();
        Console.WriteLine("\n"); 
        for (int i = 0; i < 3; i++)
        {
             for (int j = 0; j < 3; j++)
                   Console.Write( "{0} |", cell(jagg[i][j] )   );
              if(i<2)      
                Console.WriteLine("\n_________");
        }
   }

  }


}