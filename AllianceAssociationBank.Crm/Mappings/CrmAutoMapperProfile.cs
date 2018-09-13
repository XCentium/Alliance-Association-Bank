using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CrmAutoMapperProfile : Profile
    {
        public CrmAutoMapperProfile()
        {
            CreateMap<Project, ProjectFormViewModel>()
                .ReverseMap();

            CreateMap<ProjectUser, UserFormViewModel>();
            CreateMap<UserFormViewModel, ProjectUser>()
                .ForMember(u => u.DateAdded, o => o.Ignore())
                .ForMember(u => u.DateDeleted, o => o.Ignore());

            CreateMap<List<ProjectUser>, List<UserFormViewModel>>()
                .ReverseMap();

            CreateMap<CheckScanner, ScannerFormViewModel>()
                .ReverseMap();
        }

        public static IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CrmAutoMapperProfile>();
            }).CreateMapper();
        }
    }
}