using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Questor.Choise
{
    public class RandomChoiser
    {
        private Random Randomizer = new Random();

        private ObservableCollection<int> _exceptions = new ObservableCollection<int>();

        /// <summary>
        /// Этот метод берет две выборки:одна из них основная, а другая
        /// служит для хранения уже выбранных занчений для того чтобы с ней
        /// сверятся и не допускать повторных значений
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="exceptions"></param>
        /// <returns>Целое число</returns>
        public int NoRepeatlyChoise(ObservableCollection<int> sample,in ObservableCollection<int> exceptions)
        {
            int current = 0;//Текущее число

            if (sample.Count == 1)//Если количество элементов списке == 1 ,то мы берем единственный занятый индекс, он и так бы 100% выпал бы. 
            {
                current = sample[0];

                sample.Clear();//Зачистка всех выборок чтобы область определения значения не была перемешана

                exceptions.Clear();

                return current;
            }
            else
            {
                try
                {
                    current = sample[Randomizer.Next(0, sample.Count - 1)];

                    while (exceptions.Contains(current))//Мучаем генератор пока он не даст нам неповторимое значение для текущей выборки
                    {
                        current = sample[Randomizer.Next(0, sample.Count - 1)];
                    }

                    exceptions.Add(current);//Добавляем в исключения => недупускаемость повторных значений

                    sample.Remove(current);

                    return current;

                }
                catch
                {
                    exceptions.Clear();

                    sample.Clear();

                    return current;
                }




            }
        }

        /// <summary>
        /// Принимает по ссылке выборку 
        /// и выбирает из нее случайный элемент
        /// </summary>
        /// <param name="Выборка"></param>
        /// <returns>Случайное число</returns>
        public int RepeatlyChoise(ObservableCollection<int> sample)
        {
            int current = 0;

            if (sample.Count == 1)
            {
                current = sample[0];

                sample.Clear();

                return current;
            }
            else
            {
                try
                {
                    current = sample[Randomizer.Next(0, sample.Count - 1)];

                    return current;

                }
                catch
                {

                    sample.Clear();

                    return current;
                }




            }
        }













    }

}

