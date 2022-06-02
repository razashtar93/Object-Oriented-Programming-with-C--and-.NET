using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex05
{
    public class BoardCell
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
