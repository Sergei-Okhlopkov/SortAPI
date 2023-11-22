namespace TestSort
{
    public class SortDistributor
    {
        private readonly ISort sort;

        public SortDistributor(ISort sort)
        {
            this.sort = sort;
        }

        public void Sort<T>(T[] arr)
        {
            sort.Sort(arr);
        }

        public void SortParallel<T>(T[] arr)
        {
            sort.SortParallel(arr);
        }
    }
}
