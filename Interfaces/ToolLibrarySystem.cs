using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    interface iToolLibrarySystem
    {
        void add(iTool); // add a new tool to the system

        void add(iTool, int); //add new pieces of an existing tool to the system

        void delete(iTool); //delte a given tool from the system

        void delete(iTool, int); //remove some pieces of a tool from the system

        void add(iMember); //add a new memeber to the system

        void delete(iMember); //delete a member from the system

        void display(string tool-type); //given the contact phone number of a member, display all the tools that the member are currently renting


        void displayTools(string); // display all the tools of a tool type selected by a member

        void borrowTool(iMember, iTool); //a member borrows a tool from the tool library

        void returnTool(iMember, iTool); //a member return a tool to the tool library

        string[] listTools(iMember); //get a list of tools that are currently held by a given member

        void displayTopTHree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.


    }
}
