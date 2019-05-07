using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command
{
    public class Line : ICommand
    {
        private int _x1, _x2, _y1, _y2;
        private CreateCanvas _canvas;

        public Line(CreateCanvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException("Create a new canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Arguments missing");

            if (cmd.Count != 4)
                throw new ArgumentException("Line command accepts 4 arguments: x1,x2,y1,y2");

            if ((!int.TryParse(cmd[0], out _x1) || _x1 <= 0) ||
                (!int.TryParse(cmd[2], out _x2) || _x2 <= 0) ||
                (!int.TryParse(cmd[1], out _y1) || _y1 <= 0) ||
                (!int.TryParse(cmd[3], out _y2) || _y2 <= 0))
                throw new ArgumentException("Arguments should be a positive integer");

            if ((_x1 != _x2) && (_y1 != _y2))
                throw new ArgumentException("Only	horizontal or vertical lines are supported.");

            if ((_x1 > _x2) || (_y1 > _y2))
                throw new ArgumentException("Invalid arguments: x1 > x2 or y1 > y2");

            if ((_x2 > _canvas._width - 2) || (_y2 > _canvas._height - 2))
                throw new ArgumentException("Point should be in the canvas");
        }

        public CreateCanvas ExecuteCommand()
        {
            if (_x1 == _x2)
            {
                //draw vertical
                for (int i = _y1; i <= _y2; i++)
                    _canvas.cells[_x1, i] = _canvas.lineChar;
            }
            else if (_y1 == _y2)
            {
                //draw horizontal
                for (int i = _x1; i <= _x2; i++)
                    _canvas.cells[i, _y1] = _canvas.lineChar;
            }

            return _canvas;
        }
    }
}
