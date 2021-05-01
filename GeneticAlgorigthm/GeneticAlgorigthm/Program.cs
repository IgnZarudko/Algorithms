﻿using System;

namespace GeneticAlgorigthm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

//Уравнение 1: -13 + ((w^2) * x * y) + (x * (y^2)) + z + ((u^2) * (w^2) * x * y * z) + (w * x * y * (z^2))

//Уравнение 2: 50 + x + y + (u * w * x * y) + ((u^2) * w * x * y) + (u * x * y * (z^2))

//Начальная популяция: Случайная в (-200,200)

//Селекция: Случайная

//Скрещивание: "Одноточечная (в третьем гене) + многоточечная (во втором и четвертом гене)"

//Мутация: "Каждый бит некоторых наименее 
// пригодных потомков 
// мутирует с некоторой 
//     вероятностью p"

//Замещение: "Произвести больше потомков, и оставить 
// популяцию такого же размера, как старая, 
// но состоящую исключительно из более 
// пригодных потомков"