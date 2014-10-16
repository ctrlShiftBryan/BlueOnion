using BlueOnion.Domain.Model;
using System.Collections.Generic;

namespace BlueOnion.ViewModel.Common
{
    public class ListWithPageInfo<T>
    {
        public ListWithPageInfo()
        {
            List = new List<T>();
            PageInfo = new PageInfo();
            Columns = new List<ColumnData>();
        }

        public ListWithPageInfo(List<T> list, int top, int skip, long totalRecords)
        {
            List = list;
            PageInfo = new PageInfo(top, skip, totalRecords);
        }

        public List<T> List { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<ColumnData> Columns { get; set; }
    }
}