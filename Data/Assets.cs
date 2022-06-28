﻿using Model;

namespace Data
{
    public class Assets
    {
        public IEnumerable<Bus>? Buses { get; set; }
        public IEnumerable<Course>? Courses { get; init; }
        public IEnumerable<Company>? Companies { get; init; }
        public IEnumerable<BusCourse>? BusCourses { get; init; }
    }
}
