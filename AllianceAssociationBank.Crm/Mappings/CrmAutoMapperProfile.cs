﻿using AllianceAssociationBank.Crm.Core.Dtos;
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

            CreateMap<Project, AchReportDatasetDto>()
                .ForMember(
                    dest => dest.OwnerName, 
                    opt => opt.MapFrom(src => src.Owner == null ? null : $"{src.Owner.FirstName} {src.Owner.LastName}")
                 );

            CreateMap<ProjectUser, UserFormViewModel>();
            CreateMap<UserFormViewModel, ProjectUser>()
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore());

            CreateMap<CheckScanner, ScannerFormViewModel>()
                .ReverseMap();

            CreateMap<Note, NoteFormViewModel>();
            CreateMap<NoteFormViewModel, Note>()
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore());
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