using Consoleg.ConsoleGame;
using Consoleg.ConsoleGame.Extensions;
using Consoleg.ConsoleGame.UserInterface;
using Consoleg.LimitedList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

//var li = new LimitedList<SomeDel>(10);

IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

//var ui = config.GetSection("game:ui").Value;
//var x1 = config.GetSection("game:mapsettings:x").Value;
//var mapsettings = config.GetSection("game:mapsettings").GetChildren();

//var x = config.GetMapSizeFor("x");
//var y = config.GetMapSizeFor("y");

var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IUI, ConsoleUI>();
                   services.AddSingleton<IMap, Map>();
                   services.AddSingleton<IConfiguration>(config);
                   services.AddSingleton<IMapSettings>(config.GetSection("game:mapsettings").Get<MapSettings>()!);
                   services.AddSingleton<Game>();

               })
               .UseConsoleLifetime()
               .Build();

host.Services.GetRequiredService<Game>().Run();
//var game = new Game(new ConsoleUI(), new Map(width: 10, height: 10));
//game.Run();

Console.WriteLine("Game Over");
Console.ReadLine();
