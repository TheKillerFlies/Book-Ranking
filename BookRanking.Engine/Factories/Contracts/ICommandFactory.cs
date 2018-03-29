using BookRanking.Engine.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Factories
{
    public interface  ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
