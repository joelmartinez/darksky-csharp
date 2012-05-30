using System;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DarkSky
{
	internal static class WebHelper
	{
		public static Task<T> Json<T>(string url)
		{
			return Task.Factory.StartNew(() => 
			{
				var request = WebRequest.CreateHttp(url);
				
				var response = request.GetResponse();
				var sreader = new StreamReader(response.GetResponseStream());
                var result = sreader.ReadToEnd();
				 
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                byte[] bytes = Encoding.UTF8.GetBytes(result);
                using (var stream = new MemoryStream(bytes))
                {
                    var deserialized = serializer.ReadObject(stream);

                    return (T)deserialized;
                }
			});
		}
	}
}

