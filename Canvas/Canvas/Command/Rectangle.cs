using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command
{
    public class Rectangle : ICommand
    {
        private int _x1, _x2, _y1, _y2;
        private CreateCanvas _canvas;

        public Rectangle(CreateCanvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException("Create a new canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Arguments missing");

            if (cmd.Count != 4)
                throw new ArgumentException("Rectangle command accept 4 arguments: x1,x2,y1,y2");

            if ((!int.TryParse(cmd[0], out _x1) || _x1 <= 0) ||
                (!int.TryParse(cmd[2], out _x2) || _x2 <= 0) ||
                (!int.TryParse(cmd[1], out _y1) || _y1 <= 0) ||
                (!int.TryParse(cmd[3], out _y2) || _y2 <= 0))
                throw new ArgumentException("Arguments should be a positive integer");

            if ((_x1 > _x2) || (_y1 > _y2))
                throw new ArgumentException("Invalid Arguments: x1 > x2 or y1 > y2");

            if ((_x2 > _canvas._width - 2) || (_y2 > _canvas._height - 2))
                throw new ArgumentException("Point should be in the canvas");
        }

        public CreateCanvas ExecuteCommand()
        {
            for (int i = _y1; i <= _y2; i++)
            {
                for (int j = _x1; j <= _x2; j++)
                {
                    if (i == _y1 || i == _y2 || j == _x1 || j == _x2)
                        _canvas.cells[j, i] = _canvas.lineChar;
                    else
                        _canvas.cells[j, i] = ' ';
                }
            }
            return _canvas;
        }
    }
}
