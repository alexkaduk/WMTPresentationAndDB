using Ninject;
using WMTPresentation.DataAccess;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Services;
using WMTPresentation.Services.Intarfaces;

namespace WMTPresentation.Common
{
    public class NinjectContainer
    {
        public static IKernel kernel;

        static NinjectContainer()
        {
            kernel = new StandardKernel();

            #region Repositories
            kernel.Bind<IPresentationRepository>().To<PresentationRepository>();
            kernel.Bind<IChapterRepository>().To<ChapterRepository>();
            kernel.Bind<ISlideRepository>().To<SlideRepository>();
            #endregion

            #region Services
            kernel.Bind<IPresentationService>().To<PresentationService>();
            kernel.Bind<IChapterService>().To<ChapterService>();
            kernel.Bind<ISlideService>().To<SlideService>();
            kernel.Bind<IHttpService>().To<HttpService>();
            #endregion

            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>();
        }
        public static IKernel CreateKernel()
        {
            return kernel;
        }

        public static T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}
