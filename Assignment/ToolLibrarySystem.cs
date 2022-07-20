using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        //Defines a maximum size for the tool and memberCollections
        public const int ARRAY = 30;
        //Create a new MemberCollection which all store all the members in the library
        public MemberCollection memberCollection = new MemberCollection();//make these private and access using get and set?
        //Create a new TooLCollection which all store all the tools in the library
        public ToolCollection toolCollection = new ToolCollection();
        //Define new arrays of ToolCollection, one for up to the maximum number of types per category
        public ToolCollection[] gardeningTools = new ToolCollection[6];//[0]=linetrimmers ToolCollection,[1]=lawnmowers etc
        public ToolCollection[] flooringTools = new ToolCollection[6];
        public ToolCollection[] fencingTools = new ToolCollection[6];
        public ToolCollection[] measuringTools = new ToolCollection[6];
        public ToolCollection[] cleaningTools = new ToolCollection[6];
        public ToolCollection[] paintingTools = new ToolCollection[6];
        public ToolCollection[] electronicTools = new ToolCollection[6];
        public ToolCollection[] electricityTools = new ToolCollection[6];
        public ToolCollection[] automotiveTools = new ToolCollection[6];
        //Create an instance of member to store the changes made while the user carries out operations.
        //Because we can't write to an external file, all changes will be discarded when the loggedInMember is reset
        //on MemberMenu exit but it would be simple to write the system state to a csv at certain points
        public Member loggedInMember = new Member("First", "Last", "0", "0");

        //Add a new tool to the library. Default quantity is 1 and a user can go to the IncreaseToolQuantityMenu to
        //change it if more than one is being added.
        public void add(Tool aTool)
        {
            int catInput;
            int subInput;
            aTool.Quantity = 1;
            aTool.AvailableQuantity = 1;
            WriteLine("What category does this tool belong to?");
            MenuSystem.DisplayCategories();
            catInput = Convert.ToInt32(ReadLine());
            //saves declaring another variable to store the same information stored at the below location
            WriteLine(MenuSystem.toolCategories[0][catInput - 1]);
            WriteLine($"What tool type from {MenuSystem.toolCategories[0][catInput - 1]} is this tool?");
            MenuSystem.DisplayToolTypes(catInput);
            subInput = Convert.ToInt32(ReadLine()) - 1;
            WriteLine(MenuSystem.toolCategories[catInput][subInput]);
            //First, add the tool to the TLS's Tool Collection
            toolCollection.add(aTool);
            //Now also add a pointer to the tool to the appropriate categorised tool collection
            switch (catInput - 1)
            {
                case 0:
                    switch (subInput)//gardening tools
                    {
                        case 0:
                            //insert aTool(linetrimmer) into next index 0 (for lineTrimmers, being the first item in gardening tools)
                            //linetrimmers
                            for (int i = 0; i < gardeningTools.Count(); i++)
                            {
                                if (gardeningTools[0].Collection[i] == null)
                                {
                                    gardeningTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //lawnmowers
                            for (int i = 0; i < gardeningTools.Count(); i++)
                            {
                                if (gardeningTools[1].Collection[i] == null)
                                {
                                    gardeningTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //handtools
                            for (int i = 0; i < gardeningTools.Count(); i++)
                            {
                                if (gardeningTools[2].Collection[i] == null)
                                {
                                    gardeningTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //wheelbarrows
                            for (int i = 0; i < gardeningTools.Count(); i++)
                            {
                                if (gardeningTools[3].Collection[i] == null)
                                {
                                    gardeningTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //garden power tools
                            for (int i = 0; i < gardeningTools.Count(); i++)
                            {
                                if (gardeningTools[4].Collection[i] == null)
                                {
                                    gardeningTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (subInput)//flooring tools
                    {
                        case 0:
                            //scrapers
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[0].Collection[i] == null)
                                {
                                    flooringTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //floor lasers
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[1].Collection[i] == null)
                                {
                                    flooringTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //floor levelling tools
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[2].Collection[i] == null)
                                {
                                    flooringTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //floor levelling materials
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[3].Collection[i] == null)
                                {
                                    flooringTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //floor hand tools
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[4].Collection[i] == null)
                                {
                                    flooringTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 5:
                            //tiling tools
                            for (int i = 0; i < flooringTools.Count(); i++)
                            {
                                if (flooringTools[5].Collection[i] == null)
                                {
                                    flooringTools[5].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < fencingTools.Count(); i++)
                            {
                                if (fencingTools[0].Collection[i] == null)
                                {
                                    fencingTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //electric fencing
                            for (int i = 0; i < fencingTools.Count(); i++)
                            {
                                if (fencingTools[1].Collection[i] == null)
                                {
                                    fencingTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //steelfencing
                            for (int i = 0; i < fencingTools.Count(); i++)
                            {
                                if (fencingTools[2].Collection[i] == null)
                                {
                                    fencingTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //power tools
                            for (int i = 0; i < fencingTools.Count(); i++)
                            {
                                if (fencingTools[3].Collection[i] == null)
                                {
                                    fencingTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //fencing accessories
                            for (int i = 0; i < fencingTools.Count(); i++)
                            {
                                if (fencingTools[4].Collection[i] == null)
                                {
                                    fencingTools[4].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[0].Collection[i] == null)
                                {
                                    measuringTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //laser measurer
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[1].Collection[i] == null)
                                {
                                    measuringTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //measuring jugs
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[2].Collection[i] == null)
                                {
                                    measuringTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //temperature and humidity tools
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[3].Collection[i] == null)
                                {
                                    measuringTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //levelling tools
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[4].Collection[i] == null)
                                {
                                    measuringTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 5:
                            //markers
                            for (int i = 0; i < measuringTools.Count(); i++)
                            {
                                if (measuringTools[5].Collection[i] == null)
                                {
                                    measuringTools[5].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[0].Collection[i] == null)
                                {
                                    cleaningTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //car cleaning
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[1].Collection[i] == null)
                                {
                                    cleaningTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //vacuum
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[2].Collection[i] == null)
                                {
                                    cleaningTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //pressure cleaners
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[3].Collection[i] == null)
                                {
                                    cleaningTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //pool cleaning
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[4].Collection[i] == null)
                                {
                                    cleaningTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 5:
                            //floor cleaning
                            for (int i = 0; i < cleaningTools.Count(); i++)
                            {
                                if (cleaningTools[5].Collection[i] == null)
                                {
                                    cleaningTools[5].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[0].Collection[i] == null)
                                {
                                    paintingTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //brushes
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[1].Collection[i] == null)
                                {
                                    paintingTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //rollers
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[2].Collection[i] == null)
                                {
                                    paintingTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //paint removal tools
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[3].Collection[i] == null)
                                {
                                    paintingTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //paint scrapers
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[4].Collection[i] == null)
                                {
                                    paintingTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 5:
                            //sprayers
                            for (int i = 0; i < paintingTools.Count(); i++)
                            {
                                if (paintingTools[5].Collection[i] == null)
                                {
                                    paintingTools[5].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < electronicTools.Count(); i++)
                            {
                                if (electronicTools[0].Collection[i] == null)
                                {
                                    electronicTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //oscilloscopes
                            for (int i = 0; i < electronicTools.Count(); i++)
                            {
                                if (electronicTools[1].Collection[i] == null)
                                {
                                    electronicTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //thermal imaging
                            for (int i = 0; i < electronicTools.Count(); i++)
                            {
                                if (electronicTools[2].Collection[i] == null)
                                {
                                    electronicTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //data test tool
                            for (int i = 0; i < electronicTools.Count(); i++)
                            {
                                if (electronicTools[3].Collection[i] == null)
                                {
                                    electronicTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //insulation testers
                            for (int i = 0; i < electronicTools.Count(); i++)
                            {
                                if (electronicTools[4].Collection[i] == null)
                                {
                                    electronicTools[4].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < electricityTools.Count(); i++)
                            {
                                if (electricityTools[0].Collection[i] == null)
                                {
                                    electricityTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //safety equipment
                            for (int i = 0; i < electricityTools.Count(); i++)
                            {
                                if (electricityTools[1].Collection[i] == null)
                                {
                                    electricityTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //basic hand tools
                            for (int i = 0; i < electricityTools.Count(); i++)
                            {
                                if (electricityTools[2].Collection[i] == null)
                                {
                                    electricityTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //circuit protection
                            for (int i = 0; i < electricityTools.Count(); i++)
                            {
                                if (electricityTools[3].Collection[i] == null)
                                {
                                    electricityTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //cable tools
                            for (int i = 0; i < electricityTools.Count(); i++)
                            {
                                if (electricityTools[4].Collection[i] == null)
                                {
                                    electricityTools[4].Collection[i] = aTool;
                                    break;
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
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[0].Collection[i] == null)
                                {
                                    automotiveTools[0].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 1:
                            //air compressors
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[1].Collection[i] == null)
                                {
                                    automotiveTools[1].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 2:
                            //battery chargers
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[2].Collection[i] == null)
                                {
                                    automotiveTools[2].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 3:
                            //socket tools
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[3].Collection[i] == null)
                                {
                                    automotiveTools[3].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 4:
                            //braking
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[4].Collection[i] == null)
                                {
                                    automotiveTools[4].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                        case 5:
                            //drivetrain
                            for (int i = 0; i < automotiveTools.Count(); i++)
                            {
                                if (automotiveTools[5].Collection[i] == null)
                                {
                                    automotiveTools[5].Collection[i] = aTool;
                                    break;
                                }
                            }
                            break;
                    }
                    break;
            }
            WriteLine($"Success! This tool {aTool.Name} has been added to the Tool Library!");
            Thread.Sleep(2000);
            MenuSystem.StaffMenu();
        }//end add

        public void add(Tool aTool, int quantity)//add new pieces of an existing tool to the system
        {
            aTool.Quantity += quantity;
            aTool.AvailableQuantity += quantity;
            WriteLine($"Success! This tool {aTool.Name}'s quantity has been updated to {aTool.Quantity}!");
            WriteLine("Press any key to continue...");
            ReadKey();
            MenuSystem.StaffMenu();
        }//end add

        //This method is called when a member navigates through the menu to borrow a new tool from the library
        public void borrowTool(Member aMember, Tool aTool)//a member borrows a tool from the tool library
        {
            //Check to skip over null elements in the TLS ToolCollection
            for (int i = 0; i < toolCollection.Collection.Count(); i++)
            {
                if (toolCollection.Collection[i] != null)
                {
                    //If the given tool matches one in the TLS ToolCollection and there's 1 or more available
                    //to borrow, update the relevant properties
                    if (toolCollection.Collection[i].CompareTo(aTool) == 0)
                    {
                        aTool = toolCollection.Collection[i];
                        if (aTool.AvailableQuantity < 1)
                        {
                            WriteLine("There's none of this tool left available to borrow!");
                            Thread.Sleep(2000);
                            MenuSystem.MemberMenu();
                        }
                        else
                        {
                            //Remove 1 from that tool's Available Quantity and increase it's "times borrowed" counter
                            toolCollection.Collection[i].AvailableQuantity--;
                            toolCollection.Collection[i].NoBorrowings++;
                            //Now loop through the member's own ToolCollection and point the first available element to the
                            //location of the tool in the TLS ToolCollection
                            for (int j = 0; j < aMember.MyTools.Collection.Count(); j++)
                            {
                                //Find an empty element in the member's ToolCollection to add the newly borrowed tool to
                                if (aMember.MyTools.Collection[j] == null)
                                {
                                    //add a pointer of the tool to the member's toolCollection
                                    aMember.MyTools.Collection[j] = toolCollection.Collection[i];
                                    //update the copy of the passed in tool back to the actual tool location (probably not necessary from an OOP perspective
                                    //as per below when adding the member to the tool's memberCollection)
                                    aTool = toolCollection.Collection[i];
                                    break;
                                }
                            }
                            //add the member to the tool's member collection
                            for (int k = 0; k < aTool.GetBorrowers.Collection.Count(); k++)
                            {
                                if (aTool.GetBorrowers.Collection[i] == null)
                                {
                                    aTool.GetBorrowers.Collection[i] = aMember;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            WriteLine($"Tool '{aTool.Name}' successfully borrowed!");
            Thread.Sleep(2000);
            MenuSystem.MemberMenu();
        }//end borrowTool

        //delete a given tool from the system
        public void delete(Tool aTool, int catInput, int subInput)
        {
            for (int j = 0; j < toolCollection.Collection.Count(); j++)
            {
                if (toolCollection.Collection[j] != null)
                {
                    if (aTool == toolCollection.Collection[j])
                    {
                        toolCollection.Collection[j] = null;
                        switch (catInput - 1)
                        {
                            case 0:
                                switch (subInput)//gardening tools
                                {
                                    case 0:
                                        //insert aTool(linetrimmer) into next index 0 (for lineTrimmers, being the first item in gardening tools)
                                        //linetrimmers
                                        for (int i = 0; i < gardeningTools.Count(); i++)
                                        {
                                            if (gardeningTools[0].Collection[i] == aTool)
                                            {
                                                gardeningTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //lawnmowers
                                        for (int i = 0; i < gardeningTools.Count(); i++)
                                        {
                                            if (gardeningTools[1].Collection[i] == aTool)
                                            {
                                                gardeningTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //handtools
                                        for (int i = 0; i < gardeningTools.Count(); i++)
                                        {
                                            if (gardeningTools[2].Collection[i] == aTool)
                                            {
                                                gardeningTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //wheelbarrows
                                        for (int i = 0; i < gardeningTools.Count(); i++)
                                        {
                                            if (gardeningTools[3].Collection[i] == aTool)
                                            {
                                                gardeningTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //garden power tools
                                        for (int i = 0; i < gardeningTools.Count(); i++)
                                        {
                                            if (gardeningTools[4].Collection[i] == aTool)
                                            {
                                                gardeningTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                }
                                break;
                            case 1:
                                switch (subInput)//flooring tools
                                {
                                    case 0:
                                        //scrapers
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[0].Collection[i] == aTool)
                                            {
                                                flooringTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //floor lasers
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[1].Collection[i] == aTool)
                                            {
                                                flooringTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //floor levelling tools
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[2].Collection[i] == aTool)
                                            {
                                                flooringTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //floor levelling materials
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[3].Collection[i] == aTool)
                                            {
                                                flooringTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //floor hand tools
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[4].Collection[i] == aTool)
                                            {
                                                flooringTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        //tiling tools
                                        for (int i = 0; i < flooringTools.Count(); i++)
                                        {
                                            if (flooringTools[5].Collection[i] == aTool)
                                            {
                                                flooringTools[5].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < fencingTools.Count(); i++)
                                        {
                                            if (fencingTools[0].Collection[i] == aTool)
                                            {
                                                fencingTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //electric fencing
                                        for (int i = 0; i < fencingTools.Count(); i++)
                                        {
                                            if (fencingTools[1].Collection[i] == aTool)
                                            {
                                                fencingTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //steelfencing
                                        for (int i = 0; i < fencingTools.Count(); i++)
                                        {
                                            if (fencingTools[2].Collection[i] == aTool)
                                            {
                                                fencingTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //power tools
                                        for (int i = 0; i < fencingTools.Count(); i++)
                                        {
                                            if (fencingTools[3].Collection[i] == aTool)
                                            {
                                                fencingTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //fencing accessories
                                        for (int i = 0; i < fencingTools.Count(); i++)
                                        {
                                            if (fencingTools[4].Collection[i] == aTool)
                                            {
                                                fencingTools[4].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[0].Collection[i] == aTool)
                                            {
                                                measuringTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //laser measurer
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[1].Collection[i] == aTool)
                                            {
                                                measuringTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //measuring jugs
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[2].Collection[i] == aTool)
                                            {
                                                measuringTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //temperature and humidity tools
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[3].Collection[i] == aTool)
                                            {
                                                measuringTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //levelling tools
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[4].Collection[i] == aTool)
                                            {
                                                measuringTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        //markers
                                        for (int i = 0; i < measuringTools.Count(); i++)
                                        {
                                            if (measuringTools[5].Collection[i] == aTool)
                                            {
                                                measuringTools[5].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[0].Collection[i] == aTool)
                                            {
                                                cleaningTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //car cleaning
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[1].Collection[i] == aTool)
                                            {
                                                cleaningTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //vacuum
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[2].Collection[i] == aTool)
                                            {
                                                cleaningTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //pressure cleaners
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[3].Collection[i] == aTool)
                                            {
                                                cleaningTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //pool cleaning
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[4].Collection[i] == aTool)
                                            {
                                                cleaningTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        //floor cleaning
                                        for (int i = 0; i < cleaningTools.Count(); i++)
                                        {
                                            if (cleaningTools[5].Collection[i] == aTool)
                                            {
                                                cleaningTools[5].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[0].Collection[i] == aTool)
                                            {
                                                paintingTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //brushes
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[1].Collection[i] == aTool)
                                            {
                                                paintingTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //rollers
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[2].Collection[i] == aTool)
                                            {
                                                paintingTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //paint removal tools
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[3].Collection[i] == aTool)
                                            {
                                                paintingTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //paint scrapers
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[4].Collection[i] == aTool)
                                            {
                                                paintingTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        //sprayers
                                        for (int i = 0; i < paintingTools.Count(); i++)
                                        {
                                            if (paintingTools[5].Collection[i] == aTool)
                                            {
                                                paintingTools[5].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < electronicTools.Count(); i++)
                                        {
                                            if (electronicTools[0].Collection[i] == aTool)
                                            {
                                                electronicTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //oscilloscopes
                                        for (int i = 0; i < electronicTools.Count(); i++)
                                        {
                                            if (electronicTools[1].Collection[i] == aTool)
                                            {
                                                electronicTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //thermal imaging
                                        for (int i = 0; i < electronicTools.Count(); i++)
                                        {
                                            if (electronicTools[2].Collection[i] == aTool)
                                            {
                                                electronicTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //data test tool
                                        for (int i = 0; i < electronicTools.Count(); i++)
                                        {
                                            if (electronicTools[3].Collection[i] == aTool)
                                            {
                                                electronicTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //insulation testers
                                        for (int i = 0; i < electronicTools.Count(); i++)
                                        {
                                            if (electronicTools[4].Collection[i] == aTool)
                                            {
                                                electronicTools[4].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < electricityTools.Count(); i++)
                                        {
                                            if (electricityTools[0].Collection[i] == aTool)
                                            {
                                                electricityTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //safety equipment
                                        for (int i = 0; i < electricityTools.Count(); i++)
                                        {
                                            if (electricityTools[1].Collection[i] == aTool)
                                            {
                                                electricityTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //basic hand tools
                                        for (int i = 0; i < electricityTools.Count(); i++)
                                        {
                                            if (electricityTools[2].Collection[i] == aTool)
                                            {
                                                electricityTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //circuit protection
                                        for (int i = 0; i < electricityTools.Count(); i++)
                                        {
                                            if (electricityTools[3].Collection[i] == aTool)
                                            {
                                                electricityTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //cable tools
                                        for (int i = 0; i < electricityTools.Count(); i++)
                                        {
                                            if (electricityTools[4].Collection[i] == aTool)
                                            {
                                                electricityTools[4].Collection[i] = null;
                                                break;
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
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[0].Collection[i] == aTool)
                                            {
                                                automotiveTools[0].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        //air compressors
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[1].Collection[i] == aTool)
                                            {
                                                automotiveTools[1].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        //battery chargers
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[2].Collection[i] == aTool)
                                            {
                                                automotiveTools[2].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        //socket tools
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[3].Collection[i] == aTool)
                                            {
                                                automotiveTools[3].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        //braking
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[4].Collection[i] == aTool)
                                            {
                                                automotiveTools[4].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        //drivetrain
                                        for (int i = 0; i < automotiveTools.Count(); i++)
                                        {
                                            if (automotiveTools[5].Collection[i] == aTool)
                                            {
                                                automotiveTools[5].Collection[i] = null;
                                                break;
                                            }
                                        }
                                        break;
                                }
                                break;
                        }
                        //toolCollection.Collection = toolCollection.Collection.Where((source, index) => index != i).ToArray();
                        break;
                    }
                }
            }
        }//end delete

        public void delete(Tool aTool, int quantity, int catInput, int subInput)//remove some pieces of a tool from the system
        {
            //do a check to confirm the tool is in the library
            for (int i = 0; i < toolCollection.Collection.Count(); i++)
            {
                if (toolCollection.Collection[i] != null)
                {
                    if (toolCollection.Collection[i] == aTool)
                    {
                        //once found, check to see if the user isn't trying to remove a tool that has one or more copy out on loan
                        //then confirm the user isn't trying to remove more tools than exist at all
                        if (quantity > aTool.Quantity)
                        {
                            WriteLine($"There aren't enough {toolCollection.Collection[i].Name}'s in stock to perform that action!");
                            WriteLine("Negative stock is not allowed. Please try something else.");
                            Thread.Sleep(20000);
                            MenuSystem.StaffMenu();
                        }
                        //if the entire quantity is being removed, go ahead and delete the tool
                        else if (quantity == aTool.Quantity)
                        {
                            delete(aTool, catInput, subInput - 1);
                            WriteLine($"Success! This tool '{aTool.Name}'has been deleted!");
                            WriteLine("Press any key to continue...");
                            ReadKey();
                            MenuSystem.StaffMenu();
                        }
                        //otherwise just update the quantity
                        else
                        {
                            aTool.Quantity -= quantity;
                            aTool.AvailableQuantity -= quantity;
                        }
                    }
                }
            }
            WriteLine($"Success! This tool {aTool.Name}'s quantity has been updated to {aTool.Quantity}!");
            WriteLine("Press any key to continue...");
            ReadKey();
            MenuSystem.StaffMenu();
        }//end delete

        //add a new member to the system by adding them to the BST and calling the BST 'add' routine
        public void add(Member aMember)//add a new member to the system
        {
            Program.system.memberCollection.add(aMember);
        }//end add

        //delete a member from the system by removing them from the BST
        public void delete(Member aMember)
        {
            Program.system.memberCollection.delete(aMember);
        }//end delete

        //given a member, display all the tools that the member are currently renting
        public void displayBorrowingTools(Member aMember)
        {
            Tool[] toolList = aMember.MyTools.Collection;
            TablePrinter table = new TablePrinter("Index", "Name", "Total Quantity", "No. Available", "Times Borrowed");
            //iterate through the logged in member's toolCollection
            int i = 1;
            foreach (Tool tool in toolList)
            {
                if (tool != null)
                {
                    table.AddRow(i.ToString(), tool.Name, tool.Quantity, tool.AvailableQuantity, tool.NoBorrowings);
                    i++;
                }
            }
            table.Print();
        }//end displayBorrowingTools

        public void displayTools(string aToolType)// display all the tools of a tool type selected by a member
        {
            for (int i = 0; i < MenuSystem.toolCategories.Length; i++)
            {
                if (aToolType == MenuSystem.toolCategories[i][i])
                {
                    MenuSystem.DisplayTools(i, i);
                }
            }
        }//end displayTools

        //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.
        public void displayTopThree()
        {
            Clear();
            Tool[] sortedToolArr = toolCollection.Collection;
            HeapSortObj.HeapSort(sortedToolArr);
            for (int i = 4; i < 30; i++)
            {
                sortedToolArr[i] = null;
            }
            TablePrinter table = new TablePrinter("Rank", "Name", "Total Quantity", "No. Available", "Times Borrowed");
            int j = 1;
            for (int i = 3; i > 0; i--)
            {
                    table.AddRow(j.ToString(), sortedToolArr[i].Name, sortedToolArr[i].Quantity, sortedToolArr[i].AvailableQuantity, sortedToolArr[i].NoBorrowings);
                    j++;
            }
            table.Print();
            WriteLine("Press any key to continue...");
            ReadKey();
            MenuSystem.MemberMenu();
        }//end displayTopThree

        //get a list of tools that are currently held by a given member
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }//end listTools

        //Iterates through the currently logged in member's toolCollection, ignoring null elements
        //if the passed in tool matches one in the member's collection, remove it
        public void returnTool(Member aMember, Tool aTool)//a member return a tool to the tool library
        {
            for (int i = 0; i < loggedInMember.MyTools.Collection.Count(); i++)
            {
                if (loggedInMember.MyTools.Collection[i] == null)
                {

                }
                else
                {
                    if (aTool == loggedInMember.MyTools.Collection[i])
                    {
                        aTool.AvailableQuantity++;
                        loggedInMember.MyTools.Collection[i] = null;
                        for (int j = 0; j < aTool.GetBorrowers.Collection.Count(); j++)
                        {
                            if (aTool.GetBorrowers.Collection[j] == aMember)
                            {
                                aTool.GetBorrowers.Collection[j] = null;
                            }
                        }
                        //Remove the borrowing member from the tool's memberCollection
                        aTool.GetBorrowers.Collection[i] = null;
                    }
                }
            }
            WriteLine("\nTool successfully returned!");
            Thread.Sleep(2000);
            MenuSystem.MemberMenu();
        }//end returnTool
    }//end ToolLibrarySystem
}
