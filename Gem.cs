namespace InfernoIII
{
    public class Gem
    {
        private long power;
        private bool isExcluded;

        public Gem(long power)
        {
            this.power = power;
            this.isExcluded = false;
        }

        public long Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public bool IsExcluded { get { return this.isExcluded; } }

        public void SetItemExclusion(Exclusion exclusion)
        {
            if (exclusion == Exclusion.Exclude)
            {
                this.isExcluded = true;
            }
            else if (exclusion == Exclusion.Reverse)
            {
                this.isExcluded = false;
            }
        }
    }
}
