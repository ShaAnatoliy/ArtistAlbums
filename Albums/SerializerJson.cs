using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums
{
	internal static class Serializer
	{
		internal static string Serialize<T>(this T arg, string fileName)
		{
			string res = JsonConvert.SerializeObject(arg, Formatting.Indented);
			return res;
		}

		internal static T Deserialize<T>(string injson)
		{
			T res = JsonConvert.DeserializeObject<T>(injson);
			return res;
		}
	}
}
