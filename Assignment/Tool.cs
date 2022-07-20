using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{

    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        private MemberCollection members = new MemberCollection();

        public Tool(string name, int quantity, int availableQuantity, int noBorrowings)
        {
            Name = name;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            NoBorrowings = noBorrowings;
        }

        //get and set the name of this tool
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //get and set the quantity of this tool
        public int Quantity 
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            } 
        }

        //get and set the quantity of this tool currently available to lend
        public int AvailableQuantity
        {
            get
            {
                return availableQuantity;
            }
            set
            {
                availableQuantity = value;
            }
        }

        //get and set the number of times that this tool has been borrowed
        public int NoBorrowings
        {
            get
            {
                return noBorrowings;
            }
            set
            {
                noBorrowings = value;
            }
        }

        //get all the members who are currently holding this tool
        public MemberCollection GetBorrowers
        {
            get
            {
                return members;
            }
        }

        //add a member to the borrower list
        public void addBorrower(Member member)
        {
            //add member being passed in to memberCollection members;
            members.add(member);
        }

        public int CompareTo(Tool tool)
        {
            if (Name.CompareTo(tool.Name) < 0)
                return -1;
            else
                if (Name.CompareTo(tool.Name) == 0)
                return 0;
            else
                return 1;
        }

        //delete a member from the borrower list
        public void deleteBorrower(Member member)
        {
            //delete borrower node from the bstree specific to this tool
            members.delete(member);
        }

        //return a string containing the name and the available quantity quantity this tool
        public override string ToString()
        {
            string toolString = "";
            string[] values = { "Name:", Name, "Total Quantity:", Quantity.ToString(), "Available Quantity:", AvailableQuantity.ToString(), "Times Borrowed:", NoBorrowings.ToString() };
            toolString += String.Join(" ", values);
            return toolString;
        }
    }
}
