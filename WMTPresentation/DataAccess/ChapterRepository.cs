using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess
{
    public class ChapterRepository : Repository<Chapter>, IChapterRepository
    {
        public ChapterRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
