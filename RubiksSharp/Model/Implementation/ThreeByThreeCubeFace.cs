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
            MapFaceRotation(Size, RotateFaceClockwise);
            RotateRowsOfAdjacentFacesClockwise(topRow, bottomRow, leftRow, rightRow);
        }

        public override void RotateCounterClockwise(CubeRow topRow, CubeRow bottomRow, CubeRow leftRow, CubeRow rightRow)
        {
            MapFaceRotation(Size, RotateFaceCounterClockwise);
            RotateRowsOfAdjacentFacesCounterClockwise(topRow, bottomRow, leftRow, rightRow);
        }

        private void MapFaceRotation(int rowSize, Action<Facelet, Facelet, Facelet, Facelet, Color> rotate)
        {
            for (var cycle = 0; cycle < rowSize / 2; cycle++)
            {
                for (var index = cycle; index < rowSize - 1 - cycle; index++)
                {
                    var facelet1 = Rows[cycle].Facelets[index];
                    var facelet2 = Rows[index].Facelets[rowSize - 1 - cycle];
                    var facelet3 = Rows[rowSize - 1 - cycle].Facelets[rowSize - 1 - index];
                    var facelet4 = rows[rowSize - 1 - index].Facelets[cycle];

                    var facletColorBuffer = facelet2.CurrentColor;

                    rotate(facelet1, facelet2, facelet3, facelet4, facletColorBuffer);
                }
            }
        }

        private static void RotateFaceClockwise(Facelet facelet1, Facelet facelet2, Facelet facelet3, Facelet facelet4, Color facletColorBuffer)
        {
            facelet2.CurrentColor = facelet1.CurrentColor;
            facelet1.CurrentColor = facelet4.CurrentColor;
            facelet4.CurrentColor = facelet3.CurrentColor;
            facelet3.CurrentColor = facletColorBuffer;
        }

        private static void RotateFaceCounterClockwise(Facelet facelet1, Facelet facelet2, Facelet facelet3, Facelet facelet4, Color facletColorBuffer)
        {
            facelet2.CurrentColor = facelet3.CurrentColor;
            facelet3.CurrentColor = facelet4.CurrentColor;
            facelet4.CurrentColor = facelet1.CurrentColor;
            facelet1.CurrentColor = facletColorBuffer;
        }
    }
}
