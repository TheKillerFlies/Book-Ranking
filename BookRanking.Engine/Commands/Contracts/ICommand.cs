using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands.Contracts
{
    public interface ICommand
    {
        object Execute(IList<string> parameters);
    }
}
