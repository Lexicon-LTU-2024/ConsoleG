
namespace Consoleg.ConsoleGame.UserInterface
{
    internal interface IUI
    {
        void AddMessage(string message);
        void Clear();
        void Draw();
        ConsoleKey GetKey();
        void PrintLog();
        void PrintStats(string stats);
    }

    //internal class SomeOtherUI : IUI
    //{
    //    public void AddMessage(string message)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Draw(IMap map)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ConsoleKey GetKey()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void PrintLog()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void PrintStats(string stats)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}