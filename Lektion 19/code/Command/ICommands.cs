namespace Code.Command
{
    interface ICommand
    {
        void Execute();
        void Undo();
        string Print();

    }
}