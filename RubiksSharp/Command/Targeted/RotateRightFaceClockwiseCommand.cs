using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateRightFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateRightFaceClockwiseCommand(Cube cube) : base(cube, cube.RightFace)
        {
        }
    }
}
