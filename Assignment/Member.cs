using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Assignment
{
    //Class to create member objects
    public class Member : iMember, IComparable<Member>
    {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pin;
        private string[] tools = new string[3];//A member can only borrow 3 tools at most at any given time
        private ToolCollection myTools = new ToolCollection();

        public Member(string firstName, string lastName, string contactNumber, string pin)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            PIN = pin;
            MyTools = myTools;
        }

        //get and set the first name of this member
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        //get and set the last name of this member
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        //get and set the contact number of this member
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }

        //get and set the password of this member 
        public string PIN
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }

        //get a list of tools that this member is currently holding
        public string[] Tools
        {
            get
            {
                int i = 0;
                for (int j = 0; j < tools.Count(); j++)
                {
                    tools[i] = null;
                }
                foreach (Tool tool in MyTools.Collection)
                {
                    if (MyTools.Collection[i] != null)
                    {
                        tools[i] = MyTools.Collection[i].ToString();
                        i++;
                    }
                }
                return tools;
            }
        }

        public ToolCollection MyTools
        {
            get
            {
                return myTools;
            }
            set
            {
                myTools = value;
            }
        }

        //add a given tool to the list of tools that this member is currently holding
        public void addTool(Tool tool)
        {
            //If the member already has 3 tools in their collection, hard stop
            if (myTools.Collection.Count() == 3)
            {
                WriteLine("You can't borrow any more tools!");
                WriteLine("Press any key to continue...");
                ReadKey();
                MenuSystem.MemberMenu();
            }
            //If they have less than three tools on loan, continue to find the tool and point it to the member's ToolCollection
            else
            {
                for (int i = 0; i < myTools.Collection.Count(); i++)
                {
                    //Skip over tools the member has already borrowed that are stored in his ToolCollection
                    if (myTools.Collection[i] != null)
                    {

                    }
                    else
                    {
                        //Find the location of the supplied tool in the TLS ToolCollection and point the member's
                        //ToolCollection to that tool
                        for (int j = 0; j < Program.system.toolCollection.Collection.Count(); j++)
                        {
                            if (Program.system.toolCollection.Collection[j].CompareTo(tool) == 0)
                            {
                                myTools.Collection[j] = Program.system.toolCollection.Collection[j]; ;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public int CompareTo(Member other)
        {
            if (LastName.CompareTo(other.LastName) < 0)
                return -1;
            else
                if (LastName.CompareTo(other.LastName) == 0)
                return FirstName.CompareTo(other.FirstName);
            else
                return 1;
        }

        //delete a given tool from the list of tools that this member is currently holding
        public void deleteTool(Tool tool)
        {
            for (int i = 0; i < myTools.Collection.Count(); i++)
            {
                if (myTools.Collection[i] == null)
                {

                }
                else
                {
                    if (tool == myTools.Collection[i])
                    {
                        myTools.Collection[i] = null;
                    }
                }
            }
        }

        //return a string containing the first name, lastname, and contact phone number of this member
        public override string ToString()
        {
            string memberString = "";
            string[] values = { FirstName, LastName, ContactNumber };
            memberString += String.Join(" ", values);
            return memberString;
        }
    }
}
