using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Extensions;
using AllianceAssociationBank.Crm.Helpers;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CrmAutoMapperProfile : Profile
    {
        private const string CommaSeparator = ", ";

        public CrmAutoMapperProfile()
        {
            CreateMap<Project, ProjectFormViewModel>()
                .ReverseMap();

            CreateMap<Project, SearchResultViewModel>();

            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProjectName));

            CreateMap<ProjectUser, UserFormViewModel>();
            CreateMap<UserFormViewModel, ProjectUser>()
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore());

            CreateMap<CheckScanner, ScannerFormViewModel>()
                .ReverseMap();

            CreateMap<Note, NoteFormViewModel>();
            CreateMap<NoteFormViewModel, Note>()
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore());

            // Mappings used for reports
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
                    opt => opt.MapFrom(src => MapEmployeeName(src.AFP)))
                .ForMember(
                    dest => dest.CheckScannerModels,
                    opt => opt.MapFrom(src => src.CheckScanners
                                                 .JoinStringProperty(s => s.Model, ConcatenationSeparator.ForGenericList)))
                .ForMember(
                    dest => dest.CheckScannerSerialNumbers,
                    opt => opt.MapFrom(src => src.CheckScanners
                                                 .JoinStringProperty(s => s.SerialNumber, ConcatenationSeparator.ForGenericList)));

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

            CreateMap<Employee, EmployeeViewModel>()
                .ReverseMap();

            CreateMap<Aq2Reformat, ReformatViewModel>()
                .ReverseMap();

            CreateMap<Software, SoftwareViewModel>()
                .ReverseMap();

            // Default rule to map nullable boolean to boolean as false
            CreateMap<bool?, bool>().ConstructUsing(b => b ?? false);
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

        //private string ConcatenateStringProperty<T>(IEnumerable<T> list, Expression<Func<T, string>> expression) where T : class
        //{
        //    if (list == null)
        //    {
        //        return null;
        //    }

        //    var values = list
        //        .Select(expression.Compile())
        //        .Where(v => !string.IsNullOrEmpty(v));

        //    return string.Join(CommaSeparator, values);
        //}
    }
}