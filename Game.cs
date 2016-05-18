using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixDrix
{
   class Game
    {
       public event ErrorHandler NonValidInputMessage;
       public bool isInitialized;
       private int[][] Board;
       private Player [] player;
       private Player CurrentPlayer;
       private const int InitalCellVal=-6, NumOfNonCrucialMoves=5;
       private string gameResult=null;
       public Game() 
       { 
           isInitialized=true;
           GameBegin();
       }
       
       public int [][]BOARD {
                               get { return Board;}
                               set{} 
                            }
       
            
       public void  GameBegin()
       {
          player   = new Player [2];
          player[0]= new Player(0,'O');
          player[1]= new Player(1,'X');
          
          Board  = new int[3][];
          Board[0]  =   new int [3]{InitalCellVal,InitalCellVal,InitalCellVal};
          Board[1]  =   new int [3]{InitalCellVal,InitalCellVal,InitalCellVal};
          Board[2]  =   new int [3]{InitalCellVal,InitalCellVal,InitalCellVal};
        
       }

  
      IEnumerable<int> VectorColumn(int column) { return Enumerable.Range(0, 3).Select((m, i) => Board[i][column]); }

      IEnumerable<int> VectorRow   (int row)    { return Enumerable.Range(0, 3).Select((m, i) => Board[row][i]);    }

      IEnumerable<int> Diagonal    ()           { return Enumerable.Range(0, 3).Select((m, i) => Board[i][i] );   }

      IEnumerable<int> DiagonalSec ()           { return Enumerable.Range(0, 3).Select((m, i) => Board[i][2-i]);      }
     
     
    
      
      public bool IsValidMove() { return (CurrentPlayer.row >= 0 && CurrentPlayer.row <= 2 && CurrentPlayer.column >= 0 && CurrentPlayer.column <= 2); }

      private bool IsCellFree() { return (Board[CurrentPlayer.row][CurrentPlayer.column] == InitalCellVal); }

      private void SetSelectedCell()  {  Board[CurrentPlayer.row][CurrentPlayer.column] = CurrentPlayer.CellVal; }

      public bool IsEmptyCellLeft() 
      {
          int sum = 0;
          for (int i = 0; i < 3; i++)
              sum += VectorColumn(i).Sum();
           return sum < 0;
      }

      private bool IsWin()
      {
          for (int i = 0; i < 2; i++)
          {
              if (VectorColumn(i).Sum() == 0 || VectorColumn(i).Sum() == 3)
                  return true;
              if (VectorRow(i).Sum() == 0 || VectorRow(i).Sum() == 3)
                  return true;
          }
          if (Diagonal().Sum() == 0 || Diagonal().Sum() == 3)
              return true;
          if (DiagonalSec().Sum() == 0 || DiagonalSec().Sum() == 3)
              return true;
          else return false;
      }


     

      public void Play()
       {
          int PlayerIndex=0,Totalmoves=0;
          CurrentPlayer=player[PlayerIndex];
          bool isNotWin;
          bool isEmptyCell;
        
          UI.DrawBoard(this.BOARD);
          while ( Totalmoves < NumOfNonCrucialMoves || ( isNotWin = !IsWin() )&& (isEmptyCell = IsEmptyCellLeft() ) )  
          {   
                    
               UI.getPlayerSelectedCell(CurrentPlayer);
               if ( IsValidMove() && IsCellFree() )
                    SetSelectedCell();
               else
               {
                   if (NonValidInputMessage != null)
                       NonValidInputMessage(this, new MessageEventArgs("\n Please Enter valid row and coulmn values"));
                   UI.DrawBoard(this.BOARD);
                
                   continue;
               }
               UI.DrawBoard(this.BOARD);
               CurrentPlayer = player[++PlayerIndex % 2];
               Totalmoves++; 
     
          }

          CurrentPlayer = player[++PlayerIndex % 2];
          UI.AnanuceGameResult(GetGameResult(isNotWin));
                
                
            
        }
         

        public string GetGameResult(bool isNotWin)
        {
           if (isNotWin==false)
               return  "\n The player with "+CurrentPlayer.CellSign+" won the game";
           return "\n The game ended with a draw";
        }
        // יש לולאה , תנאי עצירה : נצחון או תיקו אבל להתחיל לבדוק את הנצחון אחרי 5 מהלכים  
        //במקום זה אפשר ללת לולאה של מונה מהלכים, אחרי 9 מהלכים לכל היותר לסיים אבל עם אפשרות לצאת מוקדם יותר במקרה של נצחון 
        // for (   bool1 && bool2
        // או לוותר על החסכון ולהרוויח קוד כללי יותר המתאים ליותר משחקים 
        // do{
        //  
        // while(IsBeginCheckeGameEnd()==True && IsGameEnded()==False)
       
   
    }


}
/*אופן פעולת התוכנית 
 * אתחול מטריצה ושחחקנים
 * הצגת הלוח 
 * תשאול שחקן לגבי בחירת תא 
 * וידוא חוקיות הבחירה 
 *  אם כן מילוי הערך במטריצה 
 *  והצגת הטריצה 
 *   בדיקת הכרעת  המשחק 
 *  אם כן הכרזה על המנצח
 *  אם לא  החלפת שחקן 
 *  וחזרה לשורה 8
 */