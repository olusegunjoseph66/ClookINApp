using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.Models
{
    public abstract class BaseEntity
    {
        public static int seed = new Random().Next(0, 1000000);
        public int Id { get; set; } = seed;
    }
    public partial class UserST : BaseEntity
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Department Department { get; set; } = null;
    }
}
