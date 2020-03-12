namespace RubiksSharp.Command
{
    public interface IFaceRotationCommand
    {
        void Execute();

        void Unexecute();
    }
}
