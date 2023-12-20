namespace TestSort
{
    public class TimSort: ISort
    {
        private static TimSort _instance;

        public static TimSort Instance
        {
            get
            {
                return _instance ?? (_instance = new TimSort());
            }
        }
       
        public void Sort<T>(T[] arr)
        {
            int N = arr.Length;

            int minRunSize = GetMinrun(N);

            for (int i = 0; i < N; i += minRunSize)
            {
                InsertionSort(arr, i, Math.Min(i + minRunSize - 1, N - 1));
            }

            for (int size = minRunSize; size <= N; size = 2 * size)
            {
                int k = 0;

                for (int left = 0; left < N; left += 2 * size)
                {
                    int mid = Math.Min(left + size - 1, N - 1);
                    int right = Math.Min(left + 2 * size - 1, N - 1);

                    int leftSize = mid - left + 1;
                    int rightSize = right - mid < 0 ? 0 : right - mid;

                    T[] leftArr = new T[leftSize];
                    T[] rightArr = new T[rightSize];

                    for (int i = 0; i < leftSize; i++)
                    {
                        leftArr[i] = arr[i + left];
                    }

                    for (int i = 0; i < rightSize; i++)
                    {
                        rightArr[i] = arr[i + mid + 1];
                    }

                    if (mid < right)
                    {
                        MergeSort(arr, leftArr, leftSize, rightArr, rightSize, ref k);
                    }

                }
            }
        }

        public void SortParallel<T>(T[] arr)
        {
            int N = arr.Length;

            int minRunSize = GetMinrun(N);

            Parallel.ForEach(SteppedIterator(0, N, minRunSize), i =>
            {
                InsertionSort(arr, i, Math.Min(i + minRunSize - 1, N - 1));
            });

            for (int size = minRunSize; size <= N; size = 2 * size)
            {
                int k = 0;

                for (int left = 0; left < N; left += 2 * size)
                {
                    int mid = Math.Min(left + size - 1, N - 1);
                    int right = Math.Min(left + 2 * size - 1, N - 1);

                    int leftSize = mid - left + 1;
                    int rightSize = right - mid < 0 ? 0 : right - mid;

                    T[] leftArr = new T[leftSize];
                    T[] rightArr = new T[rightSize];

                    for (int i = 0; i < leftSize; i++)
                    {
                        leftArr[i] = arr[i + left];
                    }

                    for (int i = 0; i < rightSize; i++)
                    {
                        rightArr[i] = arr[i + mid + 1];
                    }

                    if (mid < right)
                    {
                        MergeSort(arr, leftArr, leftSize, rightArr, rightSize, ref k);
                    }

                }
            }
        }

        //public void MergeSort<T>(T[] arr, T[] left, int leftSize, T[] right, int rightSize, ref int k) 
        //{
        //    int i = 0;
        //    int j = 0;
        //    while (i < leftSize && j < rightSize)
        //    {
        //        if (left[i] <= right[j])
        //        {
        //            arr[k++] = left[i++];
        //        }
        //        else
        //        {
        //            arr[k++] = right[j++];
        //        }
        //    }

        //    while (i < leftSize)
        //    {
        //        arr[k++] = left[i++];
        //    }

        //    while (j < rightSize)
        //    {
        //        arr[k++] = right[j++];
        //    }
        //}
        public void MergeSort<T>(T[] arr, T[] left, int leftSize, T[] right, int rightSize, ref int k)
        {
            int i = 0;
            int j = 0;
            while (i < leftSize && j < rightSize)
            {
                if (GOp<T>.LesserEqual(left[i], right[j]))
                {
                    arr[k++] = left[i++];
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }

            while (i < leftSize)
            {
                arr[k++] = left[i++];
            }

            while (j < rightSize)
            {
                arr[k++] = right[j++];
            }
        }

        public void InsertionSort<T>(T[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= left && GOp<T>.Bigger(arr[j], key)) 
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        private int GetMinrun(int n)
        {
            int r = 0;           /* ±≥αφσ≥ 1 σ±δΦ ±≡σΣΦ ±ΣΓΦφ≤≥√⌡ ßΦ≥εΓ ß≤Σσ≥ ⌡ε≥  ß√ 1 φσφ≤δσΓεΘ */
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }
            return n + r;
        }

        private static IEnumerable<int> SteppedIterator(int startIndex, int endIndex, int stepSize)
        {
            for (int i = startIndex; i < endIndex; i = i + stepSize)
            {
                yield return i;
            }
        }
    }
}
