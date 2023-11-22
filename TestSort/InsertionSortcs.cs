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
        public void Sort<T>(T[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && GOp<T>.Bigger(arr[j], key))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
        
        /// <summary>
        /// Сравнение двух значений типа 
        /// </summary>
        /// <typeparam name="T">int, float or double</typeparam>
        /// <param name="one">left operand</param>
        /// <param name="two">right operand</param>
        /// <returns>True, if one bigger than two. False, if two bigger than one or two equals one</returns>
       
        //private bool Bigger<T>(T? one, T? two)
        //{
        //    if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        //    {
        //        double leftOperand = Convert.ToDouble(one);
        //        double rightOperand = Convert.ToDouble(two);

        //        if (leftOperand > rightOperand)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Обработка типа {typeof(T)} невозможна в данной версии программы");
        //    }
        //}

        public void SortParallel<T>(T[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
