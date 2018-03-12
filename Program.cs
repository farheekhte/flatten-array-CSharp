using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            ///Using ArrayList for multiple type
            ArrayList IntArrayList = new ArrayList();

            ///Create an arraylist including int, decimal, string
            IntArrayList.Add(new int[] { 1, 2 });
            IntArrayList.Add(new int[,] { { 3, 4 }, { 5, 6 } });
            IntArrayList.Add(new int[,,] { { { 7 }, { 8 } }, { { 9 }, { 10 } } });
            IntArrayList.Add(new object[,,] { { { 11 }, { 12 } }, { { 13 }, { 13.5 }},{{"junk"},{14} } });
            IntArrayList.Add(new int[,,] { { { 15 }} });

            ///Show what we have
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(IntArrayList));

            ///Create an output arraylist
            ArrayList FlattenArrayList = new ArrayList();

            Array FlattenArray = Flatten(IntArrayList, FlattenArrayList);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(FlattenArray));
            Console.ReadLine();
        }

        /// <summary>
        /// Recursive method to flatten the array list of integer
        /// </summary>
        /// <param name="IntArrayList">List of object</param>
        /// <param name="FlattenArrayList">Flatten arrayList of int</param>
        /// <returns></returns>
        public static Array Flatten(IList IntArrayList, ArrayList FlattenArrayList)
        {
            foreach (var item in IntArrayList)
            {
                if (item is int)
                    FlattenArrayList.Add((int)item);
                else if (item is IList)
                    Flatten((IList)item, FlattenArrayList);
            }
            ///Creat and return an array of integer from the arraylist of that.
            return FlattenArrayList.ToArray(typeof(int));
        }
    }
}
