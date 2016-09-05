using Microsoft.EntityFrameworkCore;

namespace WMTPresentation.DataAccess.Interfaces
{
    public interface IDatabaseFactory
    {
        DbContext Get();
    }
}
