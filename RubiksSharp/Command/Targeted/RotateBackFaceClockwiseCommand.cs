using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateBackFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateBackFaceClockwiseCommand(Cube cube) : base(cube, cube.BackFace)
        {
        }
    }
}
