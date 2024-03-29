﻿using System.Text;

namespace RestWithAspNet5Example.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        
        private string href;
        public string Href { 
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href.ToLower());
                    return sb.Replace("%2f", "/").ToString();
                }
            }

            set { href = value; } 
        }
        public string Type { get; set; }
        public string Action { get; set; }


    }
}
