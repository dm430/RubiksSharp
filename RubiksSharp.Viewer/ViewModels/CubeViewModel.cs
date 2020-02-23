using System.Collections.Generic;

namespace RubiksSharp.Viewer.ViewModels
{
    class CubeViewModel
    {
        private readonly Cube cube;

        private readonly List<FaceViewModel> faces;

        public FaceViewModel FrontFace { get; }

        public FaceViewModel BackFace { get; }

        public FaceViewModel LeftFace { get; }

        public FaceViewModel RightFace { get; }

        public FaceViewModel TopFace { get; }

        public FaceViewModel BottomFace { get; }

        public CubeViewModel(Cube cube)
        {
            this.cube = cube;
            FrontFace = new FaceViewModel(cube.FrontFace);
            BackFace = new FaceViewModel(cube.BackFace);
            LeftFace = new FaceViewModel(cube.LeftFace);
            RightFace = new FaceViewModel(cube.RightFace);
            TopFace = new FaceViewModel(cube.TopFace);
            BottomFace = new FaceViewModel(cube.BottomFace);
            faces = new List<FaceViewModel>()
            {
                FrontFace,
                BackFace,
                LeftFace,
                RightFace,
                TopFace,
                BottomFace
            };
        }

        public void RotateClockwise(FaceViewModel faceviewModel)
        {
            cube.RotateClockwise(faceviewModel.Face);
            TriggerChanges();
        }

        public void RotateCounterClockwise(FaceViewModel faceviewModel)
        {
            cube.RotateCounterClockwise(faceviewModel.Face);
            TriggerChanges();
        }

        private void TriggerChanges()
        {
            foreach (var face in faces)
            {
                face.TriggerChange();
            }
        }
    }
}
