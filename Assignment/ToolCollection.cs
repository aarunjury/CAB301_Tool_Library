using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //ToolCollection class to hold a collection of tools, either for the whole library system or
    //for a member's own collection of borrowed tools. All tools are stored in the 'system/master' ToolCollection
    //with each category and tool type having its own toolCollection pointing to the actual tool stored in the master
    public class ToolCollection : iToolCollection
    {
        private int number;
        private Tool[] collection = new Tool[ToolLibrarySystem.ARRAY];

        //number of tools in a given toolcollection tool array
        public int Number
        {
            get
            {
                return number;
            }
        }

        public Tool[] Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }

        public ToolCollection ()
        {
            number = 0;
        }

        //add a given tool to this tool collection
        public void add(Tool aTool)
        {
            int index = 0;
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == null)
                {
                    collection[i] = aTool;
                    index = i;
                    break;
                }
            };
        }//end add

        //delete a given tool from this tool collection
        public void delete(Tool aTool)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == aTool)
                {
                    collection[i] = null;
                    aTool = null;
                    break;
                }
            };
        }//end delete

        public bool search(Tool aTool)//search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        {
            bool returnVal = false;
            for (int i = 0; i < Collection.Count(); i++)
            {
                if (Collection[i] == aTool)
                {
                    returnVal = true;
                }
                else
                {
                    returnVal = false;
                }
            }
            return returnVal;
        }//end search

        //output the tools in this tool collection to an array of Tool
        public Tool[] toArray()
        {
            return collection;
        }//end toArray
    }//end ToolCollection
}
