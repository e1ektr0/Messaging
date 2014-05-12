using Ninject;

namespace Shared.IoC
{
    /// <summary>
    /// Сервис-локатор
    /// </summary>
    public class IoC
    {
        private static IKernel _kernel;

        public static IKernel Instance
        {
            get { return _kernel ?? (_kernel = new StandardKernel()); }
        }
    }
}