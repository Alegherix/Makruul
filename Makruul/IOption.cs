namespace Makruul
{
    public interface IOption
    {
        public string[] GetOptions();

        public void PerformOption(int option);
    }
}