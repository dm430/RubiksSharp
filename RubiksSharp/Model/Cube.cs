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

        public void RotateClockwise(CubeFace face)
        {
            if (face == FrontFace)
            {
                FrontFace.RotateClockwise(TopFace.BottomRow, BottomFace.TopRow, LeftFace.RightRow, RightFace.LeftRow);
            }
            else if (face == BackFace)
            {
                BackFace.RotateClockwise(TopFace.TopRow, BottomFace.BottomRow, RightFace.RightRow, LeftFace.LeftRow);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void RotateCounterClockwise(CubeFace face)
        {
            if (face == FrontFace)
            {
                FrontFace.RotateCounterClockwise(TopFace.BottomRow, BottomFace.TopRow, LeftFace.RightRow, RightFace.LeftRow);
            }
            else if (face == BackFace)
            {
                BackFace.RotateCounterClockwise(TopFace.TopRow, BottomFace.BottomRow, RightFace.RightRow, LeftFace.LeftRow);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
