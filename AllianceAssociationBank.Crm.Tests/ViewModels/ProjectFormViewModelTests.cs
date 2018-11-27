using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.ViewModels
{
    public class ProjectFormViewModelTests
    {
        public ProjectFormViewModelTests()
        {
        }

        [Fact]
        public void SetDefaults_NewProject_ShouldSetActiveValueToTrue()
        {
            var viewModel = new ProjectFormViewModel();

            viewModel.SetDefaults();

            Assert.True(viewModel.Active);
        }

        [Fact]
        public void SetDefaults_NewProject_ShouldSetStartDateToToday()
        {
            var viewModel = new ProjectFormViewModel();

            viewModel.SetDefaults();

            Assert.Equal(DateTime.Today, viewModel.StartDate);
        }
    }
}
