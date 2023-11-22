namespace TestSort
{
    public interface ISort
    {
        public void Sort<T>(T[] arr);

        public void SortParallel<T>(T[] arr);
    }
}
