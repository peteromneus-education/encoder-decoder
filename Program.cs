using encoder_decoder.Classes;

bool keepDisplayingMenu = true; // initialiserar en bool-variabel som ska amvändas för att loopa menyvalet nedan tills ett giltigt val gjorts
char menuChoice = '\0'; // måste initialisera menuChoice utanför while-loopen pga. att compilern kräver att variabeln har ett värde när det lämnar loopen


while (keepDisplayingMenu) // loopar tills ett giltigt val har gjorts (alltså tills keepDisplayingMenu är false)
{
    Console.WriteLine(
        "== Encoder/Decoder ==\n\n" +

        "Enter a number to choose an option below\n" +
        "1. Encode a message\n" +
        "2. Decode a message\n" +
        "3. Exit program");

    menuChoice = Console.ReadKey(true).KeyChar; // den här Console-metoden registrerar enkla tangentbordstryck utan att man behöver trycka Enter fteråt

    if (menuChoice is '1' or '2' or '3')
    {
        Console.Clear(); // Clear rensar all text från terminal-fönstret
        keepDisplayingMenu = false;
    }
    else
    {
        Console.Clear();
        InputHelper.ErrorMessage("Please press a number from 1 to 3.\n"); // kallar in en metod från InputHelper-klassen som visar ett felmeddelande i rött
    }
}

switch (menuChoice) // använder char-variabeln menuChoice för att aktivera rätt metod baserat på menyval 1, 2 eller 3
{
    case '1':
        while (true)
        {
            string encoderInput = InputHelper.InputValidation("What's your message? "); // kallar in metoden InputValidation för att hantera eventuell felaktig input
            string encoded = MessageEncoder.Encode(encoderInput); // metoden Encode hanterar själva chiffreringen

            Console.WriteLine($"Here's your encoded message: {MessageReverser.Reverse(encoded)}\n");
            break;
        }
        break;

    case '2':
        while (true) // case 2 fungerar likadant som case 1, men använder Decode för att dechiffrera istället
        {
            string decoderInput = InputHelper.InputValidation("What's your message? ");
            string decoded = MessageDecoder.Decode(decoderInput);

            Console.WriteLine($"Here's your decoded message: {MessageReverser.Reverse(decoded)}");
            break;
        }
        break;

    case '3': // case 3 avslutar programmet
        Console.Clear();
        Console.WriteLine("Exiting program...");
        Console.ReadKey();
        return;
}
