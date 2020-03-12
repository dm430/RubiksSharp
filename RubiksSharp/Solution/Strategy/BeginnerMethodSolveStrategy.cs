using System;
using System.Collections.Generic;
using RubiksSharp.Command;
using RubiksSharp.Model;

namespace RubiksSharp.Solution.Strategy
{
    public class BeginnerMethodSolveStrategy : ICubeSolveStrategy
    {
        public IEnumerable<IFaceRotationCommand> Solve(Cube cube)
        {
            // Solve white corss
            // Solve white corners
            // Solve middle edges
            // Solve yellow cross
            // Solve yellow face
            // Permutate last layer
            // Rotate last layer
            throw new NotImplementedException();
        }
    }
}
