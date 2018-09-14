using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicates_on_Collections
{
    class Person {

        //delegate

        

     
        //getters & setters, Job instance cuz its a class
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

        //for generating people's names

        enum first_names 
        {
            Ivan,
            Georgi,
            Mads,
            John,
            Guisseppe,
            Andrea,
            Denver,
            Maria,
            Liliya,
            Simona
        };

        enum last_names 
        {
            Alexanderson,
            Klausen,
            DeVrij,
            Jackson,
            Marco,
            Vidal,
            Sandoval,
            Martinez,
            Koch,
            Horvath
        };


        //creating lists & a random
        List<Person> People = new List<Person>();
        List<String> FirstNames = new List<string>();
        List<String> LastNames = new List<string>();
        Random random = new Random();

        //generating methods

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
                        FirstNames.Add(first_names.Mads.ToString());
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
                        FirstNames.Add(first_names.Liliya.ToString());
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
                        LastNames.Add(last_names.DeVrij.ToString());
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
                        LastNames.Add(last_names.Sandoval.ToString());
                        break;
                    case 8:
                        LastNames.Add(last_names.Martinez.ToString());
                        break;
                    case 9:
                        LastNames.Add(last_names.Koch.ToString());
                        break;
                    case 10:
                        LastNames.Add(last_names.Horvath.ToString());
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
                People.Add(new Person(FirstNames[i], LastNames[i], Job.Jobs[i]));
            }
        }

        //get methods [IMPORTANT]

        public String getPersonData(Person person)
        {
            return ("first name: " + person.FirstName + ", last name: " + person.LastName + ", " + person.Job.getJobData() + "\n");
        }


        public void getAllPeople()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(getPersonData(People[i]));
            }
        }


        //get methods [TEST]



        public void getAllSurnames()
        {
            for (int i = 0; i < LastNames.Count(); i++)
            {
                Console.WriteLine(LastNames[i]);
            }
            Console.WriteLine("\n\n\n========================     number of surnames: " + LastNames.Count() + "     ========================\n\n\n");
        }

        public void getAllNames() {
            for (int i = 0; i < FirstNames.Count(); i++)
            {
                Console.WriteLine(FirstNames[i]);
            }
            Console.WriteLine("\n\n\n========================     number of names: " + FirstNames.Count() + "     ========================\n\n\n");
            getAllSurnames();
        }
        
    }
}
