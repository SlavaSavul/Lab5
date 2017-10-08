using System;
using System.Text;


namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            Turner Turner1 = new Turner("Maxim", "Svirid", 26, "machine operator of wide profile", "AutoCardan", 24000);
            Student Student1 = new Student("Maxim", "Svirid", 26, "BSTU", "POIT", 2, "English");
            Employee Employee1 = new Employee("Maxim", "Svirid", 26, "Hight", "AutoCardan", 700);
            Turner Turner2 = new Turner("Maxim", "Svirid", 25, "machine operator of wide profile", "AutoCardan", 34000);
            Programmer Programmer1 = new Programmer("Maxim", "Svirid", 28, "JS, AspectJ, PL/M, REXX", "EPAM", 44000);


            Person Person1 =  Employee1 as Person;
            IInfo IInfo1= Programmer1 as IInfo;
            Learner Learner1 = Student1 as Learner;

           // Print Print1 = new Print();

            var Massiv = new Object[8] { Turner1, Student1, Employee1, Turner2 , Programmer1, Person1, IInfo1, Learner1 };

            foreach(Object i in Massiv)
            {
                Print.IAmPrinting((Person)i);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }


    interface IInfo
    {
        string Information();
    }
    interface IGet
    {
        void GetStr();
    }



    abstract class Person : IInfo
    {
        string name;
        string family;
        int age;
        public int Age
        {
            get { return age; }
            set { age=value; }
        }
        public string Family
        {
            get { return family; }
            set { family = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public  Person(string name,string family ,int age)
        {
            this.name = name;
            this.family = family;
            this.age = age;
        }

        public virtual string Information()
        {
            //Console.WriteLine("Name: "+ Name + "\nFamily: "+ Family+ "\nAge: " + Age);
            return ("Name: " + Name + "\nFamily: " + Family + "\nAge: " + Age);
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Person") + "\n" + Information();
        }


    }

    abstract class Working : Person
    {
        string organization;
        int wage;
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        public int Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        

        public Working(string name, string family, int age, string organization,int wage) : base(name,family,age)
        {
            this.wage = wage;
            this.organization = organization;
        }

        public override string Information()
        {
            // base.Information();
            //Console.WriteLine("Organization:   {0} \nWage: {1:c} ", Organization, Wage);
            return base.Information() + String.Format("\nOrganization:   {0} \nWage: {1:c} ", Organization, Wage);
        }

        public virtual void GetStr()
        {
            Console.WriteLine("\nWorking");
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Working") + "\n" + Information();
        }

    }

    abstract class Learner : Person
    {
        string educationalInstitution;
        int course;
        string specialty;
        public string EducationalInstitution
        {
            get { return educationalInstitution; }
            set { educationalInstitution = value; }
        }
        public int Course
        {
            get { return course; }
            set { course = value; }
        }
        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        public Learner(string name, string family, int age, string educationalInstitution, string specialty, int course) : base(name, family, age)
        {
            this.educationalInstitution = educationalInstitution;
            this.course = course;
            this.specialty = specialty;
        }
        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("Educational institution: " + EducationalInstitution + "\nCourse: " + Course + "\nSpecialty: " + Specialty);
            return base.Information() + ("\nEducational institution: " + EducationalInstitution + "\nCourse: " + Course + "\nSpecialty: " + Specialty);
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Learner") + "\n" + Information();
        }
    }

    class Employee : Working,IGet
    {
        string education;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public Employee(string name, string family, int age, string education, string organization, int wage) : base(name, family, age, organization,wage)
        {
            this.education = education;
        }



        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("Education: " + Education);
            return base.Information() + ("\nEducation: " + Education);
        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Employee") + "\n" + Information();
        }


        void IGet.GetStr()
        {
            Console.WriteLine("IGet");
        }

       public override void GetStr()
        {
            Console.WriteLine("Employee");
        }


    }

    class Turner : Working
    {
        string specialty;
        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        public Turner(string name, string family, int age, string specialty, string organization, int wage) : base(name, family, age, organization, wage)
        {
            this.specialty = specialty;
        }

        public new string Information()
        {          
            return base.Information()+("\nSpecialty: " + Specialty);
        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Turner") + "\n" + Information();
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Turner  Obj = (Turner)obj;
            return GetHashCode()== Obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return (Name + Family+Age).GetHashCode();
        }

    }

    class Programmer : Working
    {
        string programmingLanguages;
        public string ProgrammingLanguages
        {
            get { return programmingLanguages; }
            set { programmingLanguages = value; }
        }

        public Programmer(string name, string family, int age, string programmingLanguages, string organization, int wage) : base(name, family, age, organization, wage)
        {
            this.programmingLanguages = programmingLanguages;
        }

        public override string Information()
        {
           // base.Information();
            //Console.WriteLine("\nProgrammingLanguages: " + ProgrammingLanguages);
            return base.Information() + ("\nProgramming Languages: " + programmingLanguages);

        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Programmer") + "\n" + Information();
        }

    }

    class Student : Learner
    {
        string additionalCourses;
        public string AdditionalCourses
        {
            get { return additionalCourses; }
            set { additionalCourses = value; }
        }

        public Student(string name, string family, int age, string educationalInstitution, string specialty, int course,string additionalCourses) : base(name, family, age, educationalInstitution, specialty, course)
        {
            this.additionalCourses = additionalCourses;
        }
        public override string Information()
        {
           // base.Information();
            //Console.WriteLine("Courses: " + AdditionalCourses);
            return base.Information() + ("\nCourses: " + AdditionalCourses);

        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Student") + "\n" + Information();
        }
    }

    sealed class StudentExtramural  : Learner
    {
        string workPlace;
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }

        public StudentExtramural(string name, string family, int age, string educationalInstitution, string specialty, int course, string workPlace) : base(name, family, age, educationalInstitution, specialty, course)
        {
            this.workPlace = workPlace;
        }
        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("WorkPlace: " + WorkPlace);
            return base.Information() + ("\nWorkPlace: " + WorkPlace);


        }
        public override string ToString()
        {
            return String.Format("Тип объекта: StudentExtramural") + "\n" + Information();
        }
    }

    class Print
    {
      public static void IAmPrinting(Person obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }



    }


}
