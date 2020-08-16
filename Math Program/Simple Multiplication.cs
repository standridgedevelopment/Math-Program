using System;
//using System.Threading;

namespace Math_Program
{
    class User
    {
        public string name;
        public int pType; //type of problems
        public int questions;
        public int cDifficulty; //chosen difficulty
        // difficulties available
        public int difficulty;
        public int additionDifficulty = 1;
        public int subtractionDifficulty = 2;
        public int multiplicationDiffculty = 3;
        public int divisionDifficulty = 1;
        public int combinedDifficulty = 1;


        //Problem Type Selection
        public int problemType()
        {
            //Math Selection
            //1. Addition
            //2. Subtraction
            //3. Multiplication
            //4. Division
            //5. Combination
            Console.WriteLine("Please select to type of problem you'd like to solve\n");
            Console.WriteLine("1. Addition \n2. Subtraction \n3. Multiplication \n4. Divsion \n5. Combination\n");
            pType = Convert.ToInt32(Console.ReadLine());
            while (pType > 5)
            {
                Console.Clear();
                Console.WriteLine("Please make another selection");
                Console.WriteLine("\n1. Addition \n2. Subtraction \n3. Multiplication \n4. Divsion \n5. Combination\n");
                pType = Convert.ToInt32(Console.ReadLine());

            }
            return pType;
        }

        //How Many Questions
        public int how_many_questions()
        {
            Console.Clear();
            Console.WriteLine("How many problems would you like to solve?\n");
            questions = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (questions < 10)
            {
                Console.Clear();
                Console.WriteLine("Please select at least 10 problems to solve");
                questions = Convert.ToInt32(Console.ReadLine());
            }
            return questions;
        }

        //Difficulty Method
        public int Difficulty()
        {
            switch (pType)
            {
                case 1:
                    difficulty = additionDifficulty;
                    break;
                case 2:
                    difficulty = subtractionDifficulty;
                    break;
                case 3:
                    difficulty = multiplicationDiffculty;
                    break;
                case 4:
                    difficulty = divisionDifficulty;
                    break;
                case 5:
                    difficulty = combinedDifficulty;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Please select your difficulty");
            switch (difficulty)
            {
                case 1:
                    Console.WriteLine("\n1. Beginner");
                    cDifficulty = Convert.ToInt32(Console.ReadLine());
                    while (cDifficulty < 0 || cDifficulty > 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Please make another selection.");
                        Console.WriteLine("\n1. Beginner");
                        cDifficulty = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                case 2:
                    Console.WriteLine("\n1. Beginner \n2. Intermediate");
                    cDifficulty = Convert.ToInt32(Console.ReadLine());
                    while (cDifficulty < 0 || cDifficulty > 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Please make another selection.");
                        Console.WriteLine("\n1. Beginner \n Intermediate");
                        cDifficulty = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                case 3:
                    Console.WriteLine("\n1. Beginner \n2. Intermidiate \n3. Advanced");
                    cDifficulty = Convert.ToInt32(Console.ReadLine());
                    while (cDifficulty < 0 || cDifficulty > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Please make another selection.");
                        Console.WriteLine("\n1. Beginner \n2. Intermediate \n3. Advanced");
                        cDifficulty = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
            }
            return cDifficulty;
        }
        //Addition Module
        public void addition()
        {

            Console.WriteLine("Alright! Time for some addition problems! You've chosen " + questions + " problems. Let's get started!");

            int currentQuestion = 1;
            int correctAnswers = 0;

            while (currentQuestion <= questions)
            {
                Random numberGenerator = new Random();
                int num01 = 0;
                int num02 = 0;
                if (cDifficulty == 1)
                {
                    num01 = numberGenerator.Next(1, 10);
                    num02 = numberGenerator.Next(1, 10);
                }
                if (cDifficulty == 2)
                {
                    num01 = numberGenerator.Next(1, 100);
                    num02 = numberGenerator.Next(1, 100);
                }
                if (cDifficulty == 3)
                {
                    num01 = numberGenerator.Next(1, 1000);
                    num02 = numberGenerator.Next(1, 1000);
                }
                int total = num01 + num02;
                Console.WriteLine("Question " + currentQuestion + ":\n");
                Console.WriteLine("What is " + num01 + " + " + num02 + "?");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == total)
                {
                    correctAnswers += 1;
                    currentQuestion += 1;
                    Console.WriteLine ("Correct! Press any key for next question.");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (answer != total)
                {
                    currentQuestion += 1;
                    Console.WriteLine("Incorrect. Press any key for next question");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            double score = correctAnswers / questions;
            double percentage = score * 100;
            Console.WriteLine("You got " + percentage + "%");
            Console.ReadKey();
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                int pType;
                int questions; // amuont of questions
                int currentQuestion; //track current question number
                                     //Introduction
                User player = new User();
                Console.WriteLine("Hello and welcome to Math Challenge!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("What is your name?");
                player.name = Console.ReadLine();
                Console.Clear();

                pType = player.problemType();
                player.Difficulty();
                questions = player.how_many_questions();

                switch (pType)
                {
                case 1:
                    player.addition();
                    break;
                }
            
                
                    }
                }
        }
