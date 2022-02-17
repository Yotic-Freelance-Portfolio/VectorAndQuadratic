namespace VectorAndQuadratic
{
    public class Program
    {
        public static void Main()
        {
            VectorMain();
            QuadraticMain();
        }
        public class Vector
        {
            public Vector(params int[] nums) => this.nums = nums;
            public Vector(string str) : this(str.Split(',').Select(x => int.Parse(x)).ToArray()) { }
            private int[] nums;
            public int Length { get => nums.Length; }
            public int this[int index] { get => nums[index]; set => nums[index] = value; }
            public override string ToString() => string.Join(",", nums.Select(x => x.ToString()));
            public static int NegativeSum(params Vector[] vectors)
            {
                if (vectors.Length < 2)
                    throw new ArgumentException("Too few arguments");
                return vectors.Select(x => x.NegativeSum()).Sum();
            }
            public int NegativeSum() => nums.Where(x => x > 0).Sum();
            public int Sum() => nums.Sum();
            public int MultiplicationOnVec(int num) {
                nums.ToList().ForEach(x => num = num * x);
                return num;
            }
            public Vector MultiplicationOmNum(int num)
            {
                Vector output = new Vector(nums);
                for (int i = 0; i < output.Length; i += 1)
                    output[i] = output[i] * num;
                return output;
            }
            public Vector Unar() => new Vector(nums.Select(x => -x).ToArray());
        }
        public static void VectorMain()
        {
            Vector A = new Vector(Console.ReadLine()),
            B = new Vector(Console.ReadLine()),
            C = new Vector(Console.ReadLine());
            Console.WriteLine(Vector.NegativeSum(C, A.MultiplicationOmNum(5)));
            int sum = A.Sum();
            for (int i = 0; i < A.Length; i += 1)
                if (A[i] < 0)
                    A[i] = sum;
            Console.WriteLine(Vector.NegativeSum(A.Unar(), new Vector(A.MultiplicationOnVec(4)), B.MultiplicationOmNum(2)));
        }
        public class Quadratic 
        {
            private int a, b, c, x;
            public Quadratic() => a = b = c = 1;
            public Quadratic(int a, int b, int c)
            {
                if (a < 0)
                    throw new ArgumentException("A coefficient on that is less than zero has no roots.");
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public double[] Quation() => new double[2] {
                (-b + Math.Sqrt(Discriminant())) / 2 * a,
                (-b + Math.Sqrt(Discriminant())) / 2 * a,
            };
            public double Discriminant()
            {
                double discriminant = b ^ 2 + 4 * a * c;
                if (discriminant < 0)
                    throw new ArgumentException("Discriminant on that is less than zero has no roots.");
                return discriminant;
            }
            public bool DiscriminantIt() => (b ^ 2 + 4 * a * c) < 0;
            public static implicit operator double(Quadratic q) => q.Discriminant();
            public override string ToString() => (a == 1 ? "" : a.ToString()) + "x^2" + (b > 0 ? "+" : "") + (b == 1 ? "" : b.ToString()) + "x" + (c > 0 ? "+" : "") + (c == 1 ? "" : c.ToString());
        }
        public static void QuadraticMain()
        {
            Quadratic A = new Quadratic(),
            B = new Quadratic(23, 41, 4),
            C = new Quadratic(2, 3, 3);
            Console.WriteLine("уравнение".PadRight(25) + "|" + "дискриминант".PadRight(25) + "|" + "корни".PadRight(25));
            Console.WriteLine(A.ToString().PadRight(25) + "|" + A.Discriminant().ToString().PadRight(25) + "|" + string.Join(",", A.Quation().Select(x => x < 0 ? "Упссс!" : x.ToString())).PadRight(25));
            Console.WriteLine(B.ToString().PadRight(25) + "|" + B.Discriminant().ToString().PadRight(25) + "|" + string.Join(",", B.Quation().Select(x => x < 0 ? "Упссс!" : x.ToString())).PadRight(25));
            Console.WriteLine(C.ToString().PadRight(25) + "|" + C.Discriminant().ToString().PadRight(25) + "|" + string.Join(",", C.Quation().Select(x => x < 0 ? "Упссс!" : x.ToString())).PadRight(25));
        }
    }
}