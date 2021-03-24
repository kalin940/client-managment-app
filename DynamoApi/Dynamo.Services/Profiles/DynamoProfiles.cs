using AutoMapper;
using Dynamo.Core.Db;
using System;
using System.Collections.Generic;
using System.Text;
using Dynamo.Common.DTOs;

namespace Dynamo.Services.Profiles
{
    public class DynamoProfiles : Profile
    {
        public DynamoProfiles()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<ContactSlimDTO, Contact>().ForMember(dest => dest.User, opt => opt.MapFrom( src =>    
                           new User() { Age = src.Age, CountryID = src.CountryID, Email = src.Email, Name = src.Name}
                ));
        }
    }
}
