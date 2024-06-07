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
    internal class ConsoleUI
    {
        private static MessageLog<string> messageLog = new(6);

        internal static void AddMessage(string message) => messageLog.Add(message);

        internal static void PrintLog()
        {
            messageLog.Print(message => Console.WriteLine(message + new string(' ', Console.WindowWidth - message.Length)));
        }

        internal static void Draw(IMap map)
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

        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
    }
}
