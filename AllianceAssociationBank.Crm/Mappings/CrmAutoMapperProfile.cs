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
            // Default rule to map nullable boolean to boolean as false
            CreateMap<bool?, bool>().ConstructUsing(b => b ?? false);

            CreateMap<Project, ProjectFormViewModel>()
                .ReverseMap();

            //CreateMap<Project, ProjectDto>();

            CreateMap<ProjectUser, UserFormViewModel>();
            CreateMap<UserFormViewModel, ProjectUser>()
                .ForMember(u => u.DateAdded, o => o.Ignore())
                .ForMember(u => u.DateDeleted, o => o.Ignore());

            CreateMap<CheckScanner, ScannerFormViewModel>()
                .ReverseMap();

            CreateMap<Note, NoteFormViewModel>();
            CreateMap<NoteFormViewModel, Note>()
                .ForMember(n => n.DateAdded, o => o.Ignore());
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