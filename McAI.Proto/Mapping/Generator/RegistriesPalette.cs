using McAI.Proto.Extentions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace McAI.Proto.Mapping.Generator
{
    public class RegistriesPalette
    {
        private readonly Dictionary<string, JsonRegistries> Registres;
        public RegistriesPalette()
        {
            string json = "registries.json".ReadResource();
            Registres = JsonConvert.DeserializeObject<Dictionary<string, JsonRegistries>>(json);
        }

        public void GenerateScript()
        {
            string key = "minecraft:";
            var intms = Registres["minecraft:item"].Entries.Count;

            StringBuilder codegenerator = new StringBuilder();
            foreach (var entity in Registres["minecraft:item"].Entries)
            {
                codegenerator.AppendLine($"{entity.Key.Substring(entity.Key.IndexOf(key) + key.Length)} = {entity.Value.Protocol_id},");
            }
            File.AppendAllText($"{Environment.CurrentDirectory}\\generatedItems.txt", codegenerator.ToString());
        }
    }
}
