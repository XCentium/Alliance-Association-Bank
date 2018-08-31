using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.App_Start
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            //CreateMap<Project, ProjectReportRecordViewModel>();

            CreateMap<Project, ProjectFormViewModel>()
                .ReverseMap();

            CreateMap<ProjectUser, UserFormViewModel>();
            CreateMap<UserFormViewModel, ProjectUser>()
                .ForMember(u => u.DateAdded, o => o.Ignore())
                .ForMember(u => u.DateDeleted, o => o.Ignore());

            CreateMap<List<ProjectUser>, List<UserFormViewModel>>()
                .ReverseMap();
        }
    }
}