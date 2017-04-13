namespace InfernoIII
{
    public class OperationInfo
    {
        public static readonly int LeftIndexDefault = int.MinValue;
        public static readonly int RightIndexDefaul = int.MaxValue;

        private int leftIndex;
        private int rightIndex;
        private int currIndex;
        private long wantedSum;
        
        public OperationInfo(int leftIndex, int rightIndex, long wantedSum)
        {
            this.leftIndex = leftIndex;
            this.currIndex = 0;
            this.rightIndex = rightIndex;
            this.wantedSum = wantedSum;
        }

        public int LeftIndex
        {
            get { return this.leftIndex; }
            set
            {
                if (this.leftIndex != LeftIndexDefault)
                {
                    this.leftIndex = value;
                }
            }
        }

        public int RightIndex
        {
            get { return this.rightIndex; }
            set
            {
                if (this.rightIndex != RightIndexDefaul)
                {
                    this.rightIndex = value;
                }
            }
        }

        public int CurrIndex
        {
            get { return this.currIndex; }
            set { this.currIndex = value; }
        }

        public long WantedSum
        {
            get { return this.wantedSum; }
            set { this.wantedSum = value; }
        }
    }
}
