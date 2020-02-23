using System.Collections.Generic;

namespace RubiksSharp.Viewer.ViewModels
{
    class RowViewModel
    {
        private CubeRow row;

        public List<FacletViewModel> Facelets { get; }

        public RowViewModel(CubeRow row)
        {
            this.row = row;
            Facelets = new List<FacletViewModel>();

            foreach (var faclet in row.Facelets)
            {
                Facelets.Add(new FacletViewModel(faclet));
            }
        }

        public void TriggerChange()
        {
            foreach (var facelet in Facelets)
            {
                facelet.TriggerChange();
            }
        }
    }
}
