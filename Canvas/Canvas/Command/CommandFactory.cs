using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command
{
    class CommandFactory
    {
        public static ICommand CreateCommandInstance(List<string> cmd, CreateCanvas canvas)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Wrong command");

            switch (cmd[0])
            {
                case "C":
                    return new Command();
                case "L":
                    return new Line(canvas);
                case "R":
                    return new Rectangle(canvas);
                case "B":
                    return new BucketFill(canvas);
                case "Q":
                    return new Quit();
                default:
                    throw new ArgumentException($"Invalid command: {cmd[0]}");
            }
        }
    }
}
