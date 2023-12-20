using Microsoft.AspNetCore.Mvc;
using Ninject;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace TestSort.Controllers
{
    public class SortController : Controller
    {
        StandardKernel kernel = new StandardKernel();
        public SortController()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
        }

        [HttpPost("timSort")]
        public ActionResult<int[]> TimSort([FromBody] int[] arr)
        {
            var sort = kernel.Get<ISort>();
            SortDistributor sd = new SortDistributor(sort);

            sd.Sort(arr);

            return arr;
        }

        [HttpPost("timSortDouble")]
        public ActionResult<double[]> TimSort([FromBody] double[] arr)
        {
            var sort = kernel.Get<ISort>();
            SortDistributor sd = new SortDistributor(sort);

            sd.Sort(arr);

            return arr;
        }

        [HttpPost("test")]
        public ActionResult<TimeSpan> Test(int N = 1000000)
        {
            string inputFile = "array.txt";
            string[] valuesArray;

            FileStream uploadFileStream = System.IO.File.OpenRead(inputFile);
            using (var sr = new StreamReader(uploadFileStream, Encoding.UTF8)) // what is the encoding of the text? 
            {
                var allText = sr.ReadToEnd(); // read all text into memory
                                              // TODO: Find most frequent word in allText
                                              // replace the word allText.Replace(oldValue, newValue, stringComparison)
                valuesArray = allText.Split(' ');

            }
            
            // Создаем массив int для хранения считанных значений
            int[] arr = new int[N];

            // Конвертируем каждое значение в int и сохраняем в массив
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(valuesArray[i]);
            }

            var sort = kernel.Get<ISort>();
            SortDistributor sd = new SortDistributor(sort);

            var sw = new Stopwatch();
            sw.Start();
            sd.Sort(arr);
            sw.Stop();

            return sw.Elapsed;
        }




        [HttpPost("timSortP")]
        public ActionResult<int[]> TimSortParallel([FromBody] int[] arr)
        {
            var sort = kernel.Get<ISort>();
            SortDistributor sd = new SortDistributor(sort);

            sd.SortParallel(arr);

            return arr;
        }

        [HttpPost("timSortParallelDouble")]
        public ActionResult<double[]> TimSortParallel([FromBody] double[] arr)
        {
            var sort = kernel.Get<ISort>();
            SortDistributor sd = new SortDistributor(sort);

            sd.SortParallel(arr);

            return arr;
        }

        [HttpPost("insertionSort")]
        public ActionResult<int[]> InsertionSort([FromBody] int[] arr)
        {
            var insertionSort = kernel.Get<InsertionSort>();
            insertionSort.Sort(arr);

            return arr;
        }

        [HttpPost("insertionSortDouble")]
        public ActionResult<double[]> InsertionSort([FromBody] double[] arr)
        {
            var insertionSort = kernel.Get<InsertionSort>();
            insertionSort.Sort(arr);

            return arr;
        }
    }
}
