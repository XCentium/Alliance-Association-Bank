using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Search;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Persistence.Enums;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class SearchControllerTests
    {
        private SearchController _controller;
        private Mock<IProjectRepository> _mockProjectRepository;
        private IMapper _mapper;

        private List<Project> _projects;

        public SearchControllerTests()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new SearchController(_mockProjectRepository.Object, _mapper);

            _projects = new List<Project>()
            {
                new Project() { ID = 1, ProjectName = "Project Name 1" }
            };

        }

        [Fact]
        public void Results_ValidSearchTerm_ShouldReturnViewResultModelWithItems()
        {
            var term = "project";
            _mockProjectRepository.Setup(r => r.GetProjectsBySearchTerm(term, SortOrder.Ascending)).Returns(_projects.AsQueryable());

            var result = _controller.Results(term);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<SearchResultsPagedViewModel>(viewResult.Model);
            Assert.Equal(_projects.Count(), model.Items.Count());
        }

        [Fact]
        public void Results_NotValidSearchTerm_ShouldReturnViewResultModelWithNoItems()
        {
            var term = "abcde";
            _mockProjectRepository.Setup(r => r.GetProjectsBySearchTerm(term, SortOrder.Ascending)).Returns(new List<Project>().AsQueryable());

            var result = _controller.Results(term);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<SearchResultsPagedViewModel>(viewResult.Model);
            Assert.Empty(model.Items);
        }

        [Fact]
        public void Results_ValidSearchTermWithPreviousId_ShouldReturnViewResultModelWithPreviousRecordId()
        {
            var term = "project";
            var projectId = 999;
            _mockProjectRepository.Setup(r => r.GetProjectsBySearchTerm(term, SortOrder.Ascending)).Returns(_projects.AsQueryable());

            var result = _controller.Results(term, 1, SortOrderString.Ascending, projectId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<SearchResultsPagedViewModel>(viewResult.Model);
            Assert.NotNull(model.PreviousRecordId);
        }
    }
}
