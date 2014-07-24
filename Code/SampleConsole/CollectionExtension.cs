using System;
using System.Collections.Generic;

namespace SampleConsole
{
    public static class CollectionExtension
    {
        public static void Iterate<T>(this IEnumerable<T> collection, Action<T> method) where T : class
        {
            var list = new List<T>();
            list.AddRange(collection);
            for (var i = 0; i < list.Count; i++)
            {
                var item = i < list.Count ? list[i] : default(T);
                if(item != default(T))
                    method(item);
            }
        }
    }

    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} Name: {1}", Id, Name);
        }
    }

    public class TestListExtension
    {

        public List<ListItem> InnerList { get; private set; }
    

        public TestListExtension()
        {
            LoadList();
        }

        private void LoadList()
        {
            InnerList = new List<ListItem>()
                {
                    new ListItem(){Id = 1, Name = "Oscar"},
                    new ListItem(){Id = 2, Name = "Mike"},
                    new ListItem(){Id = 3, Name = "Chris"},
                    new ListItem(){Id = 4, Name = "Hipolito"},
                    new ListItem(){Id = 5, Name = "Facundo"}
                };
        }

        /// <summary>
        /// Test the iteration of a collection adding 2 items
        /// </summary>
        public void TestIterationAddingItems()
        {
            LoadList();
            InnerList.Iterate(item =>
                {
                    if(item.Id == 3)
                        InnerList.Add(new ListItem()
                            {
                                Id = InnerList.Count + 1,
                                Name = string.Format("New Item Id {0}", InnerList.Count + 1)
                            });
                });
        }

        public void TestIterationRemoving1Item()
        {
            LoadList();
            InnerList.Iterate(RemoveItem);
        }

        private void RemoveItem(ListItem item)
        {
            if (item.Id == 2)
                InnerList.Remove(item);
        }
    }
}
