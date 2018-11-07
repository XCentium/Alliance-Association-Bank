using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Extensions;
using AllianceAssociationBank.Crm.ViewModels;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Extensions
{
    public class HtmlHelperEditorExtensionsTests
    {
        private HtmlHelper<ProjectFormViewModel> htmlHelper;

        private Mock<ViewContext> mockViewContext;
        private Mock<IViewDataContainer> mockViewDataContainer;

        private string disabledAttribute = @"disabled=""disabled""";
        public HtmlHelperEditorExtensionsTests()
        {
            var viewData = new ViewDataDictionary<ProjectFormViewModel>(new ProjectFormViewModel());

            //mockViewContext = new Mock<ViewContext>(
            //    new Mock<ControllerContext>().Object,
            //    new Mock<IView>().Object,
            //    viewData,
            //    new TempDataDictionary(),
            //    new StreamWriter(new MemoryStream()));
            mockViewContext = new Mock<ViewContext> { CallBase = true };
            mockViewContext.SetupGet(c => c.ViewData).Returns(viewData);
            //mockViewContext.Setup(c => c.HttpContext.Items).Returns(new Hashtable());

            var test = mockViewContext.Object.ViewData;

            mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer.SetupGet(v => v.ViewData).Returns(viewData);

            var test2 = mockViewDataContainer.Object.ViewData;

            htmlHelper = new HtmlHelper<ProjectFormViewModel>(mockViewContext.Object, mockViewDataContainer.Object);
        }

        [Fact]
        public void RoleBasedEditorFor_UserWithReadWriteRole_ShouldReturnHtmlStringWithoutDisabledAttribute()
        {
            SetupUserRoleForViewContextMock(mockViewContext, UserRole.ReadWriteUser);


            //var result = htmlHelper.EditorFor(e => e.ProjectName);
            var result = htmlHelper.RoleBasedEditorFor(e => e.ProjectName, "abc");

            Assert.DoesNotContain(disabledAttribute, result.ToString());
        }

        [Fact]
        public void RoleBasedEditorFor_UserWithReadOnlyRole_ShouldReturnHtmlStringWithDisabledAttribute()
        {
            SetupUserRoleForViewContextMock(mockViewContext, UserRole.ReadOnlyUser);
            
            var result = htmlHelper.RoleBasedEditorFor(e => e.ProjectName, null);

            Assert.Contains(disabledAttribute, result.ToString());
        }

        private void SetupUserRoleForViewContextMock(Mock<ViewContext> viewContextMock, string userRole)
        {
            viewContextMock.Setup(c => c.HttpContext.User.IsInRole(userRole)).Returns(true);
        }
    }
}
