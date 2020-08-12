using System;

namespace Bost.Utils
{
    public enum Action
    {
        Exit = 0,
        CompileImage,
        Test,
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action action = Action.Test;
            switch (action)
            {
                case Action.CompileImage:
                    CompileImage();
                    break;
                case Action.Test:
                    Test();
                    break;
            }
        }
        private static void Test()
        {
            string path = "AppData/oak_log.png";
            string top = "AppData/oak_log_top.png";
            ImageRotator imageRotator = new ImageRotator();
            imageRotator.GetLeftSide(path, top);
        }
        private static void CompileImage()
        {
            //string path = Console.Readline();
            string path = @"C:\Users\Artyom\Downloads\1\assets\minecraft\textures\item";
            using (var itemsCompiler = new ItemsCompiler(path))
            {
                itemsCompiler.Compile();
            }
        }
    }
}
