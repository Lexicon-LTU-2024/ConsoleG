namespace Consoleg.LimitedList
{
    public class LimitedList<T> 
    {
        private readonly int _capacity;
        private List<T> _list;

        public int Count => _list.Count;
        public bool IsFull => _capacity <= Count;

        public LimitedList(int capacity)
        {
            _capacity = Math.Max(capacity, 2);
            _list = new List<T>(_capacity);
        }

        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");

            if (IsFull) return false;
            _list.Add(item); return true;

        }
    }
}
