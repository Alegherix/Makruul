namespace Makruul
{
    public class Food
    {
        public string name;
        public int healing;

        public Food(string name, int healing)
        {
            this.name = name;
            this.healing = healing;
        }

        public override string ToString()
        {
            return $"{name} - ({healing} health regeneration)";
        }
    }
}