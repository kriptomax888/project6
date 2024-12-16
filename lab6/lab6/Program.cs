using System;

class Gold
{
    public delegate void MyEventHandler();
    public event MyEventHandler MyEvent;

    public void FulfillWish(string wish, int wishNumber)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Дідусь передав прохання {wish}");
        Console.ResetColor();
        if (wishNumber == 3)
        {
            MyEvent?.Invoke();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Бажання {wishNumber} не може бути виконано");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бажання на " + wish + " виконано");
            Console.ResetColor();
        }
    }
}

class Grandfather
{
    public void OnWishNotFulfilled()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дідусь переляканий. Прохання не виконано");
        Console.ResetColor();
    }

    public void PassWishToFish(Gold goldfish, string wish, int wishNumber)
    {
        goldfish.FulfillWish(wish, wishNumber);
    }
}

class Grandmother
{
    public void OnWishNotFulfilled()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Бабуся залишилася з розбитим коритом");
        Console.ResetColor();
    }

    public void ChangeStatus(string status)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Статус бабусі: {status}");
        Console.ResetColor();
    }
}

static class Desire
{
    public static int DesireNumber = 0;
    public static string[] Desires = new string[0];
    public static string[] DragonflyStatus = new string[0];
}

class Program
{
    static void Main(string[] args)
    {
        var gold = new Gold();
        var grandfather = new Grandfather();
        var grandmother = new Grandmother();

        gold.MyEvent += grandmother.OnWishNotFulfilled;
        gold.MyEvent += grandfather.OnWishNotFulfilled;

        grandmother.ChangeStatus("з розбитим коритом");


        grandfather.PassWishToFish(gold, "нове корито", 1);
        grandmother.ChangeStatus("з новим коритом");

        grandfather.PassWishToFish(gold, "нові маєтки", 2);
        grandmother.ChangeStatus("стовпова дворянка");

        grandfather.PassWishToFish(gold, "весь океан", 3);
    }
}
