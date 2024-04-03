using AutoMapper;
using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Candidate;

namespace BackendDevEnTansito.DevEnTransito.Application.Services.Candidate
{
    public class CandidateService : ICandidateService
    {
        
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public CandidateService(ICandidateRepository candidateRepository  , IMapper mapper)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
            }

            //public async Task CreateCandidateAsync(CandidateDto candidateDto)
            //{
            //    var candidate = _mapper.Map<CandidateEntity>(candidateDto);
            //    await _candidateRepository.AddCandidateAsync(candidate);
            //}



        public async Task<string> CreateCandidateAsync(CandidateDto dto, IFormFile pdfFile)
        {
            // Validar el archivo PDF
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return "File is not valid";
            }

            // Guardar el archivo PDF en el servidor
            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "Pdfs", resumeUrl);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            // Crear un nuevo candidato
            var newCandidate = _mapper.Map<CandidateEntity>(dto);
            newCandidate.ResumeUrl = resumeUrl;

            // Guardar el candidato en la base de datos
            await _candidateRepository.AddCandidateAsync(newCandidate);

            return "Candidate Saved Successfully";
        }

        public async Task<CandidateDto> GetCandidateAsync(int candidateId)
            {
                var candidate = await _candidateRepository.GetCandidateAsync(candidateId);
                var candidateDto = _mapper.Map<CandidateDto>(candidate);
                return candidateDto;
            }

            public async Task DeleteCandidateAsync(int candidateId)
            {
                await _candidateRepository.DeleteCandidateAsync(candidateId);
            }

            public async Task<List<CandidateDto>> GetAllCandidatesAsync()
            {
                var listCandidates = await _candidateRepository.GetAllCandidatesAsync();
                var listCandidatesDto = _mapper.Map<List<CandidateDto>>(listCandidates);
                return listCandidatesDto;
            }
        }
    }

