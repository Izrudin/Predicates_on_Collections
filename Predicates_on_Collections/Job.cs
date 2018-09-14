using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicates_on_Collections
{
    class Job 
    {
        //getters&setters
        public string Location { set; get; }

        public string Description { set; get; }

        public int Salary { set; get; }
       
        //constructor

        public Job(string location, string description, int salary)
        {
            this.Location = location;
            this.Description = description;
            this.Salary = salary;
        }

     
        //creating lists and a random
        
        public List<Job> jobs = new List<Job>();     //public because im using it in the Person class
        List<String> Locations = new List<string>();
        List<String> Descriptions = new List<string>();
        List<int> Salaries = new List<int>();
        Random random = new Random();

        //for generating job locations and descriptions

        enum location 
        {
            Sonderborg,
            Nordborg,
            Copenhagen,
            Vejle,
            Sofia,
            Pazardzhik,
        };

        enum description
        {
            Programmer,
            Policeman,
            Business,
            Basketball,
            Mechanic,
            Unemployed,

        };

        //generating methods


        public void generate_JobData()
        {
            int JACKPOT = random.Next(1, 20);
            int unemployed_counter = 0;

            for (int i = 0; i < 100; i++)
            {
                int random_location = random.Next(1, 7);
                int random_description = random.Next(1, 7);

                //generating random job location from predefined enums

                switch (random_location)
                {
                    case 1:
                        Locations.Add(location.Sonderborg.ToString());
                        break;
                    case 2:
                        Locations.Add(location.Nordborg.ToString());
                        break;
                    case 3:
                        Locations.Add(location.Copenhagen.ToString());
                        break;
                    case 4:
                        Locations.Add(location.Vejle.ToString());
                        break;
                    case 5:
                        Locations.Add(location.Pazardzhik.ToString());
                        break;
                    case 6:
                        Locations.Add(location.Sofia.ToString());
                        break;
                    default:
                        break;
                }

                //generating a random job description from predefined enums

                switch (random_description)
                {
                    case 1:
                        Descriptions.Add(description.Programmer.ToString());
                        break;
                    case 2:
                        Descriptions.Add(description.Policeman.ToString());

                        break;
                    case 3:
                        Descriptions.Add(description.Business.ToString());

                        break;
                    case 4:
                        Descriptions.Add(description.Basketball.ToString());

                        break;
                    case 5:
                        Descriptions.Add(description.Mechanic.ToString());

                        break;
                    case 6:
                        Descriptions.Add(description.Unemployed.ToString());
                        unemployed_counter++;
                        Salaries[i].Equals(0);

                        if (unemployed_counter.Equals(JACKPOT))
                        {
                            Salaries[i] = 1000000;
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        //salaries are generated seperately because of logic reasons

        public void generate_Salaries() {
            for (int i = 0; i < 100; i++)
            {
                int random_salary = random.Next(8000, 60000);
                Salaries.Add(random_salary);
            }
        }

        //populating the real list with jobs

        public void populate_JobList()
        {
            generate_Salaries();
            generate_JobData();

            for (int i = 0; i < 100; i++)
            {
                jobs.Add(new Job(Locations[i], Descriptions[i], Salaries[i]));
            }
        }

        //"get" methods (for tests mostly)

        public String getJobData()
        {
            return ("job location: " + Location + ", job description: " + Description + ", salary: " + Salary);
        }

        public void getJobsList()
        {
            foreach (Job element in jobs)
            {
                Console.WriteLine(element.getJobData());
            }
        }

        public int getJobLenght()
        {
            populate_JobList();
            return jobs.Count;
        }
    }
}
