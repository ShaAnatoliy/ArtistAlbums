using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Albums
{
	class Program
	{
		static void Main(string[] args)
		{
			string vocalist; // "Сергей+Трофимов"; //"Витас"; //"Metallica";

			while (true)
			{
				vocalist = "";

				Console.WriteLine("Ввести исполнителя (exit - выход):");
				vocalist = Console.ReadLine(); // Get string from user
				if (vocalist == "exit") // Check string
				{
					break;
				}

				string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\albums-" + vocalist + ".txt";

				string query = $"https://itunes.apple.com/search?term={vocalist}&country=ru&media=music&entity=album";

				string SoapString = HttpClient.GetListAlbums(query);

				if (SoapString == "error")
				{
					Console.WriteLine(HttpClient.RetError);

					if (File.Exists(fileName))
					{
						SoapString = File.ReadAllText(fileName);
					}
				}

				AlbumsModel response = Serializer.Deserialize<AlbumsModel>(SoapString);
				if (response.resultCount > 0)
				{
					Console.WriteLine("Найдено {0} альбомов исполнителя \"{1}\"", response.resultCount, vocalist);
					var titles = response.results.Select(item => item.copyright).ToList();
					foreach (var cr in titles)
					{
						Console.WriteLine(cr);
					}
					try
					{
						File.WriteAllText(fileName, SoapString);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				else
				{
					Console.WriteLine("Нет альбомов по исполнителю \"{0}\"", vocalist);
				}
				
				Console.WriteLine("*");
			}
		}
	}
}
