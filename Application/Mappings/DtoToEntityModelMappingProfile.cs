﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Mappings
{
    public class DtoToEntityModelMappingProfile :  Profile
    {
        public DtoToEntityModelMappingProfile() 
        {
            CreateMap<Domain.DTOs.ClientDto, Domain.Entity.ClientEntity>()
                .ForPath(entityClient => entityClient.ClientContactInfoEntity.Address,
                    opt => opt.MapFrom(dtoClient => dtoClient.Address))

                .ForPath(entityClient => entityClient.ClientContactInfoEntity.PhoneNumber,
                    opt => opt.MapFrom(dtoClient => dtoClient.PhoneNumber))

                .ForPath(entityClient => entityClient.ClientContactInfoEntity.Email,
                    opt => opt.MapFrom(dtoClient => dtoClient.Email));


            CreateMap<Domain.DTOs.CarDto, Domain.Entity.CarEntity>();
        }
    }
}
