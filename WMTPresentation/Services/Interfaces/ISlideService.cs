using System.Collections.Generic;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Intarfaces
{
    public interface ISlideService
    {
        //CRUD
        void Create(Slide entity);
        List<SlideDto> Read();
        Slide Read(int id);
        List<Slide> ReadByChapterId(int chapterId);
        void Update(Slide entity);
        void Delete(int id);
    }
}
