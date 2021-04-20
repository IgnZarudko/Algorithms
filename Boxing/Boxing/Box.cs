namespace Boxing
{
    public class Box
    {
        private double _contentSize;
        private readonly double _maxSize;
        public double AvailableSpace => _maxSize - _contentSize;

        public Box(double maxSize = 1.0)
        {
            _contentSize = 0.0;
            _maxSize = maxSize;
        }

        public bool Put(double contentToAddSize)
        {
            if (!IsFit(contentToAddSize))
            {
                return false;
            }
            _contentSize += contentToAddSize;
            return true;
        }

        private bool IsFit(double contentToAddSize) => AvailableSpace - contentToAddSize > 0;
    }
}