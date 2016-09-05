using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Intarfaces
{
    public interface IPresentationService
    {
        //CRUD
        void Create(Presentation entity);
        void CreateList(List<Presentation> entities);
        List<PresentationDto> Read();
        PresentationDto Read(int id);
        void Update(Presentation entity);
        void Delete(int id);
    }
}
