using System;

namespace BlueOnion.Domain.Interfaces
{
    public interface IModifiable
    {
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}