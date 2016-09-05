using System.Collections.Generic;
using System.Threading.Tasks;
using WMTPresentation.Entities;

namespace WMTPresentation.Services.Intarfaces
{
    public interface IHttpService
    {
        Task<string> GetToken(string email, string password);
        Task<Presentation> GetPresentationById(string id, string token);
        Task<List<Presentation>> GetPresentations(string token);
    }
}
