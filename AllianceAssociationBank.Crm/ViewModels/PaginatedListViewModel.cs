using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class PaginatedListViewModel<T>
    {
        public int TotalItems { get; }

        public int PageSize { get; }

        public int PageNumber { get; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)(TotalItems / PageSize)); }
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }

        public int PreviousPageNumber
        {
            get { return HasPreviousPage ? PageNumber - 1 : 1; }
        }

        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }

        public int NextPageNumber
        {
            get { return HasNextPage ? PageNumber + 1 : TotalPages; }
        }

        public IEnumerable<T> Items { get; set; }


        public PaginatedListViewModel(IEnumerable<T> allItems, int pageSize, int pageNumber)
        {
            //pageSize = pageSize < 1 ? 5 : pageSize;
            //pageNumber = pageNumber < 1 ? 1 : pageNumber;

            TotalItems = allItems.Count();
            PageSize = pageSize;
            PageNumber = pageNumber;
            Items = allItems
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize)
                        .ToList();
        }
    }
}