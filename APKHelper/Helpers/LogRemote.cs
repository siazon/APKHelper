using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace APKHelper.Helpers
{
   public static class LogRemote
    {
        public static void Debug(string msg)
        {
            //  Log("Debug",msg);
            string aaa = "{\"msg\":\""+msg+"\"}";
            Post("http://localhost:5001/api/MacStatus",aaa);
        }
        private static async void Log(string Type,string msg)
        {
            var client = new HttpClient();
            client.DefaultRequestVersion = HttpVersion.Version20;
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
            
            HttpContent content=new StringContent(Type+":"+msg);
            var resp = await client.GetAsync("http://localhost:5001/api/MacStatus");
            var body = await resp.Content.ReadAsStringAsync();
        }

        public static void Post(string postUrl, string paramData, Dictionary<string, string> headers = null)
        {
            HttpWebRequest webReq = null;
            HttpWebResponse response = null;
            Stream newStream = null;
            Stream resStream = null;
            StreamReader sr = null;
            try
            {
                string ret = string.Empty;

                Encoding dataEncode = System.Text.Encoding.GetEncoding("utf-8");
                //将URL编码后的字符串转化为字节
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                ServicePointManager.DefaultConnectionLimit = 512;
                ServicePointManager.Expect100Continue = false;
                webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                //webReq.ServicePoint.Expect100Continue = false;
                //webReq.ServicePoint.ConnectionLimit = 512;
                //webReq.Proxy = null;
                webReq.KeepAlive = true;
                //Post请求方式
                webReq.Method = "POST";
                // 内容类型
                webReq.ContentType = "application/json";
                webReq.Timeout = 50000;
                //设置请求的 ContentLength 
                webReq.ContentLength = byteArray.Length;
                //获得请 求流
                newStream = webReq.GetRequestStream();

                //将请求参数写入流
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                response = (HttpWebResponse)webReq.GetResponse();
                //获得响应流
                resStream = response.GetResponseStream();
                sr = new StreamReader(resStream, System.Text.Encoding.GetEncoding("utf-8"));
                ret = sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response == null && ex.Status != WebExceptionStatus.Success)
                {
                }
                if (ex.Response is HttpWebResponse sss)
                {
                    resStream = sss.GetResponseStream();
                    sr = new StreamReader(resStream, System.Text.Encoding.GetEncoding("utf-8"));
                    string msg = "";
                    var ret = sr.ReadToEnd();
                    try
                    {
                        //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(ret);
                        //msg = data.resultMessage;
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            finally
            {
                if (newStream != null)
                {
                    newStream.Close();
                    newStream = null;
                }
                if (resStream != null)
                {
                    resStream.Close();
                    resStream = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (webReq != null)
                {
                    webReq.Abort();
                    webReq = null;
                }
                if (sr != null)
                {
                    sr.Close();
                    sr = null;
                }
            }

        }
    }
}
