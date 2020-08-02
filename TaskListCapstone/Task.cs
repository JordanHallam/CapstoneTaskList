using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TaskListCapstone
{
    class Task
    {
        private string _name;
        private string _description;
        private DateTime _duedate;
        private bool _completion;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description;}
            set { _description = value;}
        }
        public DateTime Duedate
        {
            get { return _duedate;}
            set { _duedate = value; }
        }
        public bool Completion
        {
            get { return _completion; }
            set { _completion = value; }
        }

        public Task(){ }
        public Task(string name, string description,DateTime duedate, bool completion)
        {
            Name = name;
            Description = description;
            Duedate = duedate;
            Completion = completion;
        }
        public void Showtask()
        {
            string completionStatus = "Incomplete";
            if (Completion== true)
            {
                completionStatus = "Complete";
            }
            Console.WriteLine("\tCompletion Status: " + completionStatus+ "\n\tTeam Member Name: "+Name+"\n\tTask Description: "+Description+"\n\tDue Date: "+Duedate.ToShortDateString());
        }
        public void MarkComplete()
        {
            Completion = true;
        }
    }
}
