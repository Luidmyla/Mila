using System;
using System.Linq;
using System.Text;
namespace lab_3
{
    class Plural
    {
        private double[] array = new double[6];
        public void Add(double j)
        {
            Array.Resize(ref array, array.Length + 1);//зміна розміру масиву,щоб добавити ше 1 елемент
            array[array.Length - 1] = j;// присвоєння значення ост елементу
        }
        public void Remove(double j)//видалення елемента
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)//перезапис масиву
            {
                if (array[i] != j)
                {
                    array[index] = array[i];
                    index++;
                }
            }
            if (index != array.Length) Array.Resize(ref array, array.Length - 1);//видалення ост елемента
        }
        public void union(Plural b)
        {
            Array.Resize(ref array, array.Length + b.array.Length);
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i > array.Length - b.array.Length - 1)
                {
                    array[i] = b.array[k];
                    k++;
                }
            }
        }
        public void district(Plural b)//перетин
        {
            int q = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < b.array.Length; j++)
                {
                    if (array[i] == b.array[j])
                        array[i] = b.array[j];
                    else
                    {
                        k++;
                        if (k == b.array.Length) q++;
                    }
                }
            }
            Array.Resize(ref array, array.Length - q + 1);//зміна розміру масиву
        }
        public void minus(Plural b)
        {
            int q = 0, w = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < b.array.Length; j++)
                {
                    if (array[i] != b.array[j])
                    {
                        k++;
                        if (k == b.array.Length)
                        {
                            array[q] = array[i];
                            q++; w++;
                        }
                    }
                }
            }
            Array.Resize(ref array, array.Length - w);
        }
        public void cout()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public Plural(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.array[i] = arr[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double RemovingItem, elem;
            double[] key = { 1, 2, 3, 4, 5, 6 };
            double[] key2 = { 3, 4, 5, 6, 7, 8 };
            Plural P = new Plural(key);
            Plural P2 = new Plural(key2);
            try
            {
                elem = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input data, enter data again correctly");
                elem = Convert.ToDouble(Console.ReadLine());
            }
            P.Add(elem);
            P.cout();
            try
            {
                RemovingItem = Convert.ToDouble(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("invalid input data, enter data again correctly");
                RemovingItem = Convert.ToDouble(Console.ReadLine());
            }
            P.Remove(RemovingItem);
            P.cout();
            P.district(P2);
            P.cout();
            P.minus(P2);
            P.cout();
            P.union(P2);
            P.cout();
            Console.ReadKey();
        }
    }
}