using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateTopFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateTopFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.TopFace)
        {
        }
    }
}
