using AutoMapper;
using Backend_Crypto.Dto;
using Backend_Crypto.Models;

namespace Backend_Crypto.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Crypto,CryptoDto>();
            CreateMap<HistoriquePrix,HistoriqueDto>();
            CreateMap<CryptoUpdateDto, Crypto>();
        }
    }
}
