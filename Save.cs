﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    class Save
    {
        public Save()
        {
        }

        public void to_file(string x)
        {
            StreamWriter to_file = new StreamWriter(@"C:\Users\Lenovo\Desktop\Snake\Users.txt", true);
            to_file.WriteLine(x);
            to_file.Close();
        }

        public void from_file()
        {
            StreamReader from_file = new StreamReader("Users.txt");
            string text = from_file.ReadToEnd();
            Console.WriteLine(text);
            from_file.Close();
        }
    }
}
