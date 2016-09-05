using Microsoft.EntityFrameworkCore;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess
{ 
    public class DatabaseFactory : IDatabaseFactory
    {
        private DbContext _dataContext;

        public DbContext Get()
        {
            return _dataContext ?? (_dataContext = new PresentationDbContex());
        }
    }
}
