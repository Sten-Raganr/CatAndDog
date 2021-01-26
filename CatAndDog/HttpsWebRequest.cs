using System;
using System.Net;

namespace CatAndDog
{
    internal class HttpsWebRequest
    {
        public string Method { get; internal set; }

        public static explicit operator HttpsWebRequest(WebRequest v)
        {
            throw new NotImplementedException();
        }

        internal object GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}