using System;

var ints = new int[] { -112, -110, -109, -107, -105, -104, -102, -101, -99 };
var text = Extract(ints);
Console.WriteLine(text);
string Extract(int[] args)
{

    string[] split = new string[] { };
    bool check = false;
    string text = "";
    int counter = 0, number = args[0];
    for (int i = 0; i < args.Length - 1; i++)
    {
        number = args[i];
        if (i == args.Length - 2)
        {
            number = args[i + 1];
        }
        for (int j = i; j < args.Length; j++)
        {
            if (args[i] == args[j] && (args[j + 1] != number + 1 || i == args.Length - 1))
            {
                for (int k = 0; k < split.Length; k++)
                {
                    if (split[k] == $"{args[j]}")
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    text += $"{args[j]},";
                    counter = 0;
                    number = args[j + 1];
                }
                check = false;
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
                    if (counter == 1 && j == args.Length - 1)
                    {
                        text += $"{args[j]},";
                        counter = 0;
                        break;
                    }
                    else if (counter > 2)
                    {
                        i = j;
                        if (i == args.Length - 2) { i--; }
                        text += $"{args[j - counter + 1]}- {args[j]},";
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
        split = text.Split(',', ' ');
    }
    if (split[split.Length - 2] != $"{args[args.Length - 1]}")
    {
        text += args[args.Length - 1];
    }
    if (text[text.Length-1]==',')
    text = text.Remove(text.Length - 1);
    text = text.Replace(" ", "");
    return text;  //TODO
}