using System;
using System.Collections.Generic;
using System.Text;
using Canvas.Model;

namespace Canvas.Command
{
    public interface ICommand
    {
        void CommandValidation(List<string> cmd);

        CreateCanvas ExecuteCommand();
    }
}
