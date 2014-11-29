
using BlueOnion.Domain.Interfaces;
using BlueOnion.ViewModel.Common;
using BlueOnion.ViewModel.Interfaces;
using System;
using System.Collections.Generic;

namespace BlueOnion.ViewModel
{
    public interface IViewModelBase<Dto, DDto, TId>
        where Dto : class, IDto<TId>
        where DDto : class, IDto<TId>
    {
        List<Dto> List { get; set; }
        SimpleModelState ModelState { get; set; }
        int StatusCode { get; set; }
        string RedirectResponse { get; set; }
        string Message { get; set; }
        Dto Item { get; set; }
        DDto ItemDetail { get; set; }
        List<string> Meta { get; set; }
        List<ColumnData> Columns { get; }
        KOMapping KOMapping { get; set; }
        string ToJson();
        List<string> OnlyValidateFields { get; set; }
        bool ItemDetailIsNew { get; set;  }
        string Title { get; set; }
        IUser<Guid> User { get; set; }
    }
}