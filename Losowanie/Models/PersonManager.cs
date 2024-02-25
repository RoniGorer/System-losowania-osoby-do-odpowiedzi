using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losowanie.Models
{
    public class PersonManager
    {
        private const string FilePath = "people.txt";

        public void SavePeople(List<Person> people)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var person in people)
                {
                    writer.WriteLine(person.Name);
                }
            }
        }

        public List<Person> LoadPeople()
        {
            List<Person> people = new List<Person>();
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        people.Add(new Person { Name = line });
                    }
                }
            }
            return people;
        }
    }
}
