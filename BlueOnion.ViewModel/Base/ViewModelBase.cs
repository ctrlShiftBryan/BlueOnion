
using BlueOnion.ViewModel.DTO.PageInfo;
using BlueOnion.ViewModel.Interfaces;
using System.Collections.Generic;

namespace ViewModel
{
    public abstract class ViewModelBase<DTO, DDTO, TId> : ViewModelNonGenericBase, IViewModelBase<DTO, DDTO, TId>
        where DTO : class, IDto<TId>, new()
        where DDTO : class, IDto<TId>, new()
    {
        public ViewModelBase()
        {
            List = new List<DTO>();
            Item = new DTO();
            ItemDetail = new DDTO();
            PageInfo = new PageInfoDto();
            DefaultEditAction = EditAction = "InsertUpdate";
        }

        public List<DTO> List { get; set; }

        public DTO Item { get; set; }
        public DDTO ItemDetail { get; set; }
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
