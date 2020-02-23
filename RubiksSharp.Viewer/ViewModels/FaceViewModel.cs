using System.Collections.Generic;

namespace RubiksSharp.Viewer.ViewModels
{
    class FaceViewModel
    {
        public CubeFace Face { get; }
        public List<RowViewModel> Rows { get; }

        public FaceViewModel(CubeFace face)
        {
            Face = face;
            Rows = new List<RowViewModel>();

            foreach (var row in face.Rows)
            {
                var viewRow = new RowViewModel(row);
                Rows.Add(viewRow);
            }
        }

        public void TriggerChange()
        {
            foreach (var row in Rows)
            {
                row.TriggerChange();
            }
        }
    }
}
