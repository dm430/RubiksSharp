using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateFrontFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateFrontFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.FrontFace)
        {
        }
    }
}
