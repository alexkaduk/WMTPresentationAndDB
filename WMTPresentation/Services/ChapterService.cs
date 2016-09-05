using System;
using System.Collections.Generic;
using System.Linq;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;
using WMTPresentation.Services.Extensions;
using WMTPresentation.Services.Intarfaces;

namespace WMTPresentation.Services
{
    public class ChapterService : IChapterService
    {
        
        private readonly IChapterRepository _chapterRepository;
        private readonly ISlideService _slideSetvice;

        public ChapterService(IChapterRepository chapterRepository, ISlideService slideService)
        {
            _chapterRepository = chapterRepository;
            _slideSetvice = slideService;
        }

        public void Create(Chapter entity)
        {
            try
            {
                if (entity == null) return;

                _chapterRepository.Edit(entity);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public List<ChapterDto> Read()
        {
            try
            {
                var chapters = _chapterRepository.Query().ToList();

                List<ChapterDto> chDto = new List<ChapterDto>();

                foreach (var c in chapters)
                {
                    c.Slides = _slideSetvice.ReadByChapterId(c.Id);
                    chDto.Add(c.ToChapterDto(c.PresentationId));
                }

                return chDto;
            }
            catch (Exception ex)
            {
                return new List<ChapterDto>();
            }
        }

        public List<Chapter> ReadByPresentationId(int id)
        {
            try
            {
                return _chapterRepository.Query().Where(c => c.Presentation.Id == id).ToList();
            }
            catch (Exception)
            {
                return new List<Chapter>();
            }
        }

        public Chapter Read(int id)
        {
            try
            {
                var chapter = _chapterRepository.Get(id);

                if (chapter != null)
                {
                    return chapter;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update(Chapter entity)
        {
            try
            {
                if (entity == null) return;
                _chapterRepository.Edit(entity);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var chapter = _chapterRepository.Get(id);
                if (chapter != null)
                {
                    _chapterRepository.Delete(chapter);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

