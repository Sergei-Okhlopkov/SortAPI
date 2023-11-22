using Microsoft.AspNetCore.Mvc;
using Ninject;
using System.Reflection;

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
