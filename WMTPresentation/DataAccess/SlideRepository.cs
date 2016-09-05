using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess
{
    public class SlideRepository : Repository<Slide>, ISlideRepository
    {
        public SlideRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
