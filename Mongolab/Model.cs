using System;
using System.Collections.Generic;

namespace Mongolab.Models
{

    public class ComponentUsed
    {
        public Guid id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public double QuantityUsed { get; set; }
    }
    public class Experiment
    {
        public Guid id { get; } = Guid.NewGuid();
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public string Name { get; set; }

        public List<ComponentUsed> ComponentUsed;

        public string Procedure { get; set; }
    }

}
