namespace CSharp
{
    class Program
    {
        static  void AddOne(ref int number) 
        {
            number++;
        }
        static void Divide(int a,int b, out int result1,out int result2)
        {
            result1 = a + b;
            result2 = a - b;
        }
        static void Main(string[] args)
        {
            int a = 0;
            AddOne(ref a);  //ref를 사용해서 ref값만 주는게 아닌 ref자체를 줌
           

            int result1;
            int result2;
            Divide(10,3,out result1,out result2);   //out을 써서 result1과 result2를 넘긴다
        }
    }
}