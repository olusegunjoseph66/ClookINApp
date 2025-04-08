﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.ViewModels
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
}
