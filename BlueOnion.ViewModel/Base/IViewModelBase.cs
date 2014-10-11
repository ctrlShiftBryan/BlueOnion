
using BlueOnion.Domain.Interfaces;
using BlueOnion.ViewModel.Interfaces;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    public interface IViewModelBase<DTO, DDTO, TId>
        where DTO : class, IDto<TId>
        where DDTO : class, IDto<TId>
    {
        List<DTO> List { get; set; }
        SimpleModelState ModelState { get; set; }
        int StatusCode { get; set; }
        string RedirectResponse { get; set; }
        string Message { get; set; }
        DTO Item { get; set; }
        DDTO ItemDetail { get; set; }
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