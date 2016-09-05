using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess
{
    class PresentationRepository : Repository<Presentation>, IPresentationRepository
    {
        public PresentationRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
