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
			string SoapString = HttpClient.GetListAlbums(@"https://itunes.apple.com/search?term=Metallica&country=ru&media=music&entity=album");

			Console.WriteLine(SoapString);
		}
	}
}
