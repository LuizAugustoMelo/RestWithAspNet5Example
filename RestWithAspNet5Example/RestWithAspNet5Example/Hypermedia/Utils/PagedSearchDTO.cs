﻿using RestWithAspNet5Example.Hypermedia.Abstract;

namespace RestWithAspNet5Example.Hypermedia.Utils
{
    public class PagedSearchDTO<T> where T : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirections { get; set; }
        public Dictionary<string, object> Filters { get; set; }

        public List<T> Values { get; set; }

        public PagedSearchDTO()
        {

        }

        public PagedSearchDTO(int currentPage, int pageSize, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchDTO(int currentPage, string sortFields, string sortDirections) : this(currentPage, 10, sortFields, sortDirections) { }

        public PagedSearchDTO(int currentPage, int pageSize, string sortFields, string sortDirections, Dictionary<string, object> filters) : this(currentPage, pageSize, sortFields, sortDirections)
        {
            Filters = filters;
        }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}
