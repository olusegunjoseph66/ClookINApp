using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.ViewModels
{
    public class ClockinDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsStaff { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime GetTime { get; set; }
    }
}
