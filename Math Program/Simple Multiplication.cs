using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography;
using System.Xml.Schema;
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
                    num01 = numberGenerator.Next(1, 133);
                    num02 = numberGenerator.Next(1, 13);
                    break;
                case 2:
                    num01 = numberGenerator.Next(1, 100);
                    num02 = numberGenerator.Next(1, 100);
                    break;
                case 3:
                    num01 = numberGenerator.Next(1, 1000);
                    num02 = numberGenerator.Next(1, 1000);
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
            else if (score >= 90)
            {
                Console.WriteLine("You've got this down! Try a harder difficulty.\nPress any key to return to the main menu");
            }
            else
            {
                Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Subtracion Module
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
            if (score >= 90 && player.subtractionDifficulty == 1 && cDifficulty == 1)
            {
                player.subtractionDifficulty += 1;
                Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.subtractionDifficulty == 2 && cDifficulty == 2)
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
            else if (score >= 90)
            {
                Console.WriteLine("You've got this down! Try a harder difficulty.\nPress any key to return to the main menu");
            }
            else
            {
                Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
                }
                // Multiplication
                public void multiplication()
                {

                    Console.WriteLine("Alright! Time for some multiplications problems!\nYou've chosen " + questions + " problems.\nPress any key to start!");
                    Console.ReadKey();
                    Console.Clear();

                    double currentQuestion = 1;
                    double correctAnswers = 0;

                    while (currentQuestion <= questions)
                    {
                        set_difficulty(out num01, out num02);
                        int total = num01 * num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " x " + num02 + "?");
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
                    if (score >= 90 && player.multiplicationDiffculty == 1 && cDifficulty == 1)
                    {
                        player.multiplicationDiffculty += 1;
                        Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90 && player.multiplicationDiffculty == 2 && cDifficulty == 2)
                    {
                        player.multiplicationDiffculty += 1;
                        Console.WriteLine("Incredible! Time for something even more difficult!\n\nAdvanced difficulty unlocked!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90 && player.multiplicationDiffculty == 3 && cDifficulty == 3)
                    {
                        Console.WriteLine("You are a master of multiplication! Try another type of math!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90)
                    {
                        Console.WriteLine("You've got this down! Try a harder difficulty.\nPress any key to return to the main menu");
                    }
                    else
                    {
                        Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                // Division
                public void divison()
                {

                    Console.WriteLine("Alright! Time for some division problems!\nYou've chosen " + questions + " problems.\nPress any key to start!");
                    Console.ReadKey();
                    Console.Clear();

                    double currentQuestion = 1;
                    double correctAnswers = 0;

                    while (currentQuestion <= questions)
                    {
                        set_difficulty(out num01, out num02);
                            while ( num01 % num02!= 0 || num02 == 1 || num01 < num02 | num01 / num02 == 2)
                                {
                                set_difficulty(out num01, out num02);
                                }
                        double total = num01 / num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " / " + num02 + "?");
                        double answer = Convert.ToDouble(Console.ReadLine());
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
                    if (score >= 90 && player.divisionDifficulty == 1 && cDifficulty == 1)
                    {
                        player.divisionDifficulty += 1;
                        Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90 && player.divisionDifficulty == 2 && cDifficulty == 2)
                    {
                        player.divisionDifficulty += 1;
                        Console.WriteLine("Incredible! Time for something even more difficult!\n\nAdvanced difficulty unlocked!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90 && player.divisionDifficulty == 3 && cDifficulty == 3)
                    {
                        Console.WriteLine("You are a master of division! Try another type of math!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (score >= 90)
                    {
                        Console.WriteLine("You've got this down! Try a harder difficulty.\nPress any key to return to the main menu");
                    }
                    else
                    {
                        Console.WriteLine("Keep trying! Go for 90%!\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
        // Combined
        public void combined()
        {

            Console.WriteLine("Alright! Time for a combination of problems!\nYou've chosen " + questions + " problems.\nPress any key to start!");
            Console.ReadKey();
            Console.Clear();

            double currentQuestion = 1;
            double correctAnswers = 0;

            while (currentQuestion <= questions)
            {
                Random combine = new Random();
                double cType = combine.Next(1, 5);
                set_difficulty(out num01, out num02);
                switch (cType)
                {
                    case 1:
                        double aTotal = num01 + num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " + " + num02 + "?");
                        cType = aTotal;
                        break;

                    case 2:
                        double sTotal = num01 - num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " - " + num02 + "?");
                        cType = sTotal;
                        break;

                    case 3:
                        double mTotal = num01 * num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " x " + num02 + "?");
                        cType = mTotal;
                        break;

                    case 4:
                        while (num01 % num02 != 0 || num02 == 1 || num01 < num02 | num01 / num02 == 2)
                        {
                            set_difficulty(out num01, out num02);
                        }
                        double dTotal = num01 / num02;
                        Console.WriteLine("Question " + currentQuestion + " of " + questions + ":\n");
                        Console.WriteLine("What is " + num01 + " / " + num02 + "?");
                        cType = dTotal;
                        break;
                }
                double answer = Convert.ToDouble(Console.ReadLine());
                if (answer == cType)
                {
                    correctAnswers += 1;
                    Console.WriteLine("\nCorrect! You've gotten " + correctAnswers + " of " + currentQuestion + " correct so far.");
                    Console.WriteLine("\nPress any key for next question");
                    currentQuestion += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
                if (answer != cType)
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
            if (score >= 90 && player.combinedDifficulty == 1 && cDifficulty == 1)
            {
                player.combinedDifficulty += 1;
                Console.WriteLine("You're amazing! This is obviously too easy.\n\nIntermediate difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.combinedDifficulty == 2 && cDifficulty == 2)
            {
                player.combinedDifficulty += 1;
                Console.WriteLine("Incredible! Time for something even more difficult!\n\nAdvanced difficulty unlocked!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90 && player.combinedDifficulty == 3 && cDifficulty == 3)
            {
                Console.WriteLine("You are a master of all math!\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (score >= 90)
            {
                Console.WriteLine("You've got this down! Try a harder difficulty.\nPress any key to return to the main menu");
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
                        case 3:
                            newGame.multiplication();
                            break;
                        case 4:
                            newGame.divison();
                            break;
                        case 5:
                            newGame.combined();
                            break;
                    }
                }

            }
        }
    }
}
