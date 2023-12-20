namespace TestSort
{
    public interface ISort
    {
        public void Sort(int[] arr);
        public void Sort(float[] arr);
        public void Sort(double[] arr);

        public void SortParallel(int[] arr);
        public void SortParallel(float[] arr);
        public void SortParallel(double[] arr);
    }
}
