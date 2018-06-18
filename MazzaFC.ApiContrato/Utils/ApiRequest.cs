using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.Utils
{
    public class ApiRequest
    {
        private readonly string url;
        private readonly HttpWebRequest request;

        public ApiRequest(string url, string token)
        {
            this.url = url;

            request = (HttpWebRequest)WebRequest.Create(this.url);

            if (!String.IsNullOrEmpty(token))
            {
                var tokenHeader = new System.Collections.Specialized.NameValueCollection();
                tokenHeader.Add("token", token);

                if (tokenHeader.Count > 0)
                    request.Headers.Add(tokenHeader);
            }
        }

        public string Post(NameValueCollection header, object data)
        {
            //Enviar
            //var request = (HttpWebRequest)WebRequest.Create(this.url);
            request.ContentType = "application/json";
            request.Method = "POST";

            if (header != null && header.Count > 0)
                request.Headers.Add(header);

            if (data == null)
                data = new { Dummy = 1 };

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var postData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                streamWriter.Write(postData);
                streamWriter.Flush();
            }

            //Receber
            var responseData = string.Empty;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    responseData = reader.ReadToEnd();
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    var errorResponse = (HttpWebResponse)wex.Response;
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        responseData = reader.ReadToEnd();
                    throw new ArgumentException(responseData);
                }
            }

            return responseData;
        }

        public string Get(NameValueCollection header, object data)
        {
            //Enviar
            //var request = (HttpWebRequest)WebRequest.Create(this.url);
            request.ContentType = "application/json";
            request.Method = "GET";

            if (header != null && header.Count > 0)
                request.Headers.Add(header);

            //Receber
            var response = (HttpWebResponse)request.GetResponse();
            var responseData = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                responseData = reader.ReadToEnd();

            return responseData;
        }

        public string GetQueryString(NameValueCollection header, NameValueCollection data)
        {
            var _url = this.url;

            if (data != null && data.Count > 0)
            {
                var lsParams = new List<String>();
                foreach (string parm in data.AllKeys)
                {
                    lsParams.Add(string.Format("{0}={1}", parm, data[parm]));
                }

                if (lsParams.Any())
                {
                    _url = string.Format("{0}?{1}", _url, string.Join("&", lsParams));
                }
            }

            //Enviar
            //var request = (HttpWebRequest)WebRequest.Create(_url);
            request.ContentType = "application/json";
            request.Method = "GET";

            if (header != null && header.Count > 0)
                request.Headers.Add(header);

            //Receber
            var response = (HttpWebResponse)request.GetResponse();
            var responseData = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                responseData = reader.ReadToEnd();

            return responseData;
        }

        public string Delete(NameValueCollection header, NameValueCollection data)
        {
            var _url = this.url;

            if (data != null && data.Count > 0)
            {
                var lsParams = new List<String>();
                foreach (string parm in data.AllKeys)
                {
                    lsParams.Add(string.Format("{0}={1}", parm, data[parm]));
                }

                if (lsParams.Any())
                {
                    _url = string.Format("{0}?{1}", _url, string.Join("&", lsParams));
                }
            }

            //Enviar
            //var request = (HttpWebRequest)WebRequest.Create(_url);
            request.ContentType = "application/json";
            request.Method = "PUT";

            if (header != null && header.Count > 0)
                request.Headers.Add(header);

            //Receber
            var response = (HttpWebResponse)request.GetResponse();
            var responseData = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                responseData = reader.ReadToEnd();

            return responseData;
        }

    }
}
