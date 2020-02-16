using System;
using System.Collections.Generic;

namespace MatrjoshkaProject
{
    class Program
    {
        class Matrjoshka
        {
            public static int Count = 0;
            string name;
            string color;
            int size;
            string image;

            public Matrjoshka(string _name, string _color, int _size, string _image)
            {
                name = _name;
                color = _color;
                Size = _size;
                image = _image;
                Count++;
            }

            public string Color
            {
                get { return color; }
            }

            public string Image
            {
                get { return image; }
            }


            public string Name
            {
                get { return name; }
            }

            public int Size
            {
                get { return size; }
                set
                {
                    if (value > 0 && value <= 10)
                    {
                        size = value;
                    }
                    else
                    {
                        size = 1;
                    }
                }
            }

            public Matrjoshka OpenMatrjoshka(string name, string color, string image)
            {
                Matrjoshka newMatrjoshka = new Matrjoshka(name, color, size - 2, image);
                return newMatrjoshka;
            }





        }

        static void Main(string[] args)
        {
            List<Matrjoshka> bogOfMatrioskas = new List<Matrjoshka>();
            Matrjoshka matrioska1 = new Matrjoshka("Matrioska1", "green", 10, "image1");
            bogOfMatrioskas.Add(matrioska1);
            //open matrioska
            Matrjoshka matrioska2 = matrioska1.OpenMatrjoshka("Matrioska2", "orange", "image2");
            bogOfMatrioskas.Add(matrioska2);

            Matrjoshka matrioska3 = matrioska2.OpenMatrjoshka("Matrioska3", "pink", "image3");
            bogOfMatrioskas.Add(matrioska3);

            Matrjoshka matrioska4 = matrioska3.OpenMatrjoshka("Matrioska4", "yellow", "image4");
            bogOfMatrioskas.Add(matrioska4);

            Matrjoshka matrioska5 = matrioska4.OpenMatrjoshka("Matrioska5", "blue", "image5");
            bogOfMatrioskas.Add(matrioska5);

            foreach (Matrjoshka matrioska in bogOfMatrioskas)
            {
                Console.WriteLine($"A {matrioska.Color} {matrioska.Name} is in the box ");
            }

            Console.WriteLine($"there are {Matrjoshka.Count} matrioskas in the box");

            //take a matrioska from the box
            Console.WriteLine("What color matrioska would you take from the box?");
            string userInput = Console.ReadLine();

            for (int i = 0; i < bogOfMatrioskas.Count; i++)
            {
                

                if (bogOfMatrioskas[i].Color == userInput)
                {
                    Console.WriteLine($"You have taken {bogOfMatrioskas[i].Name} from the box.");
                    bogOfMatrioskas.Remove(bogOfMatrioskas[i]);
                    break;
                }
                
            }
            foreach(Matrjoshka matrjoshka in bogOfMatrioskas)
            {
                
                Console.WriteLine($"Name: {matrjoshka.Name}, color: {matrjoshka.Color} is in the box");
            }


        }
    }
}
