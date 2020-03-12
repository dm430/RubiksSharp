using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateFrontFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateFrontFaceClockwiseCommand(Cube cube) : base(cube, cube.FrontFace)
        {
        }
    }
}
