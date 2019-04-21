using System;
using System.Collections.Generic;
using System.Text;

namespace Conway
{
    class Runner
    {
        static void Main(String[] args)
        {
            Game g = new Game(3);
            g.run();
        }
    }
}
