﻿


Класс а = new Класс();

а.Id = new Класс();


Console.WriteLine("Hello, World!");





class Класс
{
    public dynamic Id { get; set; }

    public void Metoд(int[] a)
    {
        if (a.Length > 0)
        {
            if (a[0] == 1)
            {
                Console.WriteLine("Элемент равен 1 в массиве");
            }
            else if (a[0] == 2)
            {
                Console.WriteLine("Элемент равен 2 в массиве");
            }
            else
            {
                Console.WriteLine("Ни чего не знаю");
            }
        }
    }
}
