namespace TestSort
{
    public class InsertionSort : ISort
    {
        private static InsertionSort _instance;

        public static InsertionSort Instance
        {
            get
            {
                return _instance ?? (_instance = new InsertionSort());
            }
        }
   
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        public void Sort(float[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                float key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        public void Sort(double[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                double key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }


        #region Для TimSort
        public void Sort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        public void Sort(float[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                float key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        public void Sort(double[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                double key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
        #endregion

        public void SortParallel(int[] arr)
        {
            throw new NotImplementedException();
        }

        public void SortParallel(float[] arr)
        {
            throw new NotImplementedException();
        }

        public void SortParallel(double[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
