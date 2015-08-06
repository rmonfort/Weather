using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Weather.Helpers
{
    public static class JsonUtility
    {
        public static T DownloadAndDeserializeJson<T>(string url) where T : new()
        {
            using (var webClient = new WebClient())
            {
                var json = string.Empty;

                try
                {
                    json = webClient.DownloadString(url);
                }
                catch (Exception) 
                {
                    // Stop
                }

                // If Json string is not empty, deserialize it to a class and return its instance 
                return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : new T();
            }
        }

    }
}