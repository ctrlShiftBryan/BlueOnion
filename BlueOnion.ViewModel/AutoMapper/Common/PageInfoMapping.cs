using AutoMapper;
using BlueOnion.Domain.Model;
using BlueOnion.ViewModel.Dto;

namespace BlueOnion.ViewModel.AutoMapper
{
    public static class PageInfoMapping
    {
        public static void Map()
        {
            Mapper.CreateMap<PageInfo, PageInfoDto>();
        }
    }
}