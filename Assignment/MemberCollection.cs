using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //MemberCollection class to hold a collection of member's; either those that are currently borrowing a specific tool
    //or all of those in the library. Members are stored using a Binary Search Tree object.
    public class MemberCollection : iMemberCollection
    {
        private Member[] collection = new Member[ToolLibrarySystem.ARRAY];
        private BSTree memberCollectionStruct = new BSTree();
        private int number;

        public Member[] Collection
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

        public BSTree MemberCollectionStruct
        {
            get
            {
                return memberCollectionStruct;
            }
        }

        // get the number of members in the community library
        public int Number
        {
            get
            {
                return number;
            }
        }

        public MemberCollection()
        {
            int count = 0;
            Collection = collection;
            for (int i = 0; i < ToolLibrarySystem.ARRAY; i++)
            {
                if (collection[i] != null)
                {
                    count++;
                }
            }
            number = count;//count not null values
        }

        //add a new member to this member collection, make sure there are no duplicates in the member collection
        public void add(Member aMember)
        {
            if (!memberCollectionStruct.Search(aMember))
            {
                memberCollectionStruct.Insert(aMember);
                number++;
            }
            else
            {
                Console.WriteLine($"This member '{aMember.FirstName}' already exists! Press any key to continue...");
                Console.ReadKey();
            }
        }//end add

        public void delete(Member aMember)//delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        {
            //call bstree delete method then just call toArray again to update the array? search the tree for a member that matches the one passed in and remove it from the tree?
            //check if any tools are on loan first
            if (search(aMember))
            {
                memberCollectionStruct.Delete(aMember);
                toArray();
            }
            else
            {
                Console.WriteLine("The member could not be found! Press any key to continue...");
                Console.ReadKey();
            }
        }//end delete

        //search a given member in this member collection. Return true if this member is in the member collection; return false otherwise
        public bool search(Member aMember)
        {
            return memberCollectionStruct.Search(aMember);
        }//end search

        //output the members in this collection to an array of Member
        public Member[] toArray()
        {
            Program.memberList.Clear();
            memberCollectionStruct.InOrderTraverse();
            Collection = Program.memberList.ToArray();
            return collection;
        }//end toArray
    }
}
