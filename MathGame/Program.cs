const int minOption = 1;
const int maxOption = 5;

do
{
    ShowInitialMenu();
    
    var input = Console.ReadLine();
    var (isInputValid, option) = IsInputValid(input);
    
    if (!isInputValid)
    {
        Console.WriteLine("Bye bye!");
        break;
    }

    StartGame(option);
} while (true);

void ShowInitialMenu()
{
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("Select a operation to start or press any key to exit.");
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtration");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Show previous records");
}

(bool isValid, int option) IsInputValid(string? option)
{
    int.TryParse(option, out var optionNumber);
    return (option != null && optionNumber is <= maxOption and >= minOption, optionNumber);
}

int GenerateNumber()
{
    Random random = new Random();
    return (int)random.NextInt64(0, 100);
}

void StartGame(int option)
{   Console.Clear();
    int correctAnswers = 0;
    
    switch (option)
    {
        case 1:
            bool failed = false;
            do
            {
                if (Addition())
                {
                    correctAnswers++;
                    Console.WriteLine("That's correct! Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Incorrect. Your score was {correctAnswers} correct answers.\nPress any key to return to the menu");
                    Console.ReadKey();
                    failed = true;
                }
            } while (!failed);
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
    }
}

bool Addition()
{
    Console.Clear();
    (int a, int b) = (GenerateNumber(), GenerateNumber());
    int answer = a + b;

    var input = "";
    int guess;
    
    Console.WriteLine($"{a} + {b} = ?");
    
    do
    {
        Console.Write("Answer: ");
        input = Console.ReadLine();
    } while (!int.TryParse(input, out guess));

    return guess == answer;
}