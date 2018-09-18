using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicates_on_Collections
{
    class Person
    {

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ delegates ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public delegate Person getPersonFromList (List<Person> people);

        public delegate List<Person> getListFromList(List<Person> people);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ getters & setters, Job instance ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        Job Job;

        //constructor

        public Person(string fname, string lname, Job job)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Job = job;
        }

        //enums for generating people's names

        enum first_names 
        {
            Ivan,
            Georgi,
            Carl,
            John,
            Guisseppe,
            Andrea,
            Denver,
            Maria,
            Carla,
            Simona
        };

        enum last_names 
        {
            Alexanderson,
            Klausen,
            Howard,
            Jackson,
            Marco,
            Vidal,
            Gregsen,
            Martinez,
            Hoch,
            Larsen
        };


        //creating lists & a random

        public List<Person> People = new List<Person>();
        List<String> FirstNames = new List<string>();
        List<String> LastNames = new List<string>();
        Random random = new Random();

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~generating methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void generate_Names()
        {
           for (int i = 0; i < 100; i++)
            {
                int random_firstName = random.Next(1, 10);
                int random_lastName = random.Next(1, 10);

                switch (random_firstName)
                {
                    case 1:
                        FirstNames.Add(first_names.Ivan.ToString());
                        break;
                    case 2:
                        FirstNames.Add(first_names.Georgi.ToString());
                        break;
                    case 3:
                        FirstNames.Add(first_names.Carl.ToString());
                        break;
                    case 4:
                        FirstNames.Add(first_names.John.ToString());
                        break;
                    case 5:
                        FirstNames.Add(first_names.Guisseppe.ToString());
                        break;
                    case 6:
                        FirstNames.Add(first_names.Andrea.ToString());
                        break;
                    case 7:
                        FirstNames.Add(first_names.Denver.ToString());
                        break;
                    case 8:
                        FirstNames.Add(first_names.Maria.ToString());
                        break;
                    case 9:
                        FirstNames.Add(first_names.Carla.ToString());
                        break;
                    case 10:
                        FirstNames.Add(first_names.Simona.ToString());
                        break;
                    default:
                        break;
                }

                switch (random_lastName)
                {
                    case 1:
                        LastNames.Add(last_names.Alexanderson.ToString());
                        break;
                    case 2:
                        LastNames.Add(last_names.Klausen.ToString());
                        break;
                    case 3:
                        LastNames.Add(last_names.Howard.ToString());
                        break;
                    case 4:
                        LastNames.Add(last_names.Jackson.ToString());
                        break;
                    case 5:
                        LastNames.Add(last_names.Marco.ToString());
                        break;
                    case 6:
                        LastNames.Add(last_names.Vidal.ToString());
                        break;
                    case 7:
                        LastNames.Add(last_names.Gregsen.ToString());
                        break;
                    case 8:
                        LastNames.Add(last_names.Martinez.ToString());
                        break;
                    case 9:
                        LastNames.Add(last_names.Hoch.ToString());
                        break;
                    case 10:
                        LastNames.Add(last_names.Larsen.ToString());
                        break;
                    default:
                        break;
                }
            }
        }


        //generates the actual list of people that we're using for testing the lambdas

        public void generate_PeopleList()
        {
            generate_Names();
            Job.populate_JobList();

            for (int i = 0; i < 100; i++)
            {
                People.Add(new Person(FirstNames[i], LastNames[i], Job.jobs[i]));
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ get methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        public void getList(List<Person> people) {
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine("first name: " + people[i].FirstName + ", last name: " + people[i].LastName + ", location: " + people[i].Job.Location + ", description: " + people[i].Job.Description + ", salary: " + people[i].Job.Salary + " dkk\n");
            }
        }
        

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ lambdas ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //get a list with all the people with a first names Carl or Carla


        public getListFromList Carl_Carla = people =>
        {
            List<Person> carl_carla = new List<Person>();
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].FirstName.Equals("Carl") || people[i].FirstName.Equals("Carla"))
                {
                    carl_carla.Add(people[i]);
                }
            }
            return carl_carla;
        };

        //get the person with the highest salary

        public getPersonFromList withHighestSalary = people =>
        {
            Job jobTest = new Job("", "", 0);
            Person richestPerson = new Person("", "", jobTest);
            int salaryChecker = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Job.Salary > salaryChecker)
                {
                    salaryChecker = people[i].Job.Salary;
                    richestPerson = people[i];
                }
            }
            return richestPerson;
        };

        //get a list with all people's surnames starting with H

        public getListFromList lastNameStartingWith_H = people =>
        {
            Person personTest = new Person("", "", new Job("", "", 0));
            List<Person> people_h = new List<Person>();
            for (int i = 0; i < people.Count; i++)
            {
                if ((people[i].LastName.Substring(0, 1)).Equals("H"))
                {
                    people_h.Add(people[i]);
                }
            }
            return people_h;
        };

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ LINQ methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void getPeopleFromSonderborg(List<Person> people) {
            IEnumerable<Person> fromSonderborg =
                from person in people
                where person.Job.Location.Equals("Sonderborg")
                select person;

            getList(fromSonderborg.ToList());

        }

        public void salary_between_10_25k_fromSonderborg(List<Person> people) {
            IEnumerable<Person> returnVal =
                from person in people
                where person.Job.Location.Equals("Sonderborg") && ((person.Job.Salary >= 10000) && (person.Job.Salary <= 25000))
                select person;

            getList(returnVal.ToList());
        }


        //get the data of the richest person using this method

        public void getPersonData(Person person)
        {
            Console.WriteLine("first name: " + person.FirstName + ", last name: " + person.LastName + ", location: "+person.Job.Location+ ", description: "+person.Job.Description+", salary: "+person.Job.Salary+" dkk\n");
        }
    }
}
