using System;
using System.Collections.Generic;

namespace BlueOnion.ViewModel.Interfaces
{
    public class ServiceQueryParameters<T>
    {
        public ServiceQueryParameters()
        {
            Statuses = new List<string>() { };
            DateTime = DateTime.Now;
        }
        public List<string> Statuses { get; set; }
        public DateTime DateTime { get; set; }
        public object Options { get; set; }
        public string Search { get; set; }
        public int Id { get; set; }
    }
}