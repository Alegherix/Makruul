namespace Makruul
{
    public abstract class Entity
    {
        public int health { get; set; }
        public string name { get; protected init; }

        public abstract int Attack<T>(T entity) where T : Entity;
    }
}