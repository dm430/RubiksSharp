using System;
using System.Collections.Generic;
using RubiksSharp.Model.Data;

namespace RubiksSharp.Model.Implementation
{
    public class ThreeByThreeCubeFace : CubeFace
    {
        private const int Size = 3;
        private const int MiddleRowIndex = 1;
        private const int TopRowIndex = 0;

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
        }

        public CubeRow MiddleRow => rows[MiddleRowIndex];

        public override CubeRow TopRow => rows[TopRowIndex];

        public override CubeRow BottomRow => rows[rows.Count - 1];

        public override CubeRow LeftRow
        {
            get
            {
                var facelets = new List<Facelet>()
                {
                    TopRow.Facelets[0],
                    MiddleRow.Facelets[0],
                    BottomRow.Facelets[0]
                };

                return new CubeRow(facelets);
            }
        }

        public override CubeRow RightRow
        {
            get
            {
                var facelets = new List<Facelet>()
                {
                    TopRow.Facelets[2],
                    MiddleRow.Facelets[2],
                    BottomRow.Facelets[2]
                };

                return new CubeRow(facelets);
            }
        }

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
