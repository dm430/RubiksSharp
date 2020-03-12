using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateLeftFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateLeftFaceClockwiseCommand(Cube cube) : base(cube, cube.LeftFace)
        {
        }
    }
}
