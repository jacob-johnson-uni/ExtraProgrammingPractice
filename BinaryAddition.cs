using System.Text;

namespace BinaryAddition
{
    class program
    {
        static (int Sum, int Carry) HalfAdder(int a, int b)
        {
            return (a ^ b, a & b); //does half adder with XOR on the ^ and AND on the &
        }

        static (int Sum, int Carry) FullAdder(int a, int b, int carryInt)
        {
            var (s1, c1) = HalfAdder(a, b); //completes the half adder
            var (s2, c2) = HalfAdder(s1, carryInt); //completes the half adder with the carry bit.
            return (s2, c1 | c2);
        }

        static string AddBinary(string x, string y)
        {
            int len = Math.Max(x.Length, y.Length); //selects the largest number out of the given values.
            x = x.PadLeft(len, '0'); //ensures the program works from right to left
            y = y.PadLeft(len, '0');

            var result = new StringBuilder();
            int carry = 0;

            for (int i = len - 1; i >= 0; i--) //continues until the length =0 or in other terms the end of the string 
            {
                var (sum, c) = FullAdder(x[i] - '0', y[i] - '0', carry); //calls full adder to a multi digit/character string
                result.Insert(0, sum); //inserts a new string at the specific index
                carry = c; 
            }

            if (carry == 1) result.Insert(0, '1'); //inserts the carry to a specific index
            return result.ToString(); //returns the result as a string
        }

        static void Main()
        {
            //Console.WriteLine("Half adder:");
            //for (int a = 0; a <= 1; a++)
            //    for (int b = 0; b <= 1; b++)
            //    {
            //        var (sum, carry) = HalfAdder(a, b);
            //        Console.WriteLine($"{a} + {b} = Sum {sum}, Carry {carry}");
            //    }

            //Console.WriteLine();
            //Console.WriteLine("Full adder:");
            //for (int a = 0; a <= 1; a++)
            //    for (int b = 0; b <= 1; b++)
            //        for (int cin = 0; cin <= 1; cin++)
            //        {
            //            var (sum, cout) = FullAdder(a, b, cin);
            //            Console.WriteLine($"{a} + {b} + {cin} = Sum {sum}, Carry {cout}");
            //        }

            Console.WriteLine();
            Console.Write("Enter a 4 bit binary number: ");
            string binary1 = Console.ReadLine(); //gets the binary num as a string

            Console.Write("Enter another 4 bit binary number: ");
            string binary2 = Console.ReadLine(); //gets the binary num as a string

            Console.WriteLine();
            Console.WriteLine("Binary addition:");
            Console.WriteLine($"{binary1} + {binary2} = {AddBinary(binary1, binary2)}"); //AddBinary is called using the strings entered.
            Console.ReadLine();
        }

       
    }
}