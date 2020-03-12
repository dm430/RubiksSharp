using RubiksSharp.Model;
using RubiksSharp.Solution.Strategy;

namespace RubiksSharp.Solution
{
    public class CubeSolver : ICubeSolver
    {
        private readonly ICubeSolveStrategy cubeSolveStrategy;

        public CubeSolver(ICubeSolveStrategy cubeSolveStrategy) 
        {
            this.cubeSolveStrategy = cubeSolveStrategy;
        }

        public virtual void Solve(Cube cube)
        {
            var solutionSteps = cubeSolveStrategy.Solve(cube);

            foreach (var solutionStep in solutionSteps)
            {
                solutionStep.Execute();
            }
        }
    }
}
