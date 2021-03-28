namespace Makruul
{
    public abstract class Establishment : INode
    {
        public abstract void VisitEstablishment();
        public abstract bool IsDone();
        public abstract void Run();
    }
}