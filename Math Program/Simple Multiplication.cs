using System;
//using System.Threading;

namespace Math_Program
{
    class User
    {
        public string name;
        // difficulties available
        public int additionDifficulty = 1;
        public int subtractionDifficulty = 1;
        public int multiplicationDiffculty = 1;
        public int divisionDifficulty = 1;
        public int combinedDifficulty = 1;


        
    }
    class Game
    {
        User player = new User();
        public int pType; //type of problems
        public int questions;
        public int cDifficulty; //chosen difficulty
        public int difficulty;
        int num01;
        int num02;

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
            /*while (questions < 10)
            {
                Console.Clear();
                Console.WriteLine("Please select at least 10 problems to solve");
                questions = Convert.ToInt32(Console.ReadLine());
            }*/
            return questions;
        }
        //Difficulty Method
        public int Difficulty()
        {
            switch (pType)
            {
                case 1:
                    difficulty = player.additionDifficulty;
                    break;
                case 2:
                    difficulty = player.subtractionDifficulty;
                    break;
                case 3:
                    difficulty = player.multiplicationDiffculty;
                    break;
                case 4:
                    difficulty = player.divisionDifficulty;
                    break;
                case 5:
                    difficulty = player.combinedDifficulty;
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
        // Set Difficulty
        public void set_difficulty(out int num01, out int num02)
        {
            Random numberGenerator = new Random();
            num01 = 0;
            num02 = 0;
            switch (cDifficulty)
            {
                case 1:
                    num01 = numberGenerator.Next(7, 13);
                    num02 = numberGenerator.Next(1, 7);
                    break;
                case 2:
                    num01 = numberGenerator.Next(51, 100);
                    num02 = numberGenerator.Next(1, 51);
                    break;
                case 3:
                    num01 = numberGenerator.Next(501, 1000);
                    num02 = numberGenerator.Next(1, 501);
                    break;

            }
        }

        //Addition Module
        public void addition()
        {

            Console.WriteLine("Alright! Time for some addition problems!\nYou've chosen " + questions + " problems.\nPress any key to start!");
            Console.ReadKey();
            Console.Clear();

            double currentQuestion = 1;
            double correctAnswers = 0;

            while (currentQuestion <= questions)
            {
                set_difficulty(out num01, out num02);
                int total = num01 + num02;
                Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                Console.WriteLine("What is " + num01 + " + " + num02 + "?");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == total)
                {
                    correctAnswers += 1;
                    Console.WriteLine("\nCorrect! You've gotten " + correctAnswers + " of " + currentQuestion + " correct so far.");
                    Console.WriteLine("\nPress any key for next question");
                    currentQuestion += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
                if (answer != total)
                {
                    Console.WriteLine("\nIncorrect. You've gotten " + correctAnswers + " of " + currentQuestion + " correct so far.");
                    Console.WriteLine("\nPress any key for the next question.");
                    currentQuestion += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            double score = (correctAnswers / questions) * 100;
            Console.WriteLine("You got " + score + "%");
            if (score >= 90 && player.additionDifficulty == 1 && cDifficulty == 1)
            {
                player.additionDifficulty += 1;
                Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.additionDifficulty == 2 && cDifficulty == 2)
            {
                player.additionDifficulty += 1;
                Console.WriteLine("Incredible! Time for something even more difficult!\n\nAdvanced difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.additionDifficulty == 3 && cDifficulty == 3)
            {
                Console.WriteLine("You are a master of addition! Try another type of math!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Addition Module
        public void subtraction()
        {

            Console.WriteLine("Alright! Time for some subtraction problems!\nYou've chosen " + questions + " problems.\nPress any key to start!");
            Console.ReadKey();
            Console.Clear();

            double currentQuestion = 1;
            double correctAnswers = 0;

            while (currentQuestion <= questions)
            {
                set_difficulty(out num01, out num02);
                int total = num01 - num02;
                Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                Console.WriteLine("What is " + num01 + " - " + num02 + "?");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == total)
                {
                    correctAnswers += 1;
                    Console.WriteLine("\nCorrect! You've gotten " + correctAnswers + " of " + currentQuestion + " correct so far.");
                    Console.WriteLine("\nPress any key for next question");
                    currentQuestion += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
                if (answer != total)
                {
                    Console.WriteLine("\nIncorrect. You've gotten " + correctAnswers + " of " + currentQuestion + " correct so far.");
                    Console.WriteLine("\nPress any key for the next question.");
                    currentQuestion += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            double score = (correctAnswers / questions) * 100;
            Console.WriteLine("You got " + score + "%");
            if (score >= 90 && player.additionDifficulty == 1 && cDifficulty == 1)
            {
                player.subtractionDifficulty += 1;
                Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.additionDifficulty == 2 && cDifficulty == 2)
            {
                player.subtractionDifficulty += 1;
                Console.WriteLine("Incredible! Time for something even more difficult!\n\nAdvanced difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.subtractionDifficulty == 3 && cDifficulty == 3)
            {
                Console.WriteLine("You are a master of subtraction! Try another type of math!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                User player = new User();
                int pType;
                int questions; // amuont of questions
                int choice = 1;
                //Introduction


                Game newGame = new Game();

                Console.WriteLine("Hello and welcome to Math Challenge!");
                
                Console.WriteLine("What is your name?");
                player.name = Console.ReadLine();
                Console.Clear();

               

                //Methods for running the game

                while (choice == 1)
                {
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1. Play Game\n2. Exit");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            return;
                    }
                    pType = newGame.problemType();
                    newGame.Difficulty();
                    questions = newGame.how_many_questions();

                    switch (pType)
                    {
                        case 1:
                            newGame.addition();
                            break;
                        case 2:
                            newGame.subtraction();
                            break;
                    }
                }

            }
        }
    }
}
