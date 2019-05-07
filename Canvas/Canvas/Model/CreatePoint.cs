namespace Canvas.Model
{
    public class CreatePoint
    {
        public readonly int X;

        public readonly int Y;

        public CreatePoint(int x_point, int y_point)
        {
            X = x_point;
            Y = y_point;
        }

        public override bool Equals(object obj)
        {
            var point = ((CreatePoint)obj);
            return this.X == point.X && this.Y == point.Y;
        }

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }
    }
}
