using RubiksSharp.Model.Data;
using System.ComponentModel;

namespace RubiksSharp.Viewer
{
    class FacletViewModel : INotifyPropertyChanged
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
                TriggerChange();
            }
        }

        public void TriggerChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentColor"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
