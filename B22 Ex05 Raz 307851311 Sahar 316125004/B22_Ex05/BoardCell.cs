using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex05
{
    public class BoardCell
    {
        private eCellValue m_CellValue;
        public eCellValue CellValue
        {
            get { return m_CellValue; }
            set { m_CellValue = value; }
        }

        public BoardCell()
        {
            CellValue = eCellValue.Empty;
        }
    }
}
