using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPortfolio04_JordanCheung
{
    class Program
    {
        private static List<Pet> pets = new List<Pet>();
        static void Main(string[] args)
        {
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("| CPSC1012 Pet Clinic               |");
            Console.WriteLine("|-----------------------------------|");
            calculateDosage();


        }

        static string getName()
        {
            bool invalid = true;
            string name = "";

            while (invalid)
            {
                try
                {
                    Console.Write("Enter the name of your pet: ");
                    name = Console.ReadLine();

                    if (name == "")
                        Console.WriteLine("Invalid input value. A pet name is required and must contain at least one character.");
                    else
                        invalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return name;
        }

        static int getAge()
        {
            bool invalid = true;
            int age = 0;

            while (invalid)
            {
                try
                {
                    Console.Write("Enter the age in years of your pet: ");
                    age = int.Parse(Console.ReadLine());

                    if (age < 1)
                        Console.WriteLine("Invalid input value. Age must be at least 1 year old.");
                    else
                        invalid = false;

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return age;
        }

        static double getWeight()
        {
            bool invalid = true;
            double weight = 0;

            while (invalid)
            {
                try
                {
                    Console.Write("Enter the weight in pounds of your pet: ");
                    weight = double.Parse(Console.ReadLine());

                    if (weight < 5)
                        Console.WriteLine("Invalid input value. Weight must be at least 5 pounds");
                    else
                        invalid = false;

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return weight;
        }

        static char getType()
        {
            bool invalid = true;
            char c = 'o';

            while (invalid)
            {
                try
                {
                    Console.Write("Enter D for Dog, C for cat: ");
                    c = char.Parse(Console.ReadLine());
                    c = Char.ToLower(c);
                    if (c == 'd' || c == 'c')
                        invalid = false;
                    else
                        Console.WriteLine("Invalid input value. Pet type must be D or C");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return c;
        }

        static char getYorN(string prompt)
        {
            bool invalid = true;
            char c = 'c';

            while (invalid)
            {
                try
                {
                    Console.Write(prompt + " ");
                    c = char.Parse(Console.ReadLine().ToLower());

                    if (c == 'y' || c == 'n')
                        invalid = false;
                    else
                        Console.WriteLine("Invalid input value. Please choose between y or n");

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return c;
        }

        static int getService()
        {
            bool invalid = true;
            int n = 0;

            while (invalid)
            {
                try
                {
                    Console.Write("Enter the service (1-3) required for your pet: ");
                    n = int.Parse(Console.ReadLine());
                    if (n == 1 || n == 2 || n == 3)
                        invalid = false;
                    else
                        Console.WriteLine("Invalid input value. Choose between 1, 2, or 3");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return n;
        }

        static double Acepromazine(double n, char type)
        {
            double dosage = 0;

            if (type == 'd')
            {
                dosage = (n / 2.205) * (0.03 / 10);
            }
            else
            {
                dosage = (n / 2.205) * (0.002 / 10);
            }
            return dosage;
        }

        static double Carprofen(double n, char type)
        {
            double dosage = 0;
            if (type == 'd')
            {
                dosage = (n / 2.205) * (0.5 / 12);
            }
            else
            {
                dosage = (n / 2.205) * (0.25 / 12);
            }
            return dosage;
        }

        static Pet getPet()
        {
            var myPet = new Pet();
            myPet.setName(getName());
            myPet.setAge(getAge());
            myPet.setWeight(getWeight());
            myPet.setPetType(getType());
            return myPet;
        }

        static void calculateDosage()
        {
            string name = "", petType = "";
            int age = 0;
            double weight = 0;
            char type = 'o';

            pets.Add(getPet());

            pets.ForEach(pet =>
            {
                name = pet.getName();
                age = pet.getAge();
                weight = pet.getWeight();
                type = pet.getPetType();
            });

            if (type == 'd')
                petType = "Dog";
            else
                petType = "Cat";

            Console.Write($"Name: {name}, Age: {age} years, Weight: {weight} lbs, Type: {petType}");

            if (getYorN("\nIs the information above about your pet correct? Enter y or n:") == 'n')
            {
                calculateDosage();
            }
            else
            {
                Console.WriteLine("\nService Options:");
                Console.WriteLine("1.  Pain Killer");
                Console.WriteLine("2.  Sedative");
                Console.WriteLine("3.  Both Pain Killer and Sedative");
                int n = getService();

                if (n == 1)
                {
                    Console.WriteLine($"\nYour pet requires {Carprofen(weight, type):n3}ml of carprofen.");
                }
                else if (n == 2)
                {
                    Console.WriteLine($"\nYour pet requires {Acepromazine(weight, type):n3}ml of acepromazine.");
                }
                else
                {
                    Console.WriteLine($"\nYour pet requires {Carprofen(weight, type):n3}ml of carprofen.");
                    Console.WriteLine($"Your pet requires {Acepromazine(weight, type):n3}ml of acepromazine.");
                }
            }
            if (getYorN("\nDo you have another pet that requires service? Enter y or n:") == 'y'){
                Console.WriteLine(" ");
                calculateDosage();
            }
            else
                Console.WriteLine("Good-bye and thanks for coming to the pet clinic.");
        }
    }


    class Pet
    {
        private string name = "Super Pet";
        private char type = 'd';
        private int age = 1;
        private double weight = 5.0;

        public void setName(string n)
        {
            name = n;
        }

        public void setPetType(char n)
        {
            type = n;
        }

        public void setAge(int n)
        {
            age = n;
        }

        public void setWeight(double n)
        {
            weight = n;
        }

        public string getName()
        {
            return name;
        }

        public char getPetType()
        {
            return type;
        }

        public int getAge()
        {
            return age;
        }

        public double getWeight()
        {
            return weight;
        }
    }
}
