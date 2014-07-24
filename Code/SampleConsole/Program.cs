using System;
using System.Collections.Generic;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //PLEASE DEBUG TO UNDERSTAND HOW IT WORKS
            var listTest = new TestListExtension();

            //This is a simple way to iterate fwd in a list
            Console.WriteLine("Simple list itearation");
            ShowList(listTest.InnerList);

            Console.WriteLine("Iterating the list after adding new items");
            listTest.TestIterationAddingItems();
            ShowList(listTest.InnerList);

            //Here is a sample on how to iterate in the list when removing 1 item
            Console.WriteLine("Iterating the list while removing 1 item");
            listTest.TestIterationRemoving1Item();
            ShowList(listTest.InnerList);

            Console.WriteLine();
            Console.Write("Press any key to exit... ");
            Console.ReadKey();

        }

        static void ShowList(IEnumerable<ListItem> list)
        {
            Console.WriteLine();
            list.Iterate(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
