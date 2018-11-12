using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.ViewModels
{
    public class PagedListViewModelTests
    {
        private const int _defaultPageSize = 10;
        private const int _defaultNumberOfItems = 100;

        public PagedListViewModelTests()
        {
        }

        [Theory]
        [InlineData(10, 100)]
        [InlineData(2, 100)]
        [InlineData(100, 100)]
        [InlineData(100, 60)]
        public void PagedListViewModel_Items_ShouldSetItemsBasedOnPageSize(int pageSize, int numberOfItems)
        {
            var items = GetListOfItems(numberOfItems);
            var expectedNumberOfItems = pageSize > numberOfItems ? numberOfItems : pageSize;

            var viewModel = new PagedListViewModel<string>(items, 1, pageSize);

            Assert.Equal(numberOfItems, viewModel.TotalItems);
            Assert.Equal(expectedNumberOfItems, viewModel.Items.Count());
        }

        [Theory]
        [InlineData(10, 100, 10)]
        [InlineData(10, 11, 2)]
        [InlineData(10, 19, 2)]
        [InlineData(5, 11, 3)]
        [InlineData(5, 16, 4)]
        public void PagedListViewModel_TotalPages_ShouldSetTotalPagesCorrectly(int pageSize, int numberOfItems, int expectedNumberOfPages)
        {
            var pageNumber = 1;
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.Equal(pageNumber, viewModel.PageNumber);
            Assert.Equal(expectedNumberOfPages, viewModel.TotalPages);
        }

        [Theory]
        [InlineData(10, 100, 2)]
        [InlineData(10, 100, 5)]
        [InlineData(10, 100, 10)]
        public void PagedListViewModel_ShowFirstPage_ShouldReturnTrue(int pageSize, int numberOfItems, int pageNumber)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.True(viewModel.ShowFirstPage);
        }

        [Theory]
        [InlineData(10, 100, 1)]
        [InlineData(10, 100, 5)]
        [InlineData(10, 100, 9)]
        public void PagedListViewModel_ShowLastPage_ShouldReturnTrue(int pageSize, int numberOfItems, int pageNumber)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.True(viewModel.ShowLastPage);
        }

        [Theory]
        [InlineData(10, 100, 2, true)]
        [InlineData(10, 100, 1, false)]
        [InlineData(10, 100, 99, true)]
        [InlineData(10, 10, 1, false)]
        public void PagedListViewModel_HasPreviousPage_ShouldCalculatePreviousPageCorrectly(int pageSize, 
                                                                                            int numberOfItems, 
                                                                                            int pageNumber, 
                                                                                            bool expectedHasPreviousPage)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.Equal(expectedHasPreviousPage, viewModel.HasPreviousPage);
            Assert.Equal((viewModel.HasPreviousPage ? pageNumber - 1 : 1), viewModel.PreviousPageNumber);
        }

        [Theory]
        [InlineData(10, 100, 1, true)]
        [InlineData(10, 10, 1, false)]
        [InlineData(10, 100, 5, true)]
        [InlineData(10, 100, 10, false)]
        public void PagedListViewModel_HasNextPage_ShouldCalculateNextPageCorrectly(int pageSize,
                                                                                    int numberOfItems,
                                                                                    int pageNumber,
                                                                                    bool expectedHasNextPage)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.Equal(expectedHasNextPage, viewModel.HasNextPage);
            Assert.Equal((viewModel.HasNextPage ? pageNumber + 1 : viewModel.TotalPages), viewModel.NextPageNumber);
        }

        [Theory]
        [InlineData(10, 100, 10, true, 8)]
        [InlineData(10, 100, 1, false, 0)]
        [InlineData(10, 100, 9, false, 0)]
        public void PagedListViewModel_ShowSecondPreviousPage_ShouldCalculateSecondPreviousPageCorrectly(int pageSize,
                                                                                                         int numberOfItems,
                                                                                                         int pageNumber,
                                                                                                         bool expectedShowSecondPreviousPage,
                                                                                                         int expectedSecondPreviousPage)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.Equal(expectedShowSecondPreviousPage, viewModel.ShowSecondPreviousPage);
            if (viewModel.ShowSecondPreviousPage)
            {
                Assert.Equal(expectedSecondPreviousPage, viewModel.SecondPreviousPageNumber);
            }
        }

        [Theory]
        [InlineData(10, 100, 1, true, 3)]
        [InlineData(10, 100, 2, false, 0)]
        [InlineData(10, 100, 8, false, 0)]
        public void PagedListViewModel_ShowSecondNextPage_ShouldCalculateSecondNextPageCorrectly(int pageSize,
                                                                                                 int numberOfItems,
                                                                                                 int pageNumber,
                                                                                                 bool expectedShowSecondNextPage,
                                                                                                 int expectedSecondNextPage)
        {
            var items = GetListOfItems(numberOfItems);

            var viewModel = new PagedListViewModel<string>(items, pageNumber, pageSize);

            Assert.Equal(expectedShowSecondNextPage, viewModel.ShowSecondNextPage);
            if (viewModel.ShowSecondNextPage)
            {
                Assert.Equal(expectedSecondNextPage, viewModel.SecondNextPageNumber);
            }
        }

        private IQueryable<string> GetListOfItems(int numberOfItems)
        {
            var list = new List<string>();

            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add($"Item {i}");

            }

            return list.AsQueryable();
        }
    }
}
