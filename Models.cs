using System;
using System.Collections.Generic;
using System.Text;

namespace MyJokes
{
    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
    }

    public class JokeObj
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke{ get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public Flags flags { get; set; }
        public int id { get; set; }
        public string lang { get; set; }
    }
}
