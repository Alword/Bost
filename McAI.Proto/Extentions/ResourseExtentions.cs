using System.IO;
using System.Linq;
using System.Reflection;

namespace Bost.Proto.Extentions
{
    public static class ResourseExtentions
    {
        public static string ReadResource(this string name)
        {
            // Determine path
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            // Format: "{Namespace}.{Folder}.{filename}.{Extension}"

            var x = assembly.GetManifestResourceNames();

            resourcePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(name));


            using Stream stream = assembly.GetManifestResourceStream(resourcePath);
            using System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
