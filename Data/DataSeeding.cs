﻿using Model;

namespace Data
{
    static public class DataSeeding
    {
        public static Assets GetData()
        {
            // companies
            var comp1 = new Company { Id = Guid.NewGuid(), Name = "Zhytomyr buses" };
            var comp2 = new Company { Id = Guid.NewGuid(), Name = "Zhytomyr travel" };
            var comp3 = new Company { Id = Guid.NewGuid(), Name = "One way to Zhytomyr" };
            var comp4 = new Company { Id = Guid.NewGuid(), Name = "Public transport" };

            var companies = new List<Company> { comp1, comp2, comp3, comp4 };

            // points
            var point1 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Kyivska"
            };

            var point2 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Nebesnoi sotni"
            };

            var point3 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Mykhailivska"
            };

            var point4 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Ploscha Peremogy"
            };

            var point5 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Lesy Ukrainki"
            };

            var point6 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Schevchenka"
            };

            var point7 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Dombrovskogo"
            };

            var point8 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Gruschevskogo"
            };

            var point9 = new BusStop
            {
                Id = Guid.NewGuid(),
                Name = "Chehova"
            };

            // routes
            var route1 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "3",
                Company = comp1,
                FirstStop = point1,
                LastStop = point2,
                Duration = 1
            };
            comp1.Courses.Add(route1);

            var route2 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "33",
                Company = comp2,
                FirstStop = point3,
                LastStop = point4,
                Duration = 1.5
            };
            comp2.Courses.Add(route2);

            var route3 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "223",
                Company = comp4,
                FirstStop = point5,
                LastStop = point6,
                Duration = 0.7
            };
            comp4.Courses.Add(route3);

            var route4 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "99",
                Company = comp3,
                FirstStop = point7,
                LastStop = point8,
                Duration = 0.8
            };
            comp3.Courses.Add(route4);

            var route5 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "41",
                Company = comp1,
                FirstStop = point7,
                LastStop = point5,
                Duration = 0.3
            };
            comp1.Courses.Add(route5);

            var route6 = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "24",
                Company = comp1,
                FirstStop = point5,
                LastStop = point9,
                Duration = 1.2
            };
            comp1.Courses.Add(route6);

            var routes = new List<Course> { route1, route2, route3, route4, route5, route6 };

            // buses
            var bus1 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AC 1234 AA",
                Courses = new List<Course> { route1, route5, route6 }
            };
            route1.Buses.Add(bus1);

            var bus2 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AA 1221 AA",
                Courses = new List<Course> { route1, route5, route6 }
            };
            route5.Buses.Add(bus2);

            var bus3 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AC 3782 AA",
                Courses = new List<Course> { route1, route5, route6 }
            };
            route5.Buses.Add(bus3);

            var bus4 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BO 7591 AA",
                Courses = new List<Course> { route1, route5, route6 }
            };
            route6.Buses.Add(bus4);

            var bus5 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BO 1940 AA",
                Courses = new List<Course> { route1, route5, route6 }
            };
            route6.Buses.Add(bus5);

            var bus6 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BB 1001 AA",
                Courses = new List<Course> { route2 }
            };
            route2.Buses.Add(bus6);

            var bus7 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AM 2958 AA",
                Courses = new List<Course> { route2 }
            };
            route2.Buses.Add(bus7);

            var bus8 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AM 0593 AA",
                Courses = new List<Course> { route2 }
            };
            route2.Buses.Add(bus8);

            var bus9 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AA 4664 AA",
                Courses = new List<Course> { route3 }
            };
            route3.Buses.Add(bus9);

            var bus10 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AM 2059 AA",
                Courses = new List<Course> { route3 }
            };
            route3.Buses.Add(bus10);

            var bus11 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BE 3987 AA",
                Courses = new List<Course> { route3 }
            };
            route3.Buses.Add(bus11);

            var bus12 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BI 4660 AA",
                Courses = new List<Course> { route3 }
            };
            route3.Buses.Add(bus12);

            var bus13 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "BI 4774 AA",
                Courses = new List<Course> { route4 }
            };
            route4.Buses.Add(bus13);

            var bus14 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AM 4772 AA",
                Courses = new List<Course> { route4 }
            };
            route4.Buses.Add(bus14);

            var bus15 = new Bus
            {
                Id = Guid.NewGuid(),
                Number = "AM 4753 AA",
                Courses = new List<Course> { route4 }
            };
            route4.Buses.Add(bus15);

            var buses = new List<Bus> { bus1, bus2, bus3, bus4, bus5, bus6, bus7, bus8,
                bus9, bus10, bus11, bus12, bus13, bus14, bus15 };

            // bus routes
            var br1 = new BusCourse { Bus = bus1, Course = route1 };
            var br2 = new BusCourse { Bus = bus1, Course = route5 };
            var br3 = new BusCourse { Bus = bus1, Course = route6 };

            var br4 = new BusCourse { Bus = bus2, Course = route1 };
            var br5 = new BusCourse { Bus = bus2, Course = route5 };
            var br6 = new BusCourse { Bus = bus2, Course = route6 };

            var br7 = new BusCourse { Bus = bus3, Course = route1 };
            var br8 = new BusCourse { Bus = bus3, Course = route5 };
            var br9 = new BusCourse { Bus = bus3, Course = route6 };

            var br10 = new BusCourse { Bus = bus4, Course = route1 };
            var br11 = new BusCourse { Bus = bus4, Course = route5 };
            var br12 = new BusCourse { Bus = bus4, Course = route6 };

            var br13 = new BusCourse { Bus = bus5, Course = route1 };
            var br14 = new BusCourse { Bus = bus5, Course = route5 };
            var br15 = new BusCourse { Bus = bus5, Course = route6 };

            var br16 = new BusCourse { Bus = bus6, Course = route2 };
            var br17 = new BusCourse { Bus = bus7, Course = route2 };
            var br18 = new BusCourse { Bus = bus8, Course = route2 };

            var br19 = new BusCourse { Bus = bus9, Course = route3 };
            var br20 = new BusCourse { Bus = bus10, Course = route3 };
            var br21 = new BusCourse { Bus = bus11, Course = route3 };
            var br22 = new BusCourse { Bus = bus12, Course = route3 };

            var br23 = new BusCourse { Bus = bus13, Course = route4 };
            var br24 = new BusCourse { Bus = bus14, Course = route4 };
            var br25 = new BusCourse { Bus = bus15, Course = route4 };

            var busRoutes = new List<BusCourse> { br1, br2, br3, br4,
                br5, br6, br7, br8, br9, br10, br11, br12, br13, br14,
                br15, br16, br17, br18, br19, br20, br21, br22, br23, br24, br25 };


            return new Assets { Companies = companies, Buses = buses, BusCourses = busRoutes, Courses = routes };
        }
    }
}
