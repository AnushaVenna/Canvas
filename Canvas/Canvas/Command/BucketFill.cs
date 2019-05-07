using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Model;

namespace Canvas.Command 
{
    public class BucketFill : ICommand
    {
        private int _x, _y;
        private char _colour;
        private CreateCanvas _canvas;

        public BucketFill(CreateCanvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException("Create a new canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Arguments missing");

            if (cmd.Count != 3)
                throw new ArgumentException("Bucket Fill command accept 3 arguments: x,y,c.");

            if ((!int.TryParse(cmd[0], out _x) || _x <= 0) ||
                (!int.TryParse(cmd[1], out _y) || _y <= 0))
                throw new ArgumentException("Arguments should be a positive integer");

            if ((_x > _canvas._width - 2) || (_y > _canvas._height - 2))
                throw new ArgumentException("Point should be in the canvas");

            if (!char.TryParse(cmd[2], out _colour))
                throw new ArgumentException("Colour should be a char");
        }

        public CreateCanvas ExecuteCommand()
        {
            var queue = new Queue<CreatePoint>();
            queue.Enqueue(new CreatePoint(_x, _y));
            var traversed = new HashSet<CreatePoint>();

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (!traversed.Add(current) ||
                    _canvas.cells[current.X, current.Y] == _canvas.lineChar ||
                    _canvas.cells[current.X, current.Y] == _canvas.horizontalChar ||
                    _canvas.cells[current.X, current.Y] == _canvas.verticalChar)
                {
                    continue;
                }

                _canvas.cells[current.X, current.Y] = _colour;
                queue.Enqueue(new CreatePoint(current.X - 1, current.Y));
                queue.Enqueue(new CreatePoint(current.X + 1, current.Y));
                queue.Enqueue(new CreatePoint(current.X, current.Y - 1));
                queue.Enqueue(new CreatePoint(current.X, current.Y + 1));
            }

            return _canvas;
        }
    }
}
