using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMachinePark.Shared.Domain
{
    public class Machine
    {
        [Key] public Guid Id { get; set; } // GUID as pk
        public bool IsRunning { get; set; }

        [Required] public City City { get; set; } // Nav-prop
        public int CityId { get; set; } 

        [Required] public MachineType MachineType { get; set; } // Nav-prop
        public int MachineTypeId { get; set; }

        public Machine()
        {
            Id = Guid.NewGuid(); // Automatically generate GUID when creating a new machine.
        }
    }
}