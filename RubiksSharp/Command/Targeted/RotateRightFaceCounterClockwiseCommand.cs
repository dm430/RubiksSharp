using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateRightFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateRightFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.RightFace)
        {
        }
    }
}
