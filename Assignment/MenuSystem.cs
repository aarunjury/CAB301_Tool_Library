using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace Assignment
{
    //Class for displaying and manipulating the main menu and different sub-menus
    class MenuSystem
    {
        public static string[][] toolCategories =
        {
            new string[] { "Gardening Tools", "Flooring Tools", "Fencing Tools", "Measuring Tools", "Cleaning Tools", "Painting Tools", "Electronic Tools", "Electricity Tools", "Automotive Tools" },
            new string[] { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools" },
            new string[] { "Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" },
            new string[] { "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" },
            new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" },
            new string[] { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" },
            new string[] { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" },
            new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" },
            new string[] { "Test Equipment", "Safety Equipment", "Basic Hand Tools", "Circuit Protection", "Cable Tools" },
            new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" }
        };//jagged string array; allows easy indexing to display tools by their type for any reason. E.g, one pair of 
        //co-ordinates can pinpoint down to a tool type, e.g., Rollers = [6,2]

        //Main menu method
        public static void MainMenu()
        {
            int input;
            Clear();
            WriteLine("Welcome to the Tool Library");
            WriteLine("===========Main Menu===========");
            WriteLine("1. Staff Login");
            WriteLine("2. Member Login");
            WriteLine("0. Exit");
            WriteLine("===============================\n");
            Write("Please make a selection (1-2, or 0 to exit): ");
            input = Convert.ToInt32(ReadLine());
            if (input == 1)
            {
                StaffLogin();
            }
            else if (input == 2)
            {
                MemberLogin();
                //MemberMenu();//remove default logged in member
            }
            else if (input == 0)
            {
                WriteLine("Closing the program now...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        /*---All Staff related functionality below---*/

        //Staff login method to verify staff username and password before proceeding to StaffMenu()
        public static void StaffLogin()
        {
            string username;
            string password = null;
            Clear();
            WriteLine("Please enter the staff username: ");
            username = ReadLine().ToLower();
            WriteLine("Please enter the staff password: ");
            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            if (username == "staff" && password == "today123")
            {
                WriteLine("Logging you in, please wait...");
                Thread.Sleep(800);
                StaffMenu();
            }
            else
            {
                WriteLine("Incorrect login details supplied.");
                WriteLine("Press any key to try again...");
                ReadKey();
                StaffLogin();
            }
        }

        //Staff member functionality sub-menu method
        public static void StaffMenu()
        {
            int input;
            string menu = "Welcome to the Tool Library\n"
                + "===========Staff Menu===========\n"
                + "1. Add a new tool to the library\n"
                + "2. Add quantity of an existing tool\n"
                + "3. Remove quantity of an existing tool\n"
                + "4. Register a new member\n"
                + "5. Remove an existing member\n"
                + "6. Find the contact number of a member\n"
                + "0. Return to Main Menu\n"
                + "================================\n"
                + "Please make a selection (1-6, or 0 to return to main menu): ";
            Clear();
            Write(menu);
            input = Convert.ToInt32(ReadLine());
            if (input == 0)//change to case?
            {
                MainMenu();
            }
            else if (input == 1)
            {
                AddToolMenu();
            }
            else if (input == 2)
            {
                IncreaseToolQuantityMenu();
            }
            else if (input == 3)
            {
                ReduceToolQuantityMenu();
            }
            else if (input == 4)
            {
                RegisterMember();
            }
            else if (input == 5)
            {
                RemoveMember();
            }
            else if (input == 6)
            {
                ReturnPhoneNumber();
            }
        }

        //Sets up to display necessary user input to create a new tool for the tool library
        public static void AddToolMenu()
        {
            string name;
            bool happy = false;
            string agree;
            Tool aTool = new Tool("tool", 0, 0, 0);
            Clear();
            while (!happy)
            {
                //Take user input for what the name of the new tool should be and checks that there
                //isn't already a tool in the library with that name
                WriteLine("What name do you want to give this tool?");
                name = ReadLine();
                for (int i = 0; i < Program.system.toolCollection.Collection.Count(); i++)
                {
                    if (Program.system.toolCollection.Collection[i] == null)
                    {

                    }
                    else
                    {
                        if (Program.system.toolCollection.Collection[i].Name == name)
                        {
                            WriteLine("A tool already exists with this name! Try updating the quantity instead.");
                            Thread.Sleep(2000);
                            StaffMenu();
                        }
                    }
                }
                //Confirm user is happy with inputted name
                WriteLine($"Are you happy to name this tool '{name}', Y/N? ");
                agree = ReadLine().ToLower();
                if (agree == "y")
                {
                    happy = true;
                }
                aTool.Name = name;
            }
            Program.system.add(aTool);
        }
        //This method was supposed to be multi-purpose for Increasing and Reducing tool quantities
        //but either adding a tool or deleting a tool had to have the subarray indexes passed in using my
        //implementation so I couldn't end up reusing this method for reducing tool quantity
        public static Tool ModifyTools()
        {
            int catInput;//to allocate which category the tool is from
            int subInput;//to allocate which tool type the tool being updated is from
            int toolIndex;//to know which specific tool from a type to update
            Clear();
            WriteLine($"Please choose the tool that you want to change the total quantity of:");
            WriteLine("What category does this tool belong to?");
            //index of the name of selected category of tools in the toolCollection array
            DisplayCategories();
            catInput = Convert.ToInt32(ReadLine());
            WriteLine(toolCategories[0][catInput - 1]);
            DisplayToolTypes(catInput);
            WriteLine($"What tool type from {toolCategories[0][catInput - 1]} is this tool?");
            //index of the name of the selected tool type
            subInput = Convert.ToInt32(ReadLine());
            WriteLine(toolCategories[catInput][subInput - 1]);
            WriteLine("Which tool do you want to update?");
            DisplayTools(catInput - 1, subInput - 1);
            toolIndex = Convert.ToInt32(ReadLine()) - 1;
            Tool aTool = GetTool(catInput - 1, subInput - 1, toolIndex);
            if (aTool == null)
            {
                WriteLine("There's no tool there!");
                Thread.Sleep(2000);
                ModifyTools();
            }
            return aTool;
        }

        //Allows a user to select a specific tool, then increase it's total available quantity within the library system
        public static void IncreaseToolQuantityMenu()//need to add in that you can't update a tool while it's being borrowed?
        {

            int newQuantity;//the number of units by which the user wants to increase the quantity of this tool in the system
            Tool aTool = ModifyTools();
            WriteLine("How many of this tool are you adding?");
            newQuantity = Convert.ToInt32(ReadLine());
            Program.system.add(aTool, newQuantity);
        }

        //Allows a user to select a specific tool, then decrease it's total available quantity within the library system
        //Also checks to see if the amount to reduce is equal to the total quantity of that tool already in the system
        //and if so, deletes the tool entirely
        public static void ReduceToolQuantityMenu()
        {
            int newQuantity;//the number of units by which the user wants to increase the quantity of this tool in the system
            int catInput;//to allocate which category the tool is from
            int subInput;//to allocate which tool type the tool being updated is from
            int toolIndex;//to know which specific tool from a type to update
            Clear();
            WriteLine($"Please choose the tool that you want to change the total quantity of:");
            WriteLine("What category does this tool belong to?");
            //index of the name of selected category of tools in the toolCollection array
            DisplayCategories();
            catInput = Convert.ToInt32(ReadLine());
            WriteLine(toolCategories[0][catInput - 1]);
            DisplayToolTypes(catInput);
            WriteLine($"What tool type from {toolCategories[0][catInput - 1]} is this tool?");
            //index of the name of the selected tool type
            subInput = Convert.ToInt32(ReadLine());
            WriteLine(toolCategories[catInput][subInput - 1]);
            WriteLine("Which tool do you want to update?");
            DisplayTools(catInput - 1, subInput - 1);
            toolIndex = Convert.ToInt32(ReadLine()) - 1;
            Tool aTool = GetTool(catInput - 1, subInput - 1, toolIndex);
            if (aTool == null)
            {
                WriteLine("There's no tool there!");
                Thread.Sleep(2000);
                ReduceToolQuantityMenu();
            }
            WriteLine("How many of this tool are you removing?");
            newQuantity = Convert.ToInt32(ReadLine());
            Program.system.delete(aTool, newQuantity, catInput, subInput);
        }

        //Captures the necessary user input to create a new member object in the library then adds the new member
        //to the system's memberCollection(binary search tree)
        public static void RegisterMember()
        {
            string fName;
            string lName;
            string pNumber;
            string pass;
            Clear();
            Write("Enter the member's First Name: ");
            fName = ReadLine();
            Write("Enter the member's Last Name: ");
            lName = ReadLine();
            Write("Enter the member's contact phone number: ");
            pNumber = ReadLine();
            Write("Enter the member's desired PIN: ");
            pass = ReadLine();
            Member aMember = new Member(fName, lName, pNumber, pass);
            Program.system.memberCollection.add(aMember);
            Write($"Member {fName} successfully added!");
            Thread.Sleep(2000);
            StaffMenu();
        }

        //Traverses the BST to get the most up to date list of members, displays those to the user
        //for selection as to who to remove
        public static void RemoveMember()
        {
            int input = -1;
            string agree;
            bool happy = false;
            string name;
            while (input != 0)
            {
                while (!happy)
                {
                    //clear the list storing the members so it is a fresh slate and any recently deleted members don't show up again
                    Program.memberList.Clear();
                    //traverse the binary search tree again to get the most up to date stock of members
                    Program.system.memberCollection.MemberCollectionStruct.InOrderTraverse();
                    //Can't delete any members if there aren't any to delete in the first place
                    if (Program.memberList.Count == 0)
                    {
                        WriteLine("There are no members in the library to delete!");
                        Thread.Sleep(2000);
                        StaffMenu();
                    }
                    else
                    {
                        //Create a new table object to display the members in
                        TablePrinter table = new TablePrinter("Index", "First Name", "Last Name");
                        int i = 1;
                        foreach (Member members in Program.memberList)
                        {
                            table.AddRow(i.ToString(), members.FirstName, members.LastName);
                            i++;
                        }
                        table.Print();
                        Write("\nWhich member would you like to remove from the tool library?: ");
                        //-1 to match the index of the selected member printed to the screen from the memberList
                        input = Convert.ToInt32(ReadLine()) - 1;
                        //user entered 0
                        if (input == -1) 
                        { 
                            StaffMenu(); 
                        }
                        Member member = Program.memberList.ElementAt(input);
                        //Store the name of the member being deleted to display for confirmation at the end
                        name = member.FirstName;
                        //first check to see if the member's toolCollection has any tools in it (count the elements, ignoring null instances)
                        if (member.MyTools.Collection.Count(s => s != null) > 0)
                        {
                            WriteLine("You can't remove a member while they're borrowing tools!");
                            Thread.Sleep(2000);
                            RemoveMember();
                        }
                        Write($"Are you sure you want to delete {name}, Y/N? ");
                        agree = ReadLine().ToLower();
                        //any input other than 'y/Y' will repeat this block
                        if (agree == "y")
                        {
                            happy = true;
                        }
                        else
                        {
                            RemoveMember();
                        }
                        //if user confirms, delete the member from the system
                        Program.system.delete(member);
                        Write($"Member '{name}' deleted!");
                        Thread.Sleep(2000);
                        StaffMenu();
                    }
                }
            }
        }

        //Given a member's first and last name, this method will get an up to date list of
        //every member in the system, scan the list to see if any member objects First and
        //Last Name properties match the ones supplied and if so, prints that matching
        //member object's phone number
        public static void ReturnPhoneNumber()
        {
            string fName;
            string lName;
            Clear();
            WriteLine("Find a member's phone number Note: Entry is case-sensitive!");
            WriteLine("What is the first name of the member?");
            fName = ReadLine();
            WriteLine("What is the last name of the member?");
            lName = ReadLine();
            //Clear the memberList and traverse the BST to repopulate it with the most recent information
            Program.memberList.Clear();
            Program.system.memberCollection.MemberCollectionStruct.InOrderTraverse();
            if (Program.memberList.Count == 0)
            {
                WriteLine("There are no members in the library!");
                Thread.Sleep(2000);
                StaffMenu();
            }
            else
            {
                for (int i = 0; i < Program.memberList.Count; i++)
                {
                    if (Program.memberList[i] != null)
                    {
                        //Traverse the memberList looking for member objects whose xName parameters are a match for the ones
                        //entered by the user
                        if (Program.memberList[i].FirstName == fName && Program.memberList[i].LastName == lName)
                        {
                            WriteLine($"{fName}'s phone number is: {Program.memberList[i].ContactNumber}");
                            WriteLine("\nPress any key to continue...");
                            ReadKey();
                            StaffMenu();
                            //Or ReturnPhoneNumber();//add while (fName || lName != 0) to exit
                        }
                        else if (i == Program.memberList.Count - 1)
                        {
                            WriteLine("Member not found!");
                            Thread.Sleep(2000);
                            StaffMenu();
                        }
                    }
                }
            }
        }

        /*---All Member related functionality below---*/

        //Captures a member's 'username' in the required format, checks to see if it was entered in the correct format
        //by splitting the inputted string by capital letters and further checking if any members match those details
        //If so, a further check is done to see if the inputted password matches the one associated with the found member
        //and if that check passes, proceeds to the member menu and updates the global 'currently logged in member' with
        //the same
        public static void MemberLogin()
        {
            string username;
            string[] usernames = new string[30];
            string password = null;
            int i = 0;
            Member[] members = Program.system.memberCollection.toArray();
            foreach (Member m in members)
            {
                usernames[i] = m.LastName.Concat(m.FirstName).ToString();
                i++;
            }
            Clear();
            WriteLine("Please enter your username\n(note: your username is your last name, followed by your first name\nwith no space and case sensitive. E.g., BloggsJoe for Joe Bloggs");
            Write("Username: ");
            username = ReadLine();
            StringBuilder builder = new StringBuilder();
            //Insert a space before any capital letters encountered, except for the first one
            foreach (char c in username)
            {
                if (Char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }
            username = builder.ToString();
            //Now split the string into two where the spaces were inserted and save those strings in an array
            string[] splitNames = username.Split(' ');
            //Traverse the system's current members
            for (int j = 0; j < Program.memberList.Count; j++)
            {
                //if the entered username was supplied in the correct order/format and matches a member in the system, this statement will be true
                if (Program.memberList[j].LastName == splitNames[0] && Program.memberList[j].FirstName == splitNames[1])
                {
                    //now assign the logged in member to the one that matches
                    Program.system.loggedInMember = Program.memberList[j];
                }
            }
            WriteLine("Please enter your password");
            Write("Password: ");
            //obfuscate the password as it's being entered on the console screen, for security
            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            //check that the password the user entered matches the PIN saved for the previously
            //matched member
            if (password != Program.system.loggedInMember.PIN)
            {
                WriteLine("\nIncorrect login details supplied.");
                WriteLine("Press any key to try again...");
                WriteLine("Hint: Your password is 4 numbers.");
                ReadKey();
                MemberLogin();
            }
            else
            {
                WriteLine("\nLogging you in, please wait...");
                Thread.Sleep(800);
                MemberMenu();
            }
        }

        //Displays the content for the member functionality sub-menu
        public static void MemberMenu()
        {
            int input;
            string menu = "Welcome to the Tool Library\n"
                + "===========Member Menu===========\n"
                + "1. Display all the tools in the library by type\n"
                + "2. Borrow a tool\n"
                + "3. Return a tool\n"
                + "4. List all the tools that I am borrowing\n"
                + "5. Display the top 3 most borrowed tools\n"
                + "0. Return to Main Menu\n"
                + "=================================\n";
            Clear();
            Write(menu);
            WriteLine($"Currently logged in as: {Program.system.loggedInMember.FirstName}\n");
            Write("Please make a selection (1-5, or 0 to return to main menu): ");
            input = Convert.ToInt32(ReadLine());
            if (input == 0)//change to switch case here and also for staff menu???
            {
                MainMenu();
                Program.system.loggedInMember = null;
            }
            else if (input == 1)
            {
                DisplayToolsByType();
            }
            else if (input == 2)
            {
                BorrowTool();
            }
            else if (input == 3)
            {
                ReturnTool();
            }
            else if (input == 4)
            {
                ListBorrowedTools();
            }
            else if (input == 5)
            {
                DisplayTopThree();
            }

        }

        //Given a category and tool type, call DisplayTools to display the tools belonging to that type
        public static void DisplayToolsByType()
        {
            int catInput;
            int subInput;
            Clear();
            WriteLine("From what category is the tool you're looking for?");
            WriteLine("Press 0 to exit");
            DisplayCategories();
            catInput = Convert.ToInt32(ReadLine()) - 1;
            //because of the above, if the user types 0, it will be equal to -1 so return to the menu
            if (catInput == -1)
            {
                MemberMenu();
            }
            else
            {
                WriteLine(toolCategories[0][catInput]);
                WriteLine($"What tool type from {toolCategories[0][catInput]} is this tool?");
                DisplayToolTypes(catInput + 1);
                subInput = Convert.ToInt32(ReadLine()) - 1;
                //because of the above, if the user types 0, it will be equal to -1 so return to the menu
                if (subInput == -1)
                {
                    MemberMenu();
                }
                else
                {
                    DisplayTools(catInput, subInput);
                    WriteLine("Press any key to continue...");
                    ReadKey();
                    DisplayToolsByType();
                }
            }
        }

        //First checks to see that a user isn't already borrowing three tools and if not, proceeds to allow the user to choose a tool
        //to borrow and then adds it to that member's toolCollection by calling the system's borrowTool method
        public static void BorrowTool()
        {
            int catInput;
            int subInput;
            int toolIndex;
            Tool aTool;
            Clear();
            //check if the not null elements in the member's toolCollection adds up to 3
            //and if so, prevent them from borrowing any more tools
            int tally = Program.system.loggedInMember.MyTools.Collection.Count(s => s != null);
            if (tally == 3)
            {
                WriteLine("You can't borrow more than 3 tools!");
                Thread.Sleep(2000);
                MemberMenu();
            }
            else
            {
                WriteLine("Please choose the tool that you wish to borrow: ");
                WriteLine("From what category is the tool you're looking for?");
                DisplayCategories();
                catInput = Convert.ToInt32(ReadLine());
                WriteLine(toolCategories[0][catInput - 1]);
                WriteLine($"And what tool type from {toolCategories[0][catInput - 1]} is this tool?");
                DisplayToolTypes(catInput);
                subInput = Convert.ToInt32(ReadLine()) - 1;
                WriteLine("Which tool do you want to borrow?");
                DisplayTools(catInput - 1, subInput);
                toolIndex = Convert.ToInt32(ReadLine()) - 1;
                aTool = GetTool(catInput - 1, subInput, toolIndex);
                //Call the below system method to add member to that tool's member collection
                Program.system.borrowTool(Program.system.loggedInMember, aTool);
            }
        }

        //Allows a user to select from a list of tools that they are borrowing to return and calls
        //the system's returnTool method() to do so
        public static void ReturnTool()
        {
            int toolIndex;
            Clear();
            //First make sure the user has tools in their collection to return by checking that at least
            //one element in their toolCollection is not null
            if(Program.system.loggedInMember.MyTools.Collection.Count(s => s != null) > 1)
            {
                WriteLine("You aren't borrowing any tools!");
                Thread.Sleep(2000);
                MemberMenu();
            }
            WriteLine("Please choose the tool that you wish to return\n");
            Program.system.displayBorrowingTools(Program.system.loggedInMember);
            Write("\nWhich tool do you want to return?: ");
            toolIndex = Convert.ToInt32(ReadLine()) - 1;
            //this method removes that member from the tool's membercollection and vice versa (second dec. saves first storing the tool as a variable to pass)
            Program.system.returnTool(Program.system.loggedInMember, Program.system.loggedInMember.MyTools.Collection[toolIndex]);
        }

        //Calls the system's displayBorrowingTools method to display a list of tools the member is currently borrowing
        public static void ListBorrowedTools()
        {
            Clear();
            WriteLine("Tools I currently have on loan:\n");
            Program.system.displayBorrowingTools(Program.system.loggedInMember);
            Write("\nPress any key to continue...");
            ReadKey();
            MemberMenu();
        }

        //Calls the system's displayTopThree method to display the top three most frequently borrowed tool by all members
        //in the system
        public static void DisplayTopThree()//is this the top three for the logged in member or for the whole system?
        {
            Program.system.displayTopThree();
        }

        /*---The following methods are all helper methods that assist the above user-facing methods---*/
        //A small method to grab the 'master' list of the 9 tool categories and display them in order
        public static void DisplayCategories()
        {
            for (int i = 0; i < toolCategories[0].Length; i++)
            {
                WriteLine($"{i + 1}): {toolCategories[0][i]}");
            }
        }

        //Given a category, displays all the different tool types in that category
        public static void DisplayToolTypes(int catInput)
        {
            for (int i = 0; i < toolCategories[catInput].Length; i++)
            {
                if (toolCategories[catInput][i] == null)
                {

                }
                else
                {
                    WriteLine($"{i + 1}): {toolCategories[catInput][i]}");
                }    
            }
        }

        //This method displays tools down to the individual level, allowing a user to browse tools in each given tool type
        //This method uses a switch statement to access the correct element of the TLS's ToolCollections for displaying to the user
        public static void DisplayTools(int catInput, int subInput)
        {
            TablePrinter table = new TablePrinter("Index", "Name", "Total Quantity", "No. Available", "Times Borrowed");//////////////////to implement!
            switch (catInput)
            {
                case 0://gardening tools
                    switch (subInput)
                    {
                        case 0:
                            //Given the input category and tool type, display all the tools in that ToolCollection
                            //linetrimmers
                            for (int i = 0; i < Program.system.gardeningTools.Count(); i++)
                            {
                                if (Program.system.gardeningTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.gardeningTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //lawnmowers
                            for (int i = 0; i < Program.system.gardeningTools.Count(); i++)
                            {
                                if (Program.system.gardeningTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.gardeningTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //handtools
                            for (int i = 0; i < Program.system.gardeningTools.Count(); i++)
                            {
                                if (Program.system.gardeningTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.gardeningTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3://wheelbarrows
                            for (int i = 0; i < Program.system.gardeningTools.Count(); i++)
                            {
                                if (Program.system.gardeningTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.gardeningTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //garden power tools
                            for (int i = 0; i < Program.system.gardeningTools.Count(); i++)
                            {
                                if (Program.system.gardeningTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.gardeningTools[4].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (subInput)//flooring tools
                    {
                        case 0:
                            Tool[] toolList = Program.system.flooringTools[0].Collection;
                            //iterate through the logged in member's toolCollection
                            int j = 0;
                            foreach (Tool tool in toolList)
                            {
                                if (tool != null)
                                {
                                    table.AddRow((j + 1).ToString(), toolList[j].Name, toolList[j].Quantity, toolList[j].AvailableQuantity, toolList[j].NoBorrowings);
                                    j++;
                                }
                            }
                            table.Print();
                            //flooringTools[0] is the index where the ToolCollection for scrapers is stored. Collection is the array of tools where the scrapers are stored.
                            //scrapers
                            //for (int i = 0; i < Program.system.flooringTools[0].Collection.Length; i++)
                            //{
                            //    if (Program.system.flooringTools[0].Collection[i] != null)
                            //    {
                            //        WriteLine($"{i + 1}): {Program.system.flooringTools[0].Collection[i]}");
                            //    }
                            //}
                            break;
                        case 1:
                            //floor lasers
                            for (int i = 0; i < Program.system.flooringTools[1].Collection.Length; i++)
                            {
                                if (Program.system.flooringTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.flooringTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //floor levelling tools
                            for (int i = 0; i < Program.system.flooringTools[2].Collection.Length; i++)
                            {
                                if (Program.system.flooringTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.flooringTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //floor levelling materials
                            for (int i = 0; i < Program.system.flooringTools[3].Collection.Length; i++)
                            {
                                if (Program.system.flooringTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.flooringTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //floor hand tools
                            for (int i = 0; i < Program.system.flooringTools[4].Collection.Length; i++)
                            {
                                if (Program.system.flooringTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.flooringTools[4].Collection[i]}");
                                }
                            }
                            break;
                        case 5:
                            //tiling tools
                            for (int i = 0; i < Program.system.flooringTools[5].Collection.Length; i++)
                            {
                                if (Program.system.flooringTools[5].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.flooringTools[5].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (subInput)//fencing tools
                    {
                        case 0:
                            //hand tools
                            for (int i = 0; i < Program.system.fencingTools[0].Collection.Length; i++)
                            {
                                if (Program.system.fencingTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.fencingTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //electric fencing
                            for (int i = 0; i < Program.system.fencingTools[1].Collection.Length; i++)
                            {
                                if (Program.system.fencingTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.fencingTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //steelfencing
                            for (int i = 0; i < Program.system.fencingTools[2].Collection.Length; i++)
                            {
                                if (Program.system.fencingTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.fencingTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //power tools
                            for (int i = 0; i < Program.system.fencingTools[3].Collection.Length; i++)
                            {
                                if (Program.system.fencingTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.fencingTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //fencing accessories
                            for (int i = 0; i < Program.system.fencingTools[4].Collection.Length; i++)
                            {
                                if (Program.system.fencingTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.fencingTools[4].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (subInput)//measuring tools
                    {
                        case 0:
                            //distance tools
                            for (int i = 0; i < Program.system.measuringTools[0].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //laser measurer
                            for (int i = 0; i < Program.system.measuringTools[1].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //measuring jugs
                            for (int i = 0; i < Program.system.measuringTools[2].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //temperature and humidity tools
                            for (int i = 0; i < Program.system.measuringTools[3].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //levelling tools
                            for (int i = 0; i < Program.system.measuringTools[4].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[4].Collection[i]}");
                                }
                            }
                            break;
                        case 5:
                            //markers
                            for (int i = 0; i < Program.system.measuringTools[5].Collection.Length; i++)
                            {
                                if (Program.system.measuringTools[5].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.measuringTools[5].Collection[i]}");
                                }
                            }
                            break;

                    }
                    break;
                case 4:
                    switch (subInput)//cleaning tools
                    {
                        case 0:
                            //draining
                            for (int i = 0; i < Program.system.cleaningTools[0].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //car cleaning
                            for (int i = 0; i < Program.system.cleaningTools[1].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //vacuum
                            for (int i = 0; i < Program.system.cleaningTools[2].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //pressure cleaners
                            for (int i = 0; i < Program.system.cleaningTools[3].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //pool cleaning
                            for (int i = 0; i < Program.system.cleaningTools[4].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[4].Collection[i]}");
                                }
                            }
                            break;
                        case 5:
                            //floor cleaning
                            for (int i = 0; i < Program.system.cleaningTools[5].Collection.Length; i++)
                            {
                                if (Program.system.cleaningTools[5].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.cleaningTools[5].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (subInput)//painting tools
                    {
                        case 0:
                            //sanding tools
                            for (int i = 0; i < Program.system.paintingTools[0].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //brushes
                            for (int i = 0; i < Program.system.paintingTools[1].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //rollers
                            for (int i = 0; i < Program.system.paintingTools[2].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //paint removal tools
                            for (int i = 0; i < Program.system.paintingTools[3].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //paint scrapers
                            for (int i = 0; i < Program.system.paintingTools[4].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[4].Collection[i]}");
                                }
                            }
                            break;
                        case 5:
                            //sprayers
                            for (int i = 0; i < Program.system.paintingTools[5].Collection.Length; i++)
                            {
                                if (Program.system.paintingTools[5].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.paintingTools[5].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (subInput)//electronic tools
                    {
                        case 0:
                            //voltage tester
                            for (int i = 0; i < Program.system.electronicTools[0].Collection.Length; i++)
                            {
                                if (Program.system.electronicTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electronicTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //oscilloscopes
                            for (int i = 0; i < Program.system.electronicTools[1].Collection.Length; i++)
                            {
                                if (Program.system.electronicTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electronicTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //thermal imaging
                            for (int i = 0; i < Program.system.electronicTools[2].Collection.Length; i++)
                            {
                                if (Program.system.electronicTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electronicTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //data test tool
                            for (int i = 0; i < Program.system.electronicTools[3].Collection.Length; i++)
                            {
                                if (Program.system.electronicTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electronicTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //insulation testers
                            for (int i = 0; i < Program.system.electronicTools[4].Collection.Length; i++)
                            {
                                if (Program.system.electronicTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electronicTools[4].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 7:
                    switch (subInput)//electricity tools
                    {
                        case 0:
                            //test equipment
                            for (int i = 0; i < Program.system.electricityTools[0].Collection.Length; i++)
                            {
                                if (Program.system.electricityTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electricityTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //safety equipment
                            for (int i = 0; i < Program.system.electricityTools[1].Collection.Length; i++)
                            {
                                if (Program.system.electricityTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electricityTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //basic hand tools
                            for (int i = 0; i < Program.system.electricityTools[2].Collection.Length; i++)
                            {
                                if (Program.system.electricityTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electricityTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //circuit protection
                            for (int i = 0; i < Program.system.electricityTools[3].Collection.Length; i++)
                            {
                                if (Program.system.electricityTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electricityTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //cable tools
                            for (int i = 0; i < Program.system.electricityTools[4].Collection.Length; i++)
                            {
                                if (Program.system.electricityTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.electricityTools[4].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
                case 8:
                    switch (subInput)//automotive tools
                    {
                        case 0:
                            //jacks
                            for (int i = 0; i < Program.system.automotiveTools[0].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[0].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[0].Collection[i]}");
                                }
                            }
                            break;
                        case 1:
                            //air compressors
                            for (int i = 0; i < Program.system.automotiveTools[1].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[1].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[1].Collection[i]}");
                                }
                            }
                            break;
                        case 2:
                            //battery chargers
                            for (int i = 0; i < Program.system.automotiveTools[2].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[2].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[2].Collection[i]}");
                                }
                            }
                            break;
                        case 3:
                            //socket tools
                            for (int i = 0; i < Program.system.automotiveTools[3].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[3].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[3].Collection[i]}");
                                }
                            }
                            break;
                        case 4:
                            //braking
                            for (int i = 0; i < Program.system.automotiveTools[4].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[4].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[4].Collection[i]}");
                                }
                            }
                            break;
                        case 5:
                            //drivetrain
                            for (int i = 0; i < Program.system.automotiveTools[5].Collection.Length; i++)
                            {
                                if (Program.system.automotiveTools[5].Collection[i] != null)
                                {
                                    WriteLine($"{i + 1}): {Program.system.automotiveTools[5].Collection[i]}");
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        //This method uses a switch statement, similarly to DisplayTools but instead does this invisibly to the user
        //to return a single specific tool to the method calling it make edits to (e.g., delete, inc/dec. quantity)
        public static Tool GetTool(int catInput, int subInput, int toolIndex)
        {
            Tool aTool = new Tool("name", 0, 0, 0);
            switch (catInput)
            {
                case 0:
                    switch (subInput)//gardening tools
                    {
                        case 0:
                            //linetrimmers
                            return Program.system.gardeningTools[0].Collection[toolIndex];
                        case 1:
                            //lawnmowers
                            return Program.system.gardeningTools[1].Collection[toolIndex];
                        case 2:
                            //handtools
                            return Program.system.gardeningTools[2].Collection[toolIndex];
                        case 3:
                            //wheelbarrows
                            return Program.system.gardeningTools[3].Collection[toolIndex];
                        case 4:
                            //garden power tools
                            return Program.system.gardeningTools[4].Collection[toolIndex];
                    }
                    break;
                case 1:
                    switch (subInput)//flooring tools
                    {
                        case 0:
                            //scrapers
                            return Program.system.flooringTools[0].Collection[toolIndex];
                        case 1:
                            //floor lasers
                            return Program.system.flooringTools[1].Collection[toolIndex];
                        case 2:
                            //floor levelling tools
                            return Program.system.flooringTools[2].Collection[toolIndex];
                        case 3:
                            //floor levelling materials
                            return Program.system.flooringTools[3].Collection[toolIndex];
                        case 4:
                            //floor hand tools
                            return Program.system.flooringTools[4].Collection[toolIndex];
                        case 5:
                            //tiling tools
                            return Program.system.flooringTools[5].Collection[toolIndex];
                    }
                    break;
                case 2:
                    switch (subInput)//fencing tools
                    {
                        case 0:
                            //hand tools
                            return Program.system.fencingTools[0].Collection[toolIndex];
                        case 1:
                            //electric fencing
                            return Program.system.fencingTools[1].Collection[toolIndex];
                        case 2:
                            //steelfencing
                            return Program.system.fencingTools[2].Collection[toolIndex];
                        case 3:
                            //power tools
                            return Program.system.fencingTools[3].Collection[toolIndex];
                        case 4:
                            //fencing accessories
                            return Program.system.fencingTools[4].Collection[toolIndex];
                    }
                    break;
                case 3:
                    switch (subInput)//measuring tools
                    {
                        case 0:
                            //distance tools
                            return Program.system.measuringTools[0].Collection[toolIndex];
                        case 1:
                            //laser measurer
                            return Program.system.measuringTools[1].Collection[toolIndex];
                        case 2:
                            //measuring jugs
                            return Program.system.measuringTools[2].Collection[toolIndex];
                        case 3:
                            //temperature and humidity tools
                            return Program.system.measuringTools[3].Collection[toolIndex];
                        case 4:
                            //levelling tools
                            return Program.system.measuringTools[4].Collection[toolIndex];
                        case 5:
                            //markers
                            return Program.system.measuringTools[5].Collection[toolIndex];

                    }
                    break;
                case 4:
                    switch (subInput)//cleaning tools
                    {
                        case 0:
                            //draining
                            return Program.system.cleaningTools[0].Collection[toolIndex];
                        case 1:
                            //car cleaning
                            return Program.system.cleaningTools[1].Collection[toolIndex];
                        case 2:
                            //vacuum
                            return Program.system.cleaningTools[2].Collection[toolIndex];
                        case 3:
                            //pressure cleaners
                            return Program.system.cleaningTools[3].Collection[toolIndex];
                        case 4:
                            //pool cleaning
                            return Program.system.cleaningTools[4].Collection[toolIndex];
                        case 5:
                            //floor cleaning
                            return Program.system.cleaningTools[5].Collection[toolIndex];
                    }
                    break;
                case 5:
                    switch (subInput)//painting tools
                    {
                        case 0:
                            //sanding tools
                            return Program.system.paintingTools[0].Collection[toolIndex];
                        case 1:
                            //brushes
                            return Program.system.paintingTools[1].Collection[toolIndex];
                        case 2:
                            //rollers
                            return Program.system.paintingTools[2].Collection[toolIndex];
                        case 3:
                            //paint removal tools
                            return Program.system.paintingTools[3].Collection[toolIndex];
                        case 4:
                            //paint scrapers
                            return Program.system.paintingTools[4].Collection[toolIndex];
                        case 5:
                            //sprayers
                            return Program.system.paintingTools[5].Collection[toolIndex];
                    }
                    break;
                case 6:
                    switch (subInput)//electronic tools
                    {
                        case 0:
                            //voltage tester
                            return Program.system.electronicTools[0].Collection[toolIndex];
                        case 1:
                            //oscilloscopes
                            return Program.system.electronicTools[1].Collection[toolIndex];
                        case 2:
                            //thermal imaging
                            return Program.system.electronicTools[2].Collection[toolIndex];
                        case 3:
                            //data test tool
                            return Program.system.electronicTools[3].Collection[toolIndex];
                        case 4:
                            //insulation testers
                            return Program.system.electronicTools[4].Collection[toolIndex];
                    }
                    break;
                case 7:
                    switch (subInput)//electricity tools
                    {
                        case 0:
                            //test equipment
                            return Program.system.electricityTools[0].Collection[toolIndex];
                        case 1:
                            //safety equipment
                            return Program.system.electricityTools[1].Collection[toolIndex];
                        case 2:
                            //basic hand tools
                            return Program.system.electricityTools[2].Collection[toolIndex];
                        case 3:
                            //circuit protection
                            return Program.system.electricityTools[3].Collection[toolIndex];
                        case 4:
                            //cable tools
                            return Program.system.electricityTools[4].Collection[toolIndex];
                    }
                    break;
                case 8:
                    switch (subInput)//automotive tools
                    {
                        case 0:
                            //jacks
                            return Program.system.automotiveTools[0].Collection[toolIndex];
                        case 1:
                            //air compressors
                            return Program.system.automotiveTools[1].Collection[toolIndex];
                        case 2:
                            //battery chargers
                            return Program.system.automotiveTools[2].Collection[toolIndex];
                        case 3:
                            //socket tools
                            return Program.system.automotiveTools[3].Collection[toolIndex];
                        case 4:
                            //braking
                            return Program.system.automotiveTools[4].Collection[toolIndex];
                        case 5:
                            //drivetrain
                            return Program.system.automotiveTools[5].Collection[toolIndex];
                    }
                    break;
            }
            return aTool;
        }
    }
}
