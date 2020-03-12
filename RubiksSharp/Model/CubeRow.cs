using System;
using System.Linq;
using RubiksSharp.Model.Data;
using System.Collections.Generic;

namespace RubiksSharp.Model
{
    public class CubeRow : IDeepCloneable<CubeRow>
    {
        private const int MinimumRowSize = 1;

        private readonly List<Facelet> facelets;

        public CubeRow(Color color, int rowSize)
        {
            if (rowSize < MinimumRowSize)
            {
                throw new ArgumentException("The row must contain one or more facelets.", nameof(rowSize));
            }

            facelets = new List<Facelet>();

            for (var index = 0; index < rowSize; index++)
            {
                facelets.Add(new Facelet(color));
            }
        }

        public CubeRow(List<Facelet> facelets)
        {
            this.facelets = facelets ?? throw new ArgumentNullException(nameof(facelets));

            if (facelets.Count < MinimumRowSize)
            {
                throw new ArgumentException("The faclet list must contain one or more facelets.", nameof(facelets));
            }
        }

        public IReadOnlyList<Facelet> Facelets => facelets;

        public bool IsSolved => Facelets.All(facelet => facelet.IsSolved);

        public CubeRow ChangeOrientation()
        {
            var faceletsx = new List<Facelet>();

            for (var i = facelets.Count - 1; i >= 0; i--)
            {
                faceletsx.Add(facelets[i]);
            }

            return new CubeRow(faceletsx);
        }

        public object Clone()
        {
            var faceletClones = new List<Facelet>();

            for (var index = 0; index < facelets.Count; index++)
            {
                var faceletClone = facelets[index].DeepClone();

                faceletClones.Add(faceletClone);
            }

            return new CubeRow(faceletClones);
        }

        public CubeRow DeepClone()
        {
            return (CubeRow) Clone();
        }
    }
}