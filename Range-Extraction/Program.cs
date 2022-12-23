using System;

var ints = new int[] { 97, 98, 99, 100, 101, 102, -7, -6, 14, 15, 16, 17,
    18, -46, -45, -44, -95, -74, 65, 66, 67, 68, 37, 38, 39, 40, 41, 42, 58, -31,
    -30, -29, -28, -27, -43, -42, -41, -40, -39, -38, -37, 52, 53, 54, 67, 68,
    69, 70, 71, 72, -48, -47, -46, -45, -44};
var text = EEExtract(ints);
Console.WriteLine(text);
string Extract(int[] args)
{
    string text = "";
    int counter = 0, number = args[0];
    for (int i = 0; i < args.Length; i++)
    {
        if (args[i] == number)
        {
            counter++;
            number++;
            if (args[i + 1] != number)
            {
                if (counter == 0)
                {
                    text += $"{args[i]},";
                    counter = 0;
                    number = args[i];
                }
                if (counter >= 2)
                {
                    text += $"{args[i - counter + 1]}-{args[i]},";
                    counter = 0;
                    number = args[i];
                }

            }
        }
        else if (counter == 0)
        {
            text += $"{args[i]},";
            counter = 0;
            number = args[i + 1];
        }
    }
    return text;  //TODO
}




string EEExtract(int[] args)
{
    bool check = false;
    string text = "";
    int counter = 0, number = args[0];
    for (int i = 0; i < args.Length - 1; i++)
    {
        number = args[i];
        for (int j = i; j < args.Length ; j++)
        {
            if (args[i] == args[j] && args[j+1]!=number+1)
            {
                if (text.Contains($"{args[j]}")==false)
                {
                    text += $"{args[j]},";
                    counter = 0;
                    number = args[j + 1];
                }
            }
            else if (args[j] == number)
            {
                counter++;
                number++;
                if (j == args.Length - 1)
                {
                    j -= 1;
                    check = true;
                }
                if (args[j + 1] != number)
                {
                    if (check)
                        j += 1;
                    if (counter == 0)
                    {
                        text += $"{args[j]},";
                        counter = 0;
                        break;
                    }
                    else if (counter > 2)
                    {
                        i = j;
                        text += $"{args[j - counter + 1]}-{args[j]},";
                        counter = 0;
                        break;
                    }
                    else if (counter == 2)
                    {
                        text += $"{args[j - 1]},{args[j]},";
                        i++;
                        counter = 0;
                        break;
                    }
                }
            }
        }
    }
     text =text.Remove(text.Length-1);
    return text;  //TODO
}





string EExtract(int[] args)
{
    string text = "";
    int counter = 1, number = args[0];
    for (int i = 0; i < args.Length - 1; i++)
    {
        if (args[i] + 1 == args[i + 1])
        {
            counter++;
            number++;
            if (args[i + 1] != number)
            {
                if (counter == 0)
                {
                    text += $"{args[i]},";
                    counter = 0;
                    number = args[i];
                }
                if (counter >= 2)
                {
                    text += $"{args[i - counter]}-{args[i]},";
                    counter = 0;
                    number = args[i];
                }

            }
        }
        else if (args[i] != number)
        {
            if (counter >= 2)
            {
                text += $"{args[i - counter]}-{args[i - 1]},";
                counter = 0;
                number = args[i];
            }
            else if (counter == 0)
            {
                text += $"{args[i]},";
                counter = 0;
                number = args[i + 1];
            }

        }

    }
    return text;  //TODO
}