using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Models;
using AutoMapper;

namespace api.crosscutting.Mappings
{
    public class DtoModelProfiles : Profile
    {

        public DtoModelProfiles()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();

            
            CreateMap<UfModel, UfEntity>().ReverseMap();
            CreateMap<UfDto, UfEntity>().ReverseMap();
            CreateMap<UfModel, UfDto>().ReverseMap();
            
            CreateMap<MunicipioModel, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioCompletoDto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioCreateResultDto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDto>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>().ReverseMap();


            CreateMap<CepModel, CepEntity>().ReverseMap();
            CreateMap<CepModel, CepDto>().ReverseMap();
            CreateMap<CepModel, CepDtoCreate>().ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
            CreateMap<CepDto, CepEntity>().ReverseMap();
            CreateMap<CepDtoCreateResult, CepEntity>().ReverseMap();
            CreateMap<CepDtoUpdateResult, CepEntity>().ReverseMap();
            

        }

    }
}