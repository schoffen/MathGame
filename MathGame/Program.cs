const int minOption = 1;
const int maxOption = 5;

// TODO store previous games

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
    Console.WriteLine("2 - Subtraction");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Show previous records");
    Console.Write("Option: ");
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

void DisplayCorrectAnswer()
{
    Console.WriteLine("That's correct! Press any key to continue");
    Console.ReadKey();
}

void DisplayIncorrectAnswer(int streak)
{
    Console.WriteLine($"Incorrect. Your score was {streak} correct answers.\nPress any key to return to the menu");
    Console.ReadKey();
}

void StartGame(int option)
{   
    Console.Clear();
    int streak = 0;
    
    bool failed = false;
    do
    {
        if (Question(option))
        {
            streak++;
            DisplayCorrectAnswer();
        }
        else
        {
            DisplayIncorrectAnswer(streak);
            failed = true;
        }
    } while (!failed);
    
    Console.Clear();
}

bool Question(int operation)
{
    Console.Clear();
    (int a, int b) = (GenerateNumber(), GenerateNumber());
    int answer = 0;

    switch (operation)
    {
        case 1:
            answer = a + b;
            Console.WriteLine($"{a} + {b} = ?");
            break;
        case 2:
            answer = a - b;
            Console.WriteLine($"{a} - {b} = ?");
            break;
        case 3:
            answer = a * b;
            Console.WriteLine($"{a} * {b} = ?");
            break;
        case 4:
            while (b == 0 || a % b != 0)
            {
                a = GenerateNumber();
                b = GenerateNumber();
            }

            answer = a / b;
            Console.WriteLine($"{a} / {b} = ?");
            break;
        case 5:
            
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
    }
    
    var input = "";
    int guess;
    
    do
    {
        Console.Write("Answer: ");
        input = Console.ReadLine();
    } while (!int.TryParse(input, out guess));

    return guess == answer;
}