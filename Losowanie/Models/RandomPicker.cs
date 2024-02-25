using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losowanie.Models
{
    public class RandomPicker
    {
        public Person PickRandomPerson(List<Person> people)
        {
            if (people == null || people.Count == 0)
                return null;

            Random random = new Random();
            int index = random.Next(0, people.Count);
            return people[index];
        }
    }
}
