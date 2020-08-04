﻿using System;

namespace Bost.Utils
{
    public enum Action
    {
        Exit = 0,
        CompileImage
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action action = Action.CompileImage;
            switch (action)
            {
                case Action.CompileImage:
                    CompileImage();
                    break;
            }
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