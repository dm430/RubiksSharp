using RubiksSharp.Model.Data;
using System.ComponentModel;

namespace RubiksSharp.Viewer
{
    class FacletViewModel
    {
        private readonly Facelet facelet;

        public FacletViewModel(Facelet facelet)
        {
            this.facelet = facelet;
        }

        public Color CurrentColor {
            get
            {
                return facelet.CurrentColor;
            }
            set
            {
                facelet.CurrentColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentColor)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
