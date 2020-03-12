using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateLeftFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateLeftFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.LeftFace)
        {
        }
    }
}
