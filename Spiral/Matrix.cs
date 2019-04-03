using System;
using System.Collections.Generic;

namespace Spiral
{
    class Matrix<T>
    {
        List<Row<T>> list = new List<Row<T>>();
        private readonly int rowSize;
        private readonly int colSize;

        public Matrix(int RowSize, int ColSize)
        {
            for (int i = 0; i < RowSize; i++)
            {
                list.Add(new Row<T>(ColSize));
            }

            rowSize = RowSize;
            colSize = ColSize;
        }

        public Row<T> this[int index] => list[index];

        public Element<T> this[int Row, int Col] => list[Row][Col];


        enum PathDirection
        {
            LTR, RTL, TTB, BTT
        };

        public IList<Element<T>> GetSpiral()
        {
            List<Element<T>> Result = new List<Element<T>>();
            int row = 0;
            int col = 0;
            PathDirection direction = PathDirection.LTR;

            while (true)
            {
                switch (direction)
                {
                    case PathDirection.LTR:
                        for (int j = col; j < colSize; j++)
                        {
                            var element = this[row][j];
                            if (!element.Visited)
                            {
                                element.Visited = true;
                                Result.Add(element);
                            }
                            else
                            {
                                direction = PathDirection.TTB;
                                //TODO: update row col

                                break;
                            }
                        }
                        break;
                    case PathDirection.RTL:
                        break;
                    case PathDirection.TTB:
                        break;
                    case PathDirection.BTT:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
