namespace Consoleg.LimitedList
{
    public class LimitedList<T>
    {
        private readonly int _capacity;
        private List<T> list;

        public LimitedList(int capacity)
        {
            _capacity = Math.Max(capacity, 2);
            list = new List<T>(_capacity);
        }
    }
}
