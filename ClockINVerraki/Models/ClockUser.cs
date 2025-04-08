using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.Models
{
    public partial class ClockUser : BaseEntity
    {
        public int UserId { get; set; }
        public bool IsStaff { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime GetTime { get; set; }
    }
}
