using System;

namespace RubiksSharp
{
    public abstract class Cube
    {
        protected Cube(CubeFace front, CubeFace back, CubeFace left, CubeFace right, CubeFace top, CubeFace bottom)
        {
            FrontFace = front;
            BackFace = back;
            LeftFace = left;
            RightFace = right;
            TopFace = top;
            BottomFace = bottom;
        }

        public CubeFace FrontFace { get; }

        public CubeFace BackFace { get; }

        public CubeFace LeftFace { get; }

        public CubeFace RightFace { get; }

        public CubeFace TopFace { get; }

        public CubeFace BottomFace { get; }

        public bool IsSolved
        {
            get
            {
                return FrontFace.IsSolved && BackFace.IsSolved && LeftFace.IsSolved 
                    && RightFace.IsSolved && TopFace.IsSolved && BottomFace.IsSolved;
            }
        }

        private void MapRotation(Action<CubeRow, CubeRow, CubeRow, CubeRow> rotate)
        {
            // topRow, bottomRow, leftRow, rightRow

            // TODO: Im almost positive that I messed this up. Get an actual cube and check. Also use a consistent relative mapping.

            if (rotate.Target == FrontFace)
            {
                rotate(TopFace.BottomRow, BottomFace.TopRow, LeftFace.RightRow, RightFace.LeftRow);
            }
            else if (rotate.Target == BackFace)
            {
                rotate(TopFace.TopRow, BottomFace.BottomRow, RightFace.RightRow, LeftFace.LeftRow);
            }
            else if (rotate.Target == LeftFace)
            {
                rotate(TopFace.LeftRow, BottomFace.LeftRow, BackFace.RightRow, FrontFace.LeftRow);
            }
            else if (rotate.Target == RightFace)
            {
                rotate(TopFace.RightRow, BottomFace.RightRow, FrontFace.RightRow, BackFace.LeftRow);
            }
            else if (rotate.Target == TopFace)
            {
                rotate(BackFace.TopRow, FrontFace.TopRow, LeftFace.TopRow, RightFace.TopRow);
            }
            else if (rotate.Target == BottomFace)
            {
                rotate(FrontFace.BottomRow, BackFace.BottomRow, LeftFace.BottomRow, RightFace.BottomRow);
            }
            else
            {
                throw new InvalidOperationException("The target face does not belong to the cube. Rotation cannot be performed.");
            }
        }

        public void RotateClockwise(CubeFace face)
        {
            MapRotation(face.RotateClockwise);
        }

        public void RotateCounterClockwise(CubeFace face)
        {
            MapRotation(face.RotateCounterClockwise);
        }
    }
}
