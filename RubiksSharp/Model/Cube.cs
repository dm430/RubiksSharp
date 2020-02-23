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

            if (rotate.Target == FrontFace)
            {
                rotate(TopFace.BottomRow, BottomFace.TopRow, LeftFace.RightRow, RightFace.LeftRow);
            }
            else if (rotate.Target == BackFace)
            {
                rotate(BottomFace.BottomRow, TopFace.TopRow, LeftFace.LeftRow.ChangeOrientation(), RightFace.RightRow.ChangeOrientation());
            }
            else if (rotate.Target == LeftFace)
            {
                rotate(TopFace.LeftRow, BottomFace.LeftRow.ChangeOrientation(), BackFace.RightRow, FrontFace.LeftRow);
            }
            else if (rotate.Target == RightFace)
            {
                rotate(TopFace.RightRow.ChangeOrientation(), BottomFace.RightRow, FrontFace.RightRow, BackFace.LeftRow);
            }
            else if (rotate.Target == TopFace)
            {
                rotate(BackFace.TopRow, FrontFace.TopRow.ChangeOrientation(), LeftFace.TopRow.ChangeOrientation(), RightFace.TopRow);
            }
            else if (rotate.Target == BottomFace)
            {
                rotate(FrontFace.BottomRow.ChangeOrientation(), BackFace.BottomRow, LeftFace.BottomRow, RightFace.BottomRow.ChangeOrientation());
            }
            else
            {
                throw new InvalidOperationException("The target face does not belong to the cube. Rotation cannot be performed.");
            }
        }

        public void RotateClockwise(CubeFace face)
        {
            if (face == null)
            {
                throw new ArgumentNullException(nameof(face));
            }

            MapRotation(face.RotateClockwise);
        }

        public void RotateCounterClockwise(CubeFace face)
        {
            if (face == null)
            {
                throw new ArgumentNullException(nameof(face));
            }

            MapRotation(face.RotateCounterClockwise);
        }
    }
}
