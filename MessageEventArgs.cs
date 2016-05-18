using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixDrix
{
    class MessageEventArgs: EventArgs  
    {
            public readonly string Message;

            public MessageEventArgs(string UserError)
            {
                Message = UserError;
            }
        
    }
}

//static IEnumerable<int> VectorColumnSqlStyle(int [][] values,int col)
//{
//    IEnumerable<int> vector =
//         from i in Enumerable.Range(0, 3)
//         select values[col][i];
//    return vector;
//}

//static IEnumerable<int> VectorRowSqlStyle(int[][] values, int row)
//{
//    IEnumerable<int> vector =
//         from i in Enumerable.Range(0, 3)
//         select values[row][i];
//    return vector;
//}