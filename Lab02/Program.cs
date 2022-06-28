using Data;
using Lab02;
using Model;
using System.Text.RegularExpressions;

namespace Lab2Example
{
    class Program
    {
        static void Main()
        {
            var data = DataSeeding.GetData();
            XmlFiles.InitialXmlFilesCreation(data);

            Options(data);
        }

        static void PrintMenu()
        {
            Console.WriteLine("Choose from 1 to 15 or 0 to quit.");
            Console.WriteLine("1. Get first stop and quantity of buses driving from this point.");
            Console.WriteLine("2. Get number of buses that run on courses with more than three buses.");
            Console.WriteLine("3. Get companies with the biggest amount of courses.");
            Console.WriteLine("4. Get first and last three buses.");
            Console.WriteLine("5. Get courses with it\'s companies.");
            Console.WriteLine("6. Get common courses between first and second buses.");
            Console.WriteLine("7. Get list of the same amount of courses for buses.");
            Console.WriteLine("8. Get car city codes with their amount.");
            Console.WriteLine("9. Get all start and end points.");
            Console.WriteLine("10. Get courses with the same amount of buses.");
            Console.WriteLine("11. Get avarage amount of buses among courses.");
            Console.WriteLine("12. Get all buses except buses on first and last course.");
            Console.WriteLine("13. Get amount of symbols in courses.");
            Console.WriteLine("14. Get all courses of companies.");
            Console.WriteLine("15. Get all ordered bus numbers.");
            Console.WriteLine("16. Input new bus.");
            Console.WriteLine("0. Quit.");
        }

        static void Options(Assets data)
        {
            var queues = new Queues();
            var finished = false;
            while (!finished)
            {
                PrintMenu();
                string? opt = Console.ReadLine();
                if (opt is null || !int.TryParse(opt, out int result) || result < 0 || result > 16)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong option. Try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                switch (result)
                {
                    case 0:
                        Console.WriteLine("Program finished.");
                        finished = true;
                        break;
                    case 1:
                        {
                            var queue = queues.GetByFirstStopAndCount();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 2:
                        {
                            var queue = queues.GetThreeOrMoreBusses(3);
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            var queue = queues.GetTopRoutesCompanies();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            var queue = queues.GetFirstAndLastBusses();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            var queue = queues.CompanyCourseJoin();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item.Name1 + " " + item.Name2);
                            }
                            break;
                        }
                    case 6:
                        {
                            var queue = queues.GetCommonRoutes();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 7:
                        {
                            var queue = queues.GroupingBusesByAmountOfCoursesOnEach();
                            foreach (var item in queue)
                            {
                                Console.WriteLine("Amount: " + item.Name1 + ", buses: " + item.Name2);
                            }
                            break;
                        }
                    case 8:
                        {
                            var queue = queues.GetNameplates();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item.Name1 + " - " + item.Name2);
                            }
                            break;
                        }
                    case 9:
                        {
                            var queue = queues.GetRouteStartAndFinish();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 10:
                        {
                            var queue = queues.GetRoutesByBusAmount();
                            foreach (var item in queue)
                            {
                                Console.WriteLine("Courses: " + item.Name2 + " with " + item.Name1);
                            }
                            break;
                        }
                    case 11:
                        {
                            var queue = queues.GetAvgBussAmount();
                            Console.WriteLine("Avarage amount: " + queue);
                            break;
                        }
                    case 12:
                        {
                            var queue = queues.GetAllBussesButLastAndFirstRoute();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 13:
                        {
                            var queue = queues.GetRoutesBySymbols();
                            foreach (var item in queue)
                            {
                                Console.WriteLine("Number of symbols: " + item.Name1 + ", courses: " + item.Name2);
                            }
                            break;
                        }
                    case 14:
                        {
                            var queue = queues.GetRoutesByCompany();
                            foreach (var item in queue)
                            {
                                Console.WriteLine("Company \"" + item.Name1 + "\" has courses: " + item.Name2);
                            }
                            break;
                        }
                    case 15:
                        {
                            var queue = queues.GetAllBusNumbers();
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 16:
                        AddingNewItemsToBuses(data);
                        queues.ReadBuses();
                        queues.ReadBusCourses();
                        break;
                }

                Console.Write("Press any button to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddingNewItemsToBuses(Assets data)
        {
            while (true)
            {
                Console.WriteLine("Type bus number:");
                var number = Console.ReadLine();
                if (data.Buses.Any(b => b.Number == number))
                {
                    Console.WriteLine("Wrong number.");
                    continue;
                }

                Console.WriteLine("Choose courses separated by spaces");
                Console.WriteLine(data.Courses.Select(r => r.Name).Aggregate((s1, s2) => s1 + ", " + s2));

                var courses = Console.ReadLine();
                if (courses is null)
                {
                    Console.WriteLine("Type any course");
                    continue;
                }

                var separatedCourses = courses.Split(' ');

                var coursesObj = new List<Course>();
                var isCorrectCourses = true;
                foreach (var course in separatedCourses)
                {
                    var rr = data.Courses.FirstOrDefault(r => r.Name == course);
                    if (rr is null)
                    {
                        Console.WriteLine("Course " + course + " was not found");
                        isCorrectCourses = false;
                        break;
                    }
                    coursesObj.Add(rr);
                }
                if (!isCorrectCourses) continue;

                var bus = new Bus { Number = number, Courses = coursesObj };

                foreach (var course in coursesObj)
                {
                    course.Buses.Add(bus);
                }

                data.Buses = data.Buses.Append(bus);

                XmlFiles.CreateBusesXml(data);
                Console.WriteLine("done");
                break;
            }
        }
    }
}