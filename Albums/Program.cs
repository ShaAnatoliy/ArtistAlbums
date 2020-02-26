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

				string query = $"https://itunes.apple.com/search?term={vocalist}&country=ru&media=music&entity=album";

				string SoapString = HttpClient.GetListAlbums(query);

				if (SoapString == "error")
				{
					Console.WriteLine(HttpClient.RetError);
				}
				else
				{
					AlbumsModel response = Serializer.Deserialize<AlbumsModel>(SoapString);
					if (response.resultCount > 0)
					{
						Console.WriteLine("Получено {0} альбомов исполнителя \"{1}\"", response.resultCount, vocalist);
					}
					else
					{
						Console.WriteLine("Нет альбомов по исполнителю \"{0}\"", vocalist);
					}
				}

			}
		}
	}
}
