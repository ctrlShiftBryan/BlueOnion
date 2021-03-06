﻿using BlueOnion.ViewModel.Interfaces;
using System;

namespace BlueOnion.ViewModel
{
    public class PageInfoDto : DtoBase, IDto<Guid>
    {
        public Guid Id { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }

        public string Page1 { get; set; }
        public string Page2 { get; set; }
        public string Page3 { get; set; }
        public string Page4 { get; set; }
        public string Page5 { get; set; }
    }
}