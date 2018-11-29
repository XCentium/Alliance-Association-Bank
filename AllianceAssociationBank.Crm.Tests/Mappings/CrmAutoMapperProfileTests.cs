using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Mappings
{
    public class CrmAutoMapperProfileTests
    {
        private IMapper _mapper;

        public CrmAutoMapperProfileTests()
        {
            _mapper = CrmAutoMapperProfile.GetMapper();
        }

        [Fact]
        public void MapToProjectDto_SingleProject_ShouldMapToProjectDtoCorrectly()
        {
            var project = new Project()
            {
                ID = 1,
                ProjectName = "Project 1"
            };

            var projectDto = _mapper.Map<ProjectDto>(project);

            Assert.Equal(project.ID, projectDto.Id);
            Assert.Equal(project.ProjectName, projectDto.Name);
        }

        //[Fact]
        //public void ProjectToProjectDto_ProjectIQueryable_ShouldReturnCorrectProjectDtoIQueryable()
        //{
        //    var projects = new List<Project>()
        //    {
        //        new Project() { ID = 1, ProjectName = "Project 1" },
        //        new Project() { ID = 2, ProjectName = "Project 2" }
        //    }.AsQueryable();

        //    var projectDtos = projects.ProjectTo<ProjectDto>(_mapper.ConfigurationProvider);

        //}
    }
}
