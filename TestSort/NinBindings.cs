using Ninject.Modules;

namespace TestSort
{
    public class NinBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISort>().To<TimSort>();
        }
    }
}
