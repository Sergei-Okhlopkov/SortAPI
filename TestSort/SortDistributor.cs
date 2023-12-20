namespace TestSort
{
    public class SortDistributor
    {
        private readonly ISort sort;

        public SortDistributor(ISort sort)
        {
            this.sort = sort;
        }

        public void Sort(int[] arr)
        {
            sort.Sort(arr);
        }

        public void Sort(float[] arr)
        {
            sort.Sort(arr);
        }

        public void Sort(double[] arr)
        {
            sort.Sort(arr);
        }

        public void SortParallel(int[] arr)
        {
            sort.SortParallel(arr);
        }

        public void SortParallel(float[] arr)
        {
            sort.SortParallel(arr);
        }

        public void SortParallel(double[] arr)
        {
            sort.SortParallel(arr);
        }
    }
}
