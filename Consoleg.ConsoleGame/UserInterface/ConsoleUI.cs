using Consoleg.ConsoleGame.Extensions;
using Consoleg.LimitedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Consoleg.ConsoleGame.UserInterface
{
    internal class ConsoleUI : IUI
    {
        private ILimitedList<string> messageLog;
        private readonly IMap map;

        public ConsoleUI(IMap map, ILimitedList<string> messageLog)
        {
            this.map = map;
            this.messageLog = messageLog;
        }

        public void AddMessage(string message) => messageLog.Add(message);

        public void PrintLog()
        {
            messageLog.Print(message => Console.WriteLine(message + new string(' ', Console.WindowWidth - message.Length)));
        }

        public void Draw()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell? cell = map.GetCell(y, x);
                    ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                    IDrawable drawable = map.Creatures.CreatureAtExtension(cell)
                                                                            ?? cell.Items.FirstOrDefault() as IDrawable
                                                                            ?? cell;
                    Console.ForegroundColor = drawable.Color;
                    Console.Write(drawable.Symbol);
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

        public void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
