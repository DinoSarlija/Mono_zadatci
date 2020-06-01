using System;
using System.Runtime.InteropServices;

namespace Zadatak1 {
    class Program {    
        static void Main(string[] args) {

            Rock R = new Rock(26);
            Wood W = new Wood();
            W.SetWidth(1);
            W.SetHeight(2);
            W.SetDept(3);
            Metal M = new Metal();
            Paper P = new Paper(W);
            R.GetTime();
            W.MakeProduct();
            M.PrintProperties();
            P.MakeProduct();

        }
    }
}
