using System.Xml.Linq;

namespace Lab02
{
    public class Queues
    {
        private const string _busesFile = "buses.xml";
        private const string _coursesFile = "courses.xml";
        private const string _companiesFile = "companies.xml";
        private const string _busCoursesFile = "buscourse.xml";

        private XElement _buses;
        private XElement _courses;
        private XElement _companies;
        private XElement _busCourses;

        public void ReadBuses()
        {
            var xBusesDoc = XDocument.Load(_busesFile);
            _buses = xBusesDoc.Element("buses");
        }

        public void ReadCourses()
        {
            var xCoursesDoc = XDocument.Load(_coursesFile);
            _courses = xCoursesDoc.Element("courses");
        }

        public void ReadCompanies()
        {
            var xCompaniesDoc = XDocument.Load(_companiesFile);
            _companies = xCompaniesDoc.Element("companies");
        }

        public void ReadBusCourses()
        {
            var xCompaniesDoc = XDocument.Load(_busCoursesFile);
            _busCourses = xCompaniesDoc.Element("busCourses");
        }


        public Queues()
        {
            ReadBuses();
            ReadCourses();
            ReadCompanies();
            ReadBusCourses();
        }

        public IEnumerable<string> GetByFirstStopAndCount()
        {
            var queue = from course in _courses?.Elements("course")
                        group course by course?.Element("startPoint")?.Element("id")?.Value into courseGroup
                        select new String
                        (
                            courseGroup.Select(x => x.Element("courseName").Value).First() + " - " + courseGroup.Count()
                        );
            return queue;
        }

        public IOrderedEnumerable<string> GetThreeOrMoreBusses(int number)
        {
            var queue = _busCourses.Elements("busCourse")?
                .Where(br => int.Parse(br?.Element("course")?.Element("busAmount")?.Value ?? "-1") >= number)
                .Select(br => br.Element("bus").Element("number").Value)
                .OrderBy(num => num);
            return queue;
        }

        public IEnumerable<string> GetTopRoutesCompanies()
        {
            var queue = (from companies in _companies.Elements("company")
                         where companies.Element("courses").Elements("course").Count() ==
                                (from max in _companies.Elements("company")
                                 select max.Element("courses").Elements("course").Count()).Max()
                         select companies.Element("companyName").Value);

            return queue;
        }

        public IEnumerable<string> GetFirstAndLastBusses()
        {
            var queue = _buses.Elements("bus")
                .Take(3)
                .Concat(_buses.Elements("bus")
                    .TakeLast(3)).Select(bus => bus.Element("number").Value);

            return queue;
        }

        public IEnumerable<StringString> CompanyCourseJoin()
        {
            var queue = from courses in _courses.Elements("course")
                        join companies in _companies.Elements("company")
                        on courses.Element("company").Element("id").Value equals companies.Element("id").Value
                        select new StringString
                        {
                            Name1 = courses.Element("cpurseName").Value,
                            Name2 = companies.Element("companyName").Value
                        };
            return queue;
        }

        public IEnumerable<string> GetCommonRoutes()
        {
            var queue = _busCourses.Elements("busCourse")
                .Where(br => br.Element("bus").Element("id").Value == _buses?.Elements("bus")?.ElementAt(1)
                    .Element("id").Value)
                .Select(br => br.Element("course").Element("courseName").Value)
                .Intersect(_busCourses.Elements("busCourse")
                .Where(br => br.Element("bus").Element("id").Value == _buses?.Elements("bus")?.ElementAt(2)
                    .Element("id").Value)
                .Select(br => br.Element("course").Element("courseName").Value));

            return queue;
        }

        public IEnumerable<StringString> GroupingBusesByAmountOfCoursesOnEach()
        {
            var queue = _busCourses.Elements("busCourse").GroupBy(br => br.Element("bus").Element("id").Value)
                .Select(br => new
                {
                    Name = br.FirstOrDefault()?.Element("bus"),
                    Count = br.Count()
                })
                .GroupBy(br => br.Count)
                .Select(b => new StringString
                {
                    Name1 = b.Key.ToString(),
                    Name2 = b.Select(n => n.Name.Element("number").Value)
                    .Aggregate((n1, n2) => n1 + ", " + n2)
                });

            return queue;
        }

        public IEnumerable<StringString> GetNameplates()
        {
            var queue = from res in (from buses in _buses.Elements("bus")
                                     group buses by buses.Element("number").Value[..2] into busesGroups
                                     select new StringString
                                     {
                                         Name1 = busesGroups.Key,
                                         Name2 = busesGroups.Count().ToString()
                                     })
                        orderby res.Name2 descending
                        select res;

            return queue;
        }

        public IOrderedEnumerable<string> GetRouteStartAndFinish()
        {
            var queue = _courses.Elements("course").Select(r => r.Element("startPoint").Element("name").Value)
                .Union(_courses.Elements("course").Select(r => r.Element("endPoint").Element("name").Value))
                .OrderBy(r => r.Length);

            return queue;
        }

        public IEnumerable<StringString> GetRoutesByBusAmount()
        {
            var queue = from res in (from courses in _courses.Elements("course")
                                     group courses by int.Parse(courses.Element("busAmount").Value) into courseGroups
                                     select new StringString
                                     {
                                         Name1 = courseGroups.Key + " buses",
                                         Name2 = (from r in courseGroups
                                                   select r.Element("courseName").Value).Aggregate((s1, s2) => s1 + ", " + s2)
                                     })
                        orderby res.Name1 descending
                        select res;
            return queue;

        }

        public double GetAvgBussAmount()
        {
            var queue = (from amount in _courses.Elements("course")
                         select double.Parse(amount.Element("busAmount").Value)).Average();

            return queue;
        }

        public IEnumerable<string> GetAllBussesButLastAndFirstRoute()
        {
            var queue = (from buses in _buses.Elements("bus")
                         select buses.Element("number").Value).Except((
                            from buses1 in _courses.Elements("course").First().Element("busesNumbers").Elements("busNumber")
                            select buses1.Value)
                            .Union(
                                from buses2 in _courses.Elements("course").Last().Element("busesNumbers").Elements("busNumber")
                                select buses2.Value)
                            );

            return queue;
        }

        public IEnumerable<StringString> GetRoutesBySymbols()
        {
            var queue = _courses.Elements("course").GroupBy(r =>
                r.Element("courseName").Value.Length)
                .Select(r => new StringString
                {
                    Name1 = r.Key.ToString(),
                    Name2 = r.Select(rr => rr.Element("courseName").Value)
                        .Aggregate((s1, s2) => s1 + ", " + s2)
                });
            return queue;
        }

        public IEnumerable<StringString> GetRoutesByCompany()
        {
            var queue = _companies.Elements("company").Select(c =>
                new StringString
                {
                    Name1 = c.Element("companyName").Value,
                    Name2 = c.Element("courses").Elements("course").Select(r => r.Element("courseName").Value)
                        .Aggregate((n1, n2) => n1 + ", " + n2)
                }
            );
            return queue;
        }

        public IEnumerable<string> GetAllBusNumbers()
        {
            var queue = from buses in _buses.Elements("bus")
                        orderby buses.Element("id").Value
                        select buses.Element("number").Value;

            return queue;
        }
    }
    public class StringString
    {
        public string Name1 { get; init; }
        public string Name2 { get; init; }
    }
}
