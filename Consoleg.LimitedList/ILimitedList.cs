
namespace Consoleg.LimitedList
{
    public interface ILimitedList<T> : IEnumerable<T>
    {
        T this[int index] { get; }

        int Count { get; }
        bool IsFull { get; }

        bool Add(T item);
        void Print(Action<T> action);
        bool Remove(T item);
    }
}