using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    class BoardCell
    {
        public eCellValue CellValue
        {
            get;
            set;
        }


        public BoardCell()
        {
            CellValue = eCellValue.Empty;
        }
    }
}
