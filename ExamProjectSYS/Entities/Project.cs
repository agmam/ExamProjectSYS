﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentNumber { get; set; }
    }
}
