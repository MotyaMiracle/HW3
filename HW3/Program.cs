using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Список строковых значений: ");
            try
            {
                MyList<string> list1 = new MyList<string>();

                for (int i = 0; i < 20; i++)
                {
                    list1.Add(random.Next(-10, 10).ToString());
                }

                for (int i = 0; i < list1.Length; i++)
                {
                    Console.Write(list1[i] + " ");
                }

                Console.WriteLine();
                int a = random.Next(0, 25);
                Console.WriteLine($"Нужно удалить число по этому индексу-> {a}");
                list1.RemoveAt(a);

                for (int i = 0; i < list1.Length; i++)
                {
                    Console.Write(list1[i] + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Список целочисленных значений значений: ");
            try
            {
                MyList<int> list2 = new MyList<int>();
                for (int i = 0; i < 20; i++)
                {
                    list2.Add(random.Next(-10, 10));
                }
                for (int i = 0; i < list2.Length; i++)
                {
                    Console.Write(list2[i] + " ");
                }
                Console.WriteLine();
                int b = random.Next(0, 25);
                Console.WriteLine($"Нужно удалить число по этому индексу -> {b}");
                list2.RemoveAt(b);
                for (int i = 0; i < list2.Length; i++)
                {
                    Console.Write(list2[i] + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Класс, реализующий однонаправленный одномерный список
    /// </summary>
    class MyList<MyType>
    {
        /// <summary>
        /// Реализация Элемента списка
        /// </summary>
        class MyListItem
        {
            public MyType Value;
            public MyListItem Next;
        }
        MyListItem head = null; // Первый элемент списка
        private int length = 0; // Первоначальная длина списка
        public int Length
        {
            get
            {
                return length;
            }
        }
        public void Add(MyType value)
        {
            length++;
            if (head == null)
            {
                head = new MyListItem() { Value = value };
                return;
            }
            MyListItem current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new MyListItem() { Value = value };
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 & index < length & head != null)
            {
                length--;
                if (index == 0)
                {
                    head = head.Next;
                }        
                else
                {
                    MyListItem current1 = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current1 = current1.Next;
                    }
                    MyListItem current2 = current1.Next;
                    current2 = current2.Next;
                    current1.Next = current2;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс удаляемого элемента за пределами списка");
            }
        }
        public MyType this[int index]
        {
            get
            {
                MyListItem current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return (current.Value);
            }
            set
            {
                MyListItem current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }
    }
}
