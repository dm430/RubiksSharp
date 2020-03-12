using RubiksSharp.Command;
using RubiksSharp.Model;
using System.Collections.Generic;

namespace RubiksSharp.Solution.Strategy
{
    public interface ICubeSolveStrategy
    {
        IEnumerable<IFaceRotationCommand> Solve(Cube cube);
    }
}
