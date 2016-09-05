using System.Collections.Generic;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Intarfaces
{
    public interface IChapterService
    {
        //CRUD
        void Create(Chapter entity);
        List<ChapterDto> Read();
        Chapter Read(int id);
        List<Chapter> ReadByPresentationId(int id);
        void Update(Chapter entity);
        void Delete(int id);
    }
}
