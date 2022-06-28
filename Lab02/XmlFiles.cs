using Data;
using System.Xml;

namespace Lab02
{
    public static class XmlFiles
    {
        private static readonly XmlWriterSettings _settings = new() { Indent = true };
        public static void InitialXmlFilesCreation(Assets data)
        {
            CreateBusesXml(data);
            CreateCompaniesXml(data);
            CreateCoursesXml(data);
            CreatBusCourseXml(data);
        }

        public static void CreatBusCourseXml(Assets data)
        {
            using (XmlWriter writer = XmlWriter.Create("buscourse.xml", _settings))
            {
                writer.WriteStartElement("busCourses");
                foreach (var br in data.BusCourses)
                {
                    writer.WriteStartElement("busCourses");
                    writer.WriteStartElement("bus");
                    writer.WriteElementString("id", br.Bus.Id.ToString());
                    writer.WriteElementString("number", br.Bus.Number);
                    writer.WriteEndElement();

                    writer.WriteStartElement("course");
                    writer.WriteElementString("id", br.Course.CourseId.ToString());
                    writer.WriteElementString("courseName", br.Course.Name);
                    writer.WriteStartElement("firstStop");
                    writer.WriteElementString("id", br.Course.FirstStop.Id.ToString());
                    writer.WriteElementString("name", br.Course.FirstStop.Name);
                    writer.WriteEndElement();
                    writer.WriteElementString("busAmount", br.Course.BusAmount.ToString());
                    writer.WriteStartElement("lastStop");
                    writer.WriteElementString("id", br.Course.LastStop.Id.ToString());
                    writer.WriteElementString("name", br.Course.LastStop.Name);
                    writer.WriteEndElement();
                    writer.WriteElementString("busAmount", br.Course.BusAmount.ToString());

                    writer.WriteStartElement("company");
                    writer.WriteElementString("id", br.Course.Company.Id.ToString());
                    writer.WriteElementString("companyName", br.Course.Company.Name);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();
            }
        }

        public static void CreateBusesXml(Assets data)
        {
            using (XmlWriter writer = XmlWriter.Create("buses.xml", _settings))
            {
                writer.WriteStartElement("buses");
                foreach (var bus in data.Buses)
                {
                    writer.WriteStartElement("bus");
                    writer.WriteElementString("id", bus.Id.ToString());
                    writer.WriteElementString("number", bus.Number);

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        public static void CreateCoursesXml(Assets data)
        {
            using (XmlWriter writer = XmlWriter.Create("courses.xml", _settings))
            {
                writer.WriteStartElement("courses");
                foreach (var course in data.Courses)
                {
                    writer.WriteStartElement("course");
                    writer.WriteElementString("id", course.CourseId.ToString());
                    writer.WriteElementString("courseName", course.Name);
                    writer.WriteStartElement("firstStop");
                    writer.WriteElementString("id", course.FirstStop.Id.ToString());
                    writer.WriteElementString("name", course.FirstStop.Name);
                    writer.WriteEndElement();
                    writer.WriteStartElement("lastStop");
                    writer.WriteElementString("id", course.LastStop.Id.ToString());
                    writer.WriteElementString("name", course.LastStop.Name);
                    writer.WriteEndElement();
                    writer.WriteElementString("busAmount", course.BusAmount.ToString());

                    writer.WriteStartElement("company");
                    writer.WriteElementString("id", course.Company.Id.ToString());
                    writer.WriteElementString("companyName", course.Company.Name);
                    writer.WriteEndElement(); //company

                    writer.WriteStartElement("busesNumbers");
                    foreach (var busNumber in course.BusesNumbers)
                    {
                        writer.WriteElementString("busNumber", busNumber);
                    }
                    writer.WriteEndElement(); //buses numbers

                    writer.WriteEndElement();
                }
                writer.WriteEndElement(); //courses
            }
        }

        public static void CreateCompaniesXml(Assets data)
        {
            using (XmlWriter writer = XmlWriter.Create("companies.xml", _settings))
            {
                writer.WriteStartElement("companies");

                foreach (var company in data.Companies)
                {
                    writer.WriteStartElement("company");
                    writer.WriteElementString("id", company.Id.ToString());
                    writer.WriteElementString("companyName", company.Name);

                    writer.WriteStartElement("courses");
                    foreach (var course in company.Courses)
                    {
                        writer.WriteStartElement("course");
                        writer.WriteElementString("id", course.CourseId.ToString());
                        writer.WriteElementString("courseName", course.Name);
                        writer.WriteStartElement("firstStop");
                        writer.WriteElementString("id", course.FirstStop.Id.ToString());
                        writer.WriteElementString("name", course.FirstStop.Name);
                        writer.WriteEndElement();

                        writer.WriteStartElement("lastStop");
                        writer.WriteElementString("id", course.LastStop.Id.ToString());
                        writer.WriteElementString("name", course.LastStop.Name);
                        writer.WriteEndElement();

                        writer.WriteElementString("busAmount", course.BusAmount.ToString());

                        writer.WriteStartElement("company");
                        writer.WriteElementString("id", company.Id.ToString());
                        writer.WriteElementString("companyName", course.Company.Name);
                        writer.WriteEndElement();

                        writer.WriteStartElement("busesNumbers");
                        foreach (var busNumber in course.BusesNumbers)
                        {
                            writer.WriteElementString("busNumber", busNumber);
                        }
                        writer.WriteEndElement();

                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}
