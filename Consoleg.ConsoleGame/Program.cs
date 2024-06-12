using Consoleg.ConsoleGame;
using Consoleg.ConsoleGame.Extensions;
using Consoleg.ConsoleGame.UserInterface;
using Consoleg.LimitedList;
using Microsoft.Extensions.Configuration;
using System;

//var li = new LimitedList<SomeDel>(10);

IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

var ui = config.GetSection("game:ui").Value;
var x1 = config.GetSection("game:mapsettings:x").Value;
var mapsettings = config.GetSection("game:mapsettings").GetChildren();

var x = config.GetMapSizeFor("x");
var y = config.GetMapSizeFor("y");


var game = new Game(new ConsoleUI(), new Map(width: x, height: y));
game.Run();

Console.WriteLine("Game Over");
Console.ReadLine();
