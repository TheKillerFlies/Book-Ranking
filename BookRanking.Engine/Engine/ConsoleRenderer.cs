using BookRanking.Engine.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Engine
{
    public class ConsoleRenderer : IRenderer
    {
        public IEnumerable<string> Input()
        {
            var currentLine = Console.ReadLine();
            while (currentLine!="end")
            {
                yield return currentLine;
                currentLine = Console.ReadLine();
            }
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
