namespace TestSort
{
    public static class GOp<T>
    {
        public static bool Bigger(T? one, T? two)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                double leftOperand = Convert.ToDouble(one);
                double rightOperand = Convert.ToDouble(two);

                if (leftOperand > rightOperand)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"Обработка типа {typeof(T)} невозможна в данной версии программы");
            }
        }

        public static bool Lesser(T? one, T? two)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                double leftOperand = Convert.ToDouble(one);
                double rightOperand = Convert.ToDouble(two);

                if (leftOperand < rightOperand)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"Обработка типа {typeof(T)} невозможна в данной версии программы");
            }
        }

        public static bool LesserEqual(T? one, T? two)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                double leftOperand = Convert.ToDouble(one);
                double rightOperand = Convert.ToDouble(two);

                if (leftOperand <= rightOperand)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"Обработка типа {typeof(T)} невозможна в данной версии программы");
            }
        }

        public static bool BiggerEqual(T? one, T? two)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                double leftOperand = Convert.ToDouble(one);
                double rightOperand = Convert.ToDouble(two);

                if (leftOperand >= rightOperand)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"Обработка типа {typeof(T)} невозможна в данной версии программы");
            }
        }
    }
}
