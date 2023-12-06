using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex54
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }
    }
}
