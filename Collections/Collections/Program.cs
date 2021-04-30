using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Collections
{
    class Program
    {
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        static void Main()
        {
            try
            {
                var st1 = new Student
                {
                    FirstName = "Marie",
                    LastName = "Kuri",
                    Weight = 55,
                    Height = 168,
                    University = "BSTU"
                };
                var st2 = new Student
                {
                    FirstName = "Jack",
                    LastName = "Nicholson",
                    Weight = 75,
                    Height = 185,
                    University = "BSTU"
                };
                var st3 = new Student
                {
                    Weight = 54,
                    Height = 181,
                    FirstName = "Lance",
                    LastName = "Knight",
                    University = "BSU"
                };
                var st4 = new Student
                {
                    FirstName = "Lance",
                    LastName = "Stepth",
                    Weight = 78,
                    Height = 184,
                    University = "BSU"
                };
                var st5 = new Student
                {

                    FirstName = "Wesley",
                    LastName = "Jackson",
                    Weight = 81,
                    Height = 184,
                    University = "BSTU"
                };
                var wr1 = new Worker
                {

                    FirstName = "Douglas",
                    LastName = "Collins",
                    Weight = 67,
                    Height = 190,
                    Salary = 578.4
                };
                var wr2 = new Worker
                {

                    FirstName = "Lynn",
                    LastName = "Gibson",
                    Weight = 67,
                    Height = 190,
                    Salary = 976.5
                };
                var wr3 = new Worker
                {
                    FirstName = "Olivi",
                    LastName = "Smith",
                    Weight = 55,
                    Height = 172,
                    Salary = 493
                };
                var container1 = new HumanContainer<Human> { st1, wr1, st2, wr2 };
                container1.Remove(wr2);
                container1.Remove(st1);
                foreach (var human in container1)
                {
                    Console.WriteLine(human.ToString());
                }
                Console.WriteLine("---------------------------------------------");

                var container2 = new HumanContainer<Human>();
                container2.Add(st3);
                container2.Add(st4);
                container2.Add(st5);
                container2.Add(wr3);
                container2.Sort();
                foreach (var human in container2)
                {
                    Console.WriteLine(human.ToString());
                }
                var list = new LinkedList<HumanContainer<Human>>();
                list.AddLast(container1);
                list.AddLast(container2);

                var ordered = list.OrderBy(x => x.Count);

                Console.WriteLine("\nMin collection: " + ordered.First().Count);
                Console.WriteLine("\nMax collection: " + ordered.Last().Count);
                Console.WriteLine("\nCollection size n: " + (from HumanContainer<Human> t in list where t.Count == 2 select t).First().Count);

                WriteToBinaryFile<Human>("Human.obj", st1);
                Human list2 = ReadFromBinaryFile<Human>("Human.obj");
                Console.WriteLine("\nWrite to file: " + list2.FullName);

                //return;

                Console.WriteLine("\nLinq To objects: ");
                var orderRes = container2.OrderBy(h => h.Height).ThenBy(h => h.Weight);
                foreach (var human in orderRes)
                    Console.WriteLine(human);

                Console.WriteLine("\nLinq To objects: ");
                var whereRes = container2.Where(h => (h.Height > 170 && h.Weight >= 58) ||
               h.FullName.StartsWith("L")).OrderByDescending(h => h);
                foreach (var human in whereRes)
                    Console.WriteLine(human.ToString());

                Console.WriteLine("\nLinq To objects: ");
                var allAnyRes = list.First(c => c.All(h => h.Height > 160) && c.Any(h => h is Worker))
                .Select(h => h.FirstName)
               .OrderByDescending(s => s);
                foreach (var name in allAnyRes)
                    Console.WriteLine(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public interface IHuman
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Height { get; set; }
        double Weight { get; set; }
    }

    [Serializable]
    public class Human : IHuman, IComparable<Human>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public Human() { }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public int CompareTo(Human other)
        {
            return string.Compare(other.FullName, FullName,
                StringComparison.OrdinalIgnoreCase);
        }
        public override string ToString()
        {
            return string.Format("Class Human: \n FullName: {0}, Height: {1}, Width: {2}",
                FullName,
                Height,
                Weight);
        }
    }

    [Serializable]
    public class Worker : Human
    {
        public double Salary { get; set; }
        public Worker() { }
        public override string ToString()
        {
            return string.Format(
            "Class Worker: \n FullName: {0}, Height: {1}, Width: {2}, Salary: {3}",
            FullName,
            Height,
            Weight,
            Salary
            );
        }
    }

    [Serializable]
    public class Student : Human
    {
        public string University { get; set; }
        public Student() { }
        public override string ToString()
        {
            return string.Format(
            "Class Student: \n FullName: {0}, Height: {1}, Width: {2}, University: {3}",
            FullName,
            Height,
            Weight,
            University
        );
        }
    }

    public class HumanContainer<T> : IEnumerable<T> where T : Human
    {
        private readonly List<T> _container;
        public HumanContainer()
        {
            _container = new List<T>();
        }
        public int Count
        {
            get { return _container.Count; }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _container[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _container[index] = value;
            }
        }
        public void Add(T human)
        {
            _container.Add(human);
        }
        public T Remove(T human)
        {
            var element = _container.FirstOrDefault(h => h == human);
            if (element != null)
            {
                _container.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }
        public void Sort()
        {
            _container.Sort();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _container.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }

    }
}