using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command
{
    public class Command : ICommand
    {
        private int _width;
        private int _height;

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Arguments missing");

            if (cmd.Count != 2)
                throw new ArgumentException("Accept only width & height arguments");

            if ((!int.TryParse(cmd[0], out _width) || _width <= 0) ||
                (!int.TryParse(cmd[1], out _height) || _height <= 0))
                throw new ArgumentException("Arguments should be a positive integer");
        }

        public CreateCanvas ExecuteCommand()
        {
            var canvas = new CreateCanvas(_width, _height);
            return canvas;
        }
    }
}
