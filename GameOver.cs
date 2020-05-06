using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Snake_Janika
{
	class GameOver
	{
		public GameOver()
		{

		}

		public void WriteGameOver(int x)
		{
			Ntext text = new Ntext();

			int xOffset = 40;
			int yOffset = 8;

			Console.ForegroundColor = ConsoleColor.Black;
			Console.SetCursorPosition(xOffset, yOffset++);
			text.WriteText("============================", xOffset, yOffset++);
			text.WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			StreamReader from_file = new StreamReader(@"C:\Users\Lenovo\Desktop\Snake\Users.txt", true);
			for (int i = 0; i <= 5; i++)
			{
				string textt = from_file.ReadToEnd();
				Console.SetCursorPosition(xOffset + 1, yOffset++);
				Console.WriteLine(textt);
			}
			from_file.Close();
			text.WriteText("Автор: Janika Valjataga", xOffset + 2, yOffset++);
			text.WriteText("Группа: TARpv19", xOffset + 2, yOffset++);
			text.WriteText("============================", xOffset, yOffset++);
		}
	}
}