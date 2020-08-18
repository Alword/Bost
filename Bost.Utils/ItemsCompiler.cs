using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Utils
{
    public class ItemsCompiler : IDisposable
    {
        private readonly string imagePath;
        public ItemsCompiler(string path)
        {
            this.imagePath = path;
        }

        public async Task Download()
        {
            using (HttpClient client = new HttpClient())
            {
                var itemsTask = GetItems(client);
                var pointsTask = GetPoints(client);
                Dictionary<string, string> itemIdItem = await itemsTask.ConfigureAwait(false);
                List<ItemPos> points = await pointsTask.ConfigureAwait(false);

                int itemSize = 32;
                int inlineCount = 28;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"{itemSize}");
                stringBuilder.AppendLine($"{inlineCount}");
                foreach (var p in points)
                {
                    stringBuilder.AppendLine($"{itemIdItem[p.Item]}");
                }
                File.WriteAllText("items.txt", stringBuilder.ToString());
            }
        }

        private static async Task<Dictionary<string, string>> GetItems(HttpClient client)
        {
            var content = client.GetStringAsync("https://minecraft-ids.grahamedgecombe.com/");

            var contentResult = await content;

            Dictionary<string, string> itemIdItem = new Dictionary<string, string>();
            var items = contentResult.Split("class=\"row\">")[1..];
            foreach (var item in items)
            {
                var split = item.Split(">");
                var name = split[8].Split("<")[0].Replace("(", "").Replace(")", "");
                var item_id = split[3].Split(" ")[2].Split("\"")[0];
                itemIdItem.Add(item_id, name);
            }

            return itemIdItem;
        }

        private static async Task<List<ItemPos>> GetPoints(HttpClient client)
        {
            var css = client.GetStringAsync("https://minecraft-ids.grahamedgecombe.com/stylesheets/bundles/all/1534075872.css");
            var cssResult = await css;
            var itemsPos = cssResult.Split(".items-")[1..];
            List<ItemPos> points = new List<ItemPos>(itemsPos.Length);
            foreach (var pos in itemsPos)
            {
                string name = $"items-{pos.Split("{")[0]}";
                var spaces = pos.Split(" ");
                int x = int.Parse(spaces[1].Replace("px", ""));
                int y = int.Parse(spaces[2].Replace("px", ""));
                points.Add(new ItemPos(name, x, y));
            }
            points = points.OrderByDescending(d => d.Y).ThenByDescending(d => d.X).ToList();
            return points;
        }

        public void Dispose()
        {
        }

        readonly struct ItemPos
        {
            public ItemPos(string item, int x, int y)
            {
                this.Item = item;
                this.X = x;
                this.Y = y;
            }
            public string Item { get; }
            public int X { get; }
            public int Y { get; }
        }
    }
}
