using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace Assignment
{
    class Program
    {
        public static ToolLibrarySystem system = new ToolLibrarySystem();
        public static List<Member> memberList = new List<Member>();
        //parallel string array for each tool category here
        //null exception handling for magic number array size

        static void Main(string[] args)
        {
            //Initialisation for the various ToolCollections (to know which tool type each tool is)
            for (int i = 0; i < MenuSystem.toolCategories[1].Length; i++)
            {
                system.gardeningTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[2].Length; i++)
            {
                system.flooringTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[3].Length; i++)
            {
                system.fencingTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[4].Length; i++)
            {
                system.measuringTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[5].Length; i++)
            {
                system.cleaningTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[6].Length; i++)
            {
                system.paintingTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[7].Length; i++)
            {
                system.electronicTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[8].Length; i++)
            {
                system.electricityTools[i] = new ToolCollection();
            }
            for (int i = 0; i < MenuSystem.toolCategories[9].Length; i++)
            {
                system.automotiveTools[i] = new ToolCollection();
            }
            int userInput;
            //add default tools and members here
            Member kRudd = new Member("Kevin", "Rudd", "0449123456", "4478");
            Member aJury = new Member("Aarun", "Jury", "0449822334", "2937");
            Member sJobs = new Member("Steve", "Jobs", "555145925", "6025");
            Member eMusk = new Member("Elon", "Musk", "555495695", "8955");
            system.add(kRudd);
            system.add(aJury);
            system.add(sJobs);
            system.add(eMusk);
            //Program.system.loggedInMember = eMusk;
            Tool rake = new Tool("Bunnings Rake", 1, 1, 5);
            Tool roller = new Tool("Generic 300mm Roller", 5, 3, 12);
            Tool charger = new Tool("12v Battery Charger", 10, 6, 24);
            Tool socketset = new Tool("Kincrome 12pce Metric Socket Set", 2, 1, 4);
            Tool scraper = new Tool("Generic Handheld Scraper", 5, 5, 12);
            system.toolCollection.Collection[0] = rake;
            system.toolCollection.Collection[1] = roller;
            system.toolCollection.Collection[2] = charger;
            system.toolCollection.Collection[3] = socketset;
            system.toolCollection.Collection[4] = scraper;
            system.gardeningTools[2].Collection[0] = system.toolCollection.Collection[0];
            system.paintingTools[2].Collection[0] = system.toolCollection.Collection[1];
            system.automotiveTools[2].Collection[0] = system.toolCollection.Collection[2];
            system.automotiveTools[3].Collection[0] = system.toolCollection.Collection[3];
            system.flooringTools[0].Collection[0] = system.toolCollection.Collection[4];

            //Main functionality
            do
            {
                MenuSystem.MainMenu();
                userInput = Convert.ToInt32(ReadLine());
            }
            while (userInput != 0);
        }
    }
}
