﻿using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;

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

            CreateMap<Project, SearchResultViewModel>();

            CreateMap<Project, AchReportDataSetDto>()
                .ForMember(
                    dest => dest.OwnerName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.Owner)));

            CreateMap<Project, CmcReportDataSetDto>()
                .ForMember(
                    dest => dest.OwnerName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.Owner)))
                .ForMember(
                    dest => dest.AFPName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.AFP)));

            CreateMap<Project, ProjectReportDataSetDto>()
                .ForMember(
                    dest => dest.OwnerName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.Owner)))
                .ForMember(
                    dest => dest.AFPName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.AFP)));

            CreateMap<Project, IncorrectEmployeeDataSetDto>()
                .ForMember(
                    dest => dest.OwnerName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.Owner)))
                .ForMember(
                    dest => dest.AFPName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.AFP)))
                .ForMember(
                    dest => dest.BoardingManagerName,
                    opt => opt.MapFrom(src => MapEmployeeName(src.BoardingManager)));

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

        private string MapEmployeeName(Employee employee)
        {
            return employee != null ? $"{employee.FirstName} {employee.LastName}" : null;
        }
    }
}