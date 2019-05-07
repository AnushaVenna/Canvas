using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command
{
    public class Quit : ICommand
    {
        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("Arguments missing");

            if (cmd.Any())
                throw new ArgumentException("Arguments are not allowed");
        }

        public CreateCanvas ExecuteCommand()
        {
            Environment.Exit(Environment.ExitCode);
            return null;
        }
    }
}
