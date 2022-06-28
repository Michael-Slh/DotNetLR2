﻿namespace Model
{
    public class Bus
    {
        public Guid Id { get; init; }
        public string? Number { get; init; }
        public List<Course> Courses { get; init; } = new List<Course>();
        public override string ToString()
        {
            return "Bus number " + Number;
        }
    }
}
