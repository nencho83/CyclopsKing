using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            //first - player choses category from main Menu
            int category = ChoseCategory();

            //second - player enters name
            //name validation
            Console.Write("Enter yor name: ");
            string playerName = Console.ReadLine();
            NameValidation(playerName);

            //how many moves player has to pass the cube????
            int credits = 30;  //initial set credits to pass the cube
            for (int moves = 0; moves <= credits; moves++)
            {
                credits--;
                if (credits==0)
                {
                    //generates new cube with Random position
                    //Random gen = new Random();
                    //TheCube theCube = new theCube[9, 9, 9];
                    credits = 30;
                }
            }

            Player playerAtBegiining = new Player(playerName, credits, category);

        }

        static int ChoseCategory()
        {
            Console.WriteLine("Category Menu: \n1 - CSharp quiz \n2 - Science quiz \n3 - Music/Film quiz");
            int category = int.Parse(Console.ReadLine());
            switch (category)
            {
                case 1: category = 1; break;
                case 2: category = 2; break;
                case 3: category = 3; break;
                default: break;
            }
            return category;
        }

        static void NameValidation(string name)
        {
            if (!Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success)
            {
                Console.WriteLine("Invalid input! Please enter your name with captal, using letters only!");
            }

        }
    }



    public class Player
    {
        private string name;
        private int credits;
        private int category;

        public Player(string name, int credits, int category)
        {
            this.name = name;
            this.credits = credits;
            this.category = category;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Credits
        {
            get { return this.credits; }
            set { this.credits = value; }
        }

        public int Category
        {
            set { this.category = int.Parse(Console.ReadLine()); }
        }
    }
}
