using System;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {






            Console.ReadKey();
        }
    }


    interface IInfo
    {
        void Information();
      

    }


    class Person: IInfo
    {
        string name;
        string family;
        int age;

      public  Person(string name,string family ,int age)
        {
            this.name = name;
            this.family = family;
            this.age = age;
        }

       public virtual  void Information()
        {
            Console.WriteLine("Name "+ name+"\nFamily "+ family+ "\nAge " + age);
        }
    }

    class Working : Person, IInfo
    {
        string organization;
        int wage;
        public Working(string name, string family, int age, string organization,int wage) : base(name,family,age)
        {
            this.wage = wage;
            this.organization = organization;
        }

        public override void Information()
        {
            base.Information();
            Console.WriteLine("/nOrganization " + organization + "\nWage " + wage);
        }
    }

    class Employee : Working
    {
        string education;
        public Employee(string name, string family, int age, string education, string organization, int wage) : base(name, family, age, organization,wage)
        {
            this.education = education;
        }

    }

    class Turner : Working
    {
        string specialty;
        public Turner(string name, string family, int age, string specialty, string organization, int wage) : base(name, family, age, organization, wage)
        {

        }

    }

    class Programmer : Working
    {
        string programmingLanguages;
        public Programmer(string name, string family, int age, string programmingLanguages, string organization, int wage) : base(name, family, age, organization, wage)
        {

        }

    }
/*
    class Learner : Person
    {
        string educationalInstitution;
        int course;
        string group;
        string specialty;

    }

    class Student : Learner
    {

    }

    class StudentExtramural  : Learner
    {

    }
    */



}
