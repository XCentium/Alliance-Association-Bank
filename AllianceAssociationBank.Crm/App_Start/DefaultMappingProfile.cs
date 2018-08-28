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
            CreateMap<Project, ProjectReportRecordViewModel>();

            CreateMap<Project, ProjectFormViewModel>()
                .ReverseMap();

            CreateMap<ProjectUser, UserFormViewModel>()
                .ReverseMap();

            CreateMap<Collection<ProjectUser>, List<UserFormViewModel>>()
                .ReverseMap();
        }
    }
}