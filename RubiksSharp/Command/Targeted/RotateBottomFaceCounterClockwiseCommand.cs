using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateBottomFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateBottomFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.BottomFace)
        {
        }
    }
}
