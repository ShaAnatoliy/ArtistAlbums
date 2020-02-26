using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Albums
{
	internal static class HttpClient
	{
		public static string GetListAlbums(string ParamInQuery)
		{
			try
			{
				WebRequest request = HttpWebRequest.Create(ParamInQuery);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				StringBuilder pagebuilder = new StringBuilder();

				string line;
				while ((line = reader.ReadLine()) != null)
					pagebuilder.AppendLine(line);

				response.Close();
				reader.Close();

				return pagebuilder.ToString();
			}
			catch (Exception)
			{
				return "error";
			}

		}


	}
}
