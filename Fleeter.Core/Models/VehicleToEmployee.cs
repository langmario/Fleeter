using Fleeter.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Models
{
    public class VehicleToEmployee : ISearchableEntity
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Vehicle? Vehicle { get; set; }
        public Employee? Employee { get; set; }
    }
}
