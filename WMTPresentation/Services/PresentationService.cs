using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;
using WMTPresentation.Services.Intarfaces;
using WMTPresentation.Services.Extensions;

namespace WMTPresentation.Services
{
    class PresentationService : IPresentationService
    {
        private readonly IPresentationRepository _presentationRepository;
        private readonly IChapterService _chapterService;

        public PresentationService(IPresentationRepository presentationRepository, IChapterService chapterService)
        {
            _presentationRepository = presentationRepository;
            _chapterService = chapterService;
        }

        public void Create(Presentation entity)
        {
            try
            {
                if (entity == null) return;

                _presentationRepository.Edit(entity);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void CreateList(List<Presentation> entities)
        {
            try
            {
                if (entities == null) return;

                foreach(var entity in entities)
                {
                    _presentationRepository.Edit(entity);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public PresentationDto Read(int id)
        {
            try
            {
                var presentation = _presentationRepository.Get(id);

                if (presentation != null)
                {
                    presentation.Chapters = _chapterService.ReadByPresentationId(id);
                    return presentation.ToPresentationDto();
                }

                return new PresentationDto();
            }
            catch (Exception)
            {
                return new PresentationDto();
            }
        }

        public List<PresentationDto> Read()
        {
            try
            {
                var presentations = _presentationRepository.Query().ToList();
                List<PresentationDto> psDto = new List<PresentationDto>();

                foreach (var p in presentations)
                {
                    p.Chapters = _chapterService.ReadByPresentationId(p.Id);
                    psDto.Add(p.ToPresentationDto());
                }
                
                return psDto;
            }
            catch (Exception)
            {
                return new List<PresentationDto>(); ;
            }
        }

        public void Update(Presentation entity)
        {
            try
            {
                if (entity == null) return;
                _presentationRepository.Edit(entity);
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
                var presentation = _presentationRepository.Get(id);
                if (presentation != null)
                {
                    _presentationRepository.Delete(presentation);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }

}
