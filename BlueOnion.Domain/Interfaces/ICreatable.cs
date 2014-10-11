using System;

namespace BlueOnion.Domain.Interfaces
{
    public interface ICreateable
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}