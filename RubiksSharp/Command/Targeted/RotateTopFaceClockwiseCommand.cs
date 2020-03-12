using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateTopFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateTopFaceClockwiseCommand(Cube cube) : base(cube, cube.TopFace)
        {
        }
    }
}
