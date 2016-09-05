using System;
using System.Collections.Generic;
using System.Linq;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;
using WMTPresentation.Services.Intarfaces;
using WMTPresentation.Services.Extensions;

namespace WMTPresentation.Services
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public void Create(Slide entity)
        {
            try
            {
                if (entity == null) return;

                _slideRepository.Edit(entity);
            }
            catch (Exception)
            {
                return;
            }            
        }

        public List<Slide> ReadByChapterId(int id)
        {
            try
            {
                return _slideRepository.Query().Where(s => s.Chapter.Id == id).ToList();
            }
            catch (Exception)
            {
                return new List<Slide>();
            }
        }

        public List<SlideDto> Read()
        {
            try
            {
                var slides = _slideRepository.Query().ToList();

                List<SlideDto> slDto = new List<SlideDto>();

                foreach (var s in slides)
                {
                    slDto.Add(s.ToSlideDto());
                }

                return slDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Slide Read(int id)
        {
            try
            {
                var slide = _slideRepository.Get(id);

                if (slide != null)
                {
                    return slide;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public void Update(Slide entity)
        {
            try
            {
                if (entity == null) return;
                _slideRepository.Edit(entity);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var slide = _slideRepository.Get(id);
                if (slide != null)
                {
                    _slideRepository.Delete(slide);
                }
            }
            catch (Exception)
            {
                return;
            }            
        }
    }
}
