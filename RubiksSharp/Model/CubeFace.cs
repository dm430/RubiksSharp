using RubiksSharp.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace RubiksSharp
{
    public abstract class CubeFace
    {
        protected readonly List<CubeRow> rows;

        public CubeFace(Color color, int rowCount, int rowSize)
        {
            rows = new List<CubeRow>();

            for (var index = 0; index < rowCount; index++)
            {
                rows.Add(new CubeRow(color, rowSize));
            }
        }

        public CubeFace(List<CubeRow> rows)
        {
            this.rows = rows;
        }

        public abstract CubeRow TopRow { get; }

        public abstract CubeRow BottomRow { get; }

        public abstract CubeRow LeftRow { get; }

        public abstract CubeRow RightRow { get; }

        public abstract void RotateClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow);

        public abstract void RotateCounterClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow);

        public IReadOnlyList<CubeRow> Rows => rows;

        public bool IsSolved => rows.All(row => row.IsSolved);

        protected static void SwapRowColors(CubeRow sourceRow, CubeRow destinationRow)
        {
            for (var index = 0; index < destinationRow.Facelets.Count; index++)
            {
                destinationRow.Facelets[index].CurrentColor = sourceRow.Facelets[index].CurrentColor;
            }
        }

        protected static void SwapRowColorsAndOrder(CubeRow sourceRow, CubeRow destinationRow)
        {
            for (var index = 0; index < destinationRow.Facelets.Count; index++)
            {
                var destinationIndex = (destinationRow.Facelets.Count - 1) - index;

                destinationRow.Facelets[destinationIndex].CurrentColor = sourceRow.Facelets[index].CurrentColor;
            }
        }

        protected static void RotateRowsOfAdjacentFacesClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow)
        {
            var bufferRow = rightRow.DeepClone();

            SwapRowColors(topRow, rightRow);
            SwapRowColorsAndOrder(leftRow, topRow);
            SwapRowColors(bottomRow, leftRow);
            SwapRowColorsAndOrder(bufferRow, bottomRow);
        }

        protected static void RotateRowsOfAdjacentFacesCounterClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow)
        {
            var bufferRow = rightRow.DeepClone();

            SwapRowColorsAndOrder(bottomRow, rightRow);
            SwapRowColors(leftRow, bottomRow);
            SwapRowColorsAndOrder(topRow, leftRow);
            SwapRowColors(bufferRow, topRow);
        }
    }
}