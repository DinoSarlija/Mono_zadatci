using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Zadatak1
{
    class Wood : IMaterial {

        int width;
        int height;
        int depth;

        public void SetWidth(int w) { 
            width = w;
        }
        public void SetHeight(int h) {
            height = h; ;
        }
        public void SetDept(int d) {
            depth = d;
        }     
        public int GetWidth() {
            return width;
        }
        public int GetHeight() {
            return height;
        }
        public int GetDepth() {
            return depth;
        }

        public virtual void MakeProduct() {
            Console.WriteLine("Od drveta određenih dimeznzija možemo napraviti " + (width * height * depth - 2) + " dasake.");
        }
        public void PrintProperties() {
            Console.WriteLine("Gustoća drveta je 5");
        }
    }
}
