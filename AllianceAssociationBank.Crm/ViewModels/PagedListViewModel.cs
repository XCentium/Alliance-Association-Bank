using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class PagedListViewModel<T>
    {
        public int TotalItems { get; }

        public int PageSize { get; }

        public int PageNumber { get; }

        public bool ShowLastPage
        {
            get { return TotalPages > PageNumber; }
        }

        public bool ShowFirstPage
        {
            get { return PageNumber > 1; }
        }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(TotalItems / (double)PageSize); }
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }

        public int PreviousPageNumber
        {
            get { return HasPreviousPage ? PageNumber - 1 : 1; }
        }

        // Show this second previous page only when a user is at the end of pagination (the last page)
        public bool ShowSecondPreviousPage
        {
            get { return !HasNextPage && TotalPages > 2; }
        }

        public int SecondPreviousPageNumber
        {
            get { return (PreviousPageNumber - 1) > 0 ? (PreviousPageNumber - 1) : 1; }
        }

        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }

        public int NextPageNumber
        {
            get { return HasNextPage ? PageNumber + 1 : TotalPages; }
        }

        // Show this second next page only when a user is at the beginning of pagination (the first page)
        public bool ShowSecondNextPage
        {
            get { return !HasPreviousPage && TotalPages > 2; }
        }

        public int SecondNextPageNumber
        {
            get { return (NextPageNumber + 1) < TotalPages ? (NextPageNumber + 1) : TotalPages; }
        }

        public IEnumerable<T> Items { get; set; }


        public PagedListViewModel(IEnumerable<T> allItems, int pageNumber, int pageSize) 
            : this (allItems.AsQueryable(), pageNumber, pageSize)
        {
        }

        public PagedListViewModel(IQueryable<T> allItems, int pageNumber, int pageSize)
        {
            TotalItems = allItems.Count();
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = allItems
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize)
                        .ToList();
        }
    }
}