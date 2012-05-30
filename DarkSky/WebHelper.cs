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
            var tcs = new TaskCompletionSource<T>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.BeginGetResponse(iar =>
                {
                    HttpWebResponse response = null;
                    try
                    {
                        response = (HttpWebResponse)request.EndGetResponse(iar);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var sreader = new StreamReader(response.GetResponseStream());
                            var result = sreader.ReadToEnd();

                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                            byte[] bytes = Encoding.UTF8.GetBytes(result);
                            using (var stream = new MemoryStream(bytes))
                            {
                                var deserialized = serializer.ReadObject(stream);

                                tcs.SetResult( (T)deserialized );
                            }
                        }
                        else
                        {
                            tcs.SetResult(default(T));
                        }
                    }
                    catch (Exception exc) { tcs.SetException(exc); }
                    finally { if (response != null) response.Close(); }
                }, null);
            }
            catch (Exception exc) { tcs.SetException(exc); }
            return tcs.Task;

		}
	}
}

