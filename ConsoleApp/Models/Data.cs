using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp.Models
{
    internal class Data
    {
        public string GetAsString(string url)
        {
            StringBuilder response = new StringBuilder();
            WebClient client = new WebClient();

            using (Stream stream = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        response.Append(line);
                    }
                }
            }

            return response.ToString();
        }
    }
}
