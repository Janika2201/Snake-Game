using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Snake_Janika
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(102, 30);

			string name;
			while (true)
			{
				Console.Write("Назови свое игровое имя: ");
				name = Console.ReadLine();
				if (name.Length < 6)
				{
					Console.Clear();
					Console.WriteLine("Имя должно быть больше 6 символа.");
					continue;
				}
				else if (name.Length > 10)
				{
					Console.Clear();
					Console.WriteLine("Имя не должно быть больше 10 символов.");
					continue;
				}
				else
				{
					Console.Clear();
					break;
				}
			}

			Sounds music = new Sounds();
			music.MainMusic();

			Walls walls = new Walls(100, 25);
			walls.Draw();

			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(100, 24);
			Point food = foodCreator.CreateFood();
			food.Draw();


			Ntext text = new Ntext();

			int xOffsetO4ki = 40;
			int yOffsetO4ki = 26;

			int size = 2;
			text.WriteText("Длина змеи:" + size, xOffsetO4ki - 35, yOffsetO4ki);

			int o4ki = 0;
			text.WriteText("Очки:" + o4ki, xOffsetO4ki, yOffsetO4ki);

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start(); 

			while (true)
			{
				Console.SetCursorPosition(xOffsetO4ki, 27);
				TimeSpan ts = stopWatch.Elapsed;
				Console.WriteLine($"{ts.Minutes:00}:{ts.Seconds:00}");

				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					music.EatSound();
					FoodCreator food1 = new FoodCreator(100, 24);
					food = food1.CreateFood();
					food.FoodDraw();
					o4ki++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					text.WriteText("Очки:" + o4ki, xOffsetO4ki, yOffsetO4ki);
					size++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					text.WriteText("Длина змеи:" + size, xOffsetO4ki - 35, yOffsetO4ki);
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			music.GameOver();

			GameOver game = new GameOver();
			game.WriteGameOver(o4ki);

			Save saveFiles = new Save();
			saveFiles.to_file(name, o4ki);

			ConsoleKeyInfo knop = Console.ReadKey();
			if (knop.Key == ConsoleKey.R)
			{
				var fileName = Assembly.GetExecutingAssembly().Location;
				System.Diagnostics.Process.Start(fileName);
				Environment.Exit(0);
			}
		}

	}
}
