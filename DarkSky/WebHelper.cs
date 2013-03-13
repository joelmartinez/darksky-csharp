using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky
{
	internal static class WebHelper
	{
        /// <summary>Does an HTTP get on the supplied URL</summary>
        public static async Task<T> Json<T>(string url)
        {
            return await Json<T>(url, string.Empty);
        }

        /// <summary>Does an HTTP get if no post data is supplied, otherwise, a post</summary>
		public static async Task<T> Json<T>(string url, string postData)
        {
            var tcs = new TaskCompletionSource<T>();
            var request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(postData))
            {
                request.AllowWriteStreamBuffering = true;
                request.Method = "POST";
                request.ContentLength = postData.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData);
            }

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
            return await tcs.Task;

		}
	}
}

