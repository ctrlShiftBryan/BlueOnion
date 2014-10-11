using System;

namespace BlueOnion.Domain.Interfaces
{
    public interface IDeletable
    {
        DateTime? DeletedDate { get; set; }
        string DeletedBy { get; set; }
    }
}