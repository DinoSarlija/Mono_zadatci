using System;
using System.Collections.Generic;
using System.Text;

namespace Zadatak1
{
    class Rock : IMaterial {

        int time_to_extract;
        public Rock(int x) {
            time_to_extract = x;
        }

        public void GetTime() {
            Console.WriteLine("Vrijeme potrebno da se iskopa kamen je " + time_to_extract + " sati.");
        }
        public void PrintProperties() {
            Console.WriteLine("Gustoća kamena je 15");
        }
    }
}
