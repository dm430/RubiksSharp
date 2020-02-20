using System;
using System.Collections.Generic;
using RubiksSharp.Model.Data;

namespace RubiksSharp.Model.Implementation
{
    public class ThreeByThreeCubeFace : CubeFace
    {
        private const int Size = 3;
        private const int MiddleRowIndex = 1;
        private const string InvlaideRowMessage = "The supplied row does not fit on a three by three cube.";

        public ThreeByThreeCubeFace(Color color) : base(color, Size, Size)
        {
        }

        public ThreeByThreeCubeFace(CubeRow topRow, CubeRow middleRow, CubeRow bottomRow) 
            : base(new List<CubeRow>() { topRow, middleRow, bottomRow })
        {
            if (topRow == null)
            {
                throw new ArgumentNullException(nameof(topRow));
            }

            if (middleRow == null)
            {
                throw new ArgumentNullException(nameof(middleRow));
            }

            if (bottomRow == null)
            {
                throw new ArgumentNullException(nameof(bottomRow));
            }

            if (topRow.Facelets.Count != Size)
            {
                throw new ArgumentException(InvlaideRowMessage, nameof(topRow));
            }

            if (middleRow.Facelets.Count != Size)
            {
                throw new ArgumentException(InvlaideRowMessage, nameof(middleRow));
            }

            if (bottomRow.Facelets.Count != Size)
            {
                throw new ArgumentException(InvlaideRowMessage, nameof(bottomRow));
            }
        }

        public CubeRow MiddleRow => rows[MiddleRowIndex];

        public override void RotateClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow)
        {
            // TODO: Rotate face.
            for (var x = 0; x < rows.Count; x++)
            {

            }

            RotateRowsOfAdjacentFacesClockwise(topRow, bottomRow, leftRow, rightRow);
        }

        public override void RotateCounterClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow)
        {
            // TODO: Rotate face.
            RotateRowsOfAdjacentFacesCounterClockwise(topRow, bottomRow, leftRow, rightRow);
        }
    }
}
