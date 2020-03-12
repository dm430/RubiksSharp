using System;
using System.Linq;
using RubiksSharp.Model.Data;
using System.Collections.Generic;

namespace RubiksSharp.Model
{
    public abstract class CubeFace
    {
        private const int MinimumRowCount = 1;
        private const int MinimumRowSize = 1;

        protected readonly List<CubeRow> rows;

        public CubeFace(Color color, int rowCount, int rowSize)
        {
            if (rowCount < MinimumRowCount)
            {
                throw new ArgumentException("The row count must be greater or equal to one.", nameof(rowCount));
            }

            rows = new List<CubeRow>();

            for (var index = 0; index < rowCount; index++)
            {
                rows.Add(new CubeRow(color, rowSize));
            }
        }

        public CubeFace(List<CubeRow> rows)
        {
            this.rows = rows ?? throw new ArgumentNullException(nameof(rows));

            if (rows.Count < MinimumRowCount)
            {
                throw new ArgumentException("The rows list must contain one or more rows.", nameof(rows));
            }
        }

        public abstract void RotateClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow);

        public abstract void RotateCounterClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow);

        public IReadOnlyList<CubeRow> Rows => rows;

        public virtual CubeRow TopRow => rows[0];

        public virtual CubeRow BottomRow => rows[rows.Count - 1];

        public virtual CubeRow LeftRow => ExtractVerticalRow(0);

        public virtual CubeRow RightRow
        {
            get
            {

                var lastRowIndex = rows[0].Facelets.Count - 1;

                return ExtractVerticalRow(lastRowIndex);
            }
        }

        public bool IsSolved => rows.All(row => row.IsSolved);

        protected CubeRow ExtractVerticalRow(int faceletIndex)
        {
            var facelets = new List<Facelet>();

            foreach (var row in rows)
            {
                var facelet = row.Facelets[faceletIndex];

                facelets.Add(facelet);
            }

            return new CubeRow(facelets);
        }

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