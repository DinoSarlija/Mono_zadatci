using System;
using System.Collections.Generic;
using System.Text;

namespace Zadatak1
{
    class Paper : Wood
    {
        Wood W;
        public Paper(Wood w) {
            W = w;
        }
        public override void MakeProduct() {
            Console.WriteLine("Od " + (W.GetWidth() * W.GetHeight() * W.GetDepth() - 2) + " dasake možemo napraviti " + (W.GetWidth() * W.GetHeight() * W.GetDepth() - 5) + " papir A4 formata.");
        }
    }
}
