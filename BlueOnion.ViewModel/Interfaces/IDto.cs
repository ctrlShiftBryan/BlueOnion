namespace BlueOnion.ViewModel.Interfaces
{
    public interface IDto<TId>
    {
        TId Id { get; set; }
        string ClientId { get; set; }
    }
}