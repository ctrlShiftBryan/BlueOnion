
using BlueOnion.ViewModel.Common;
using BlueOnion.ViewModel.Interfaces;
using System.Collections.Generic;


namespace BlueOnion.ViewModel
{
    public abstract class ViewModelBase<Dto, DDto, TId> : ViewModelNonGenericBase, IViewModelBase<Dto, DDto, TId>
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
    {
        public ViewModelBase()
        {
            List = new List<Dto>();
            Item = new Dto();
            ItemDetail = new DDto();
            PageInfo = new PageInfoDto();
            DefaultEditAction = EditAction = "InsertUpdate";
        }

        public List<Dto> List { get; set; }

        public Dto Item { get; set; }
        public DDto ItemDetail { get; set; }
        public PageInfoDto PageInfo { get; set; }

        public bool ItemDetailIsNew { get; set; }

        public override List<ColumnData> Columns
        {
            get
            {
                return ViewModelMeta.GetColumns(List);
            }
        }


        public abstract TId GetDefaultIdValue();
        public bool IsDynamicTable { get; set; }
        public bool OverrideConcurrencyError { get; set; }
        public string OpenDynamicId { get; set; }
        public bool ModalOpen { get; set; }
        public string EditAction { get; set; }
        public string DefaultEditAction { get; set; }
       

    }
}
