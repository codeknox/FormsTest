using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsTest
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;
        Random rnd = new Random();

        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>();
            for (int i = 0; i < 100; i++)
            {
                var desc = DateTime.Now.AddMinutes(i).ToString("F");
                string url = null;
                var title = "item";
                if (rnd.Next(20) < 10)
                {
                    for (int d = 0; d <= rnd.Next(9); d++)
                    {
                        title += " item";
                        desc = $"{desc} with {DateTime.Now.AddMinutes(i).ToString("F")}";
                    }
                }
                if (rnd.Next(10) < 6)
                {
                    url = $"http://unsplash.it/200/300/?image={i}";
                }
                _items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = $"{title} {i}", Description = desc, ImageUrl = url, PostTime = DateTime.Now - TimeSpan.FromMinutes(rnd.Next(100000)) });
            }
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is a nice description"},
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is a nice description"},
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is a nice description"},
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is a nice description"},
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is a nice description"},
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is a nice description"},
            //};

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
