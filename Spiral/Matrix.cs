using System;
using System.Collections.Generic;

namespace Spiral
{
    class Matrix<T>
    {
        List<Row<T>> list = new List<Row<T>>();
        public readonly int RowSize;
        public readonly int ColSize;

        public Matrix(int RowSize, int ColSize)
        {
            for (int i = 0; i < RowSize; i++)
            {
                list.Add(new Row<T>(ColSize));
            }

            this.RowSize = RowSize;
            this.ColSize = ColSize;
        }

        public Row<T> this[int index] => list[index];

        public Element<T> this[int Row, int Col] => list[Row][Col];


        enum PathDirection
        {
            LTR, RTL, TTB, BTT
        };

        public IList<T> GetSpiral()
        {
            List<T> Result = new List<T>();
            int row = 0;
            int col = 0;
            PathDirection direction = PathDirection.LTR;

            bool listCompleted = false;

            void visit(bool movRow, bool movCol, bool positiveDir)
            {
                #region Checking if completed
                int trow = row, tcol = col;

                GetPos();
                var testElement = this[trow, tcol];
                if (testElement.Visited == true)
                {
                    listCompleted = true;
                    return;
                } 
                #endregion

                trow = row;
                tcol = col;

                while (true)
                {
                    //try new position
                    #region Decide Row and Column
                    GetPos();
                    #endregion

                    var element = this[trow, tcol];
                    if (element.Visited == false)
                    {
                        Result.Add(element.Value);
                        element.Visited = true;

                        //update in original
                        row = trow;
                        col = tcol;
                    }

                    else { break; }
                }
                    void GetPos()
                    {
                        if (positiveDir)
                        {
                            if (movRow)
                            {
                                trow++;
                            }
                            else if (movCol)
                            {
                                tcol++;
                            }
                        }

                        else
                        {
                            if (movRow)
                            {
                                trow--;
                            }
                            else if (movCol)
                            {
                                tcol--;
                            }
                        }
                    }
                
            }

            while (!listCompleted)
            {
                switch (direction)
                {
                    case PathDirection.LTR:
                        visit(false, true, true);
                        break;
                    case PathDirection.RTL:
                        visit(false, true, false);
                        break;
                    case PathDirection.TTB:
                        visit(true, false, true);
                        break;
                    case PathDirection.BTT:
                        visit(true, false, false);
                        break;
                    default:
                        break;
                }
            }

            return Result;
        }
    }
}
