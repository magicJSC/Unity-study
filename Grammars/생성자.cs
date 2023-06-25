using Csharp;

namespace Csharp
{
    class Knight
    {
        public int hp;
        public int at;
        public Knight()   //void처럼 형식을 지정하지 않는다
        {
            hp = 100;
            at = 10;
            Console.WriteLine("");  //이런것도 실행할수있다
        }
        public Knight(int hp) : this()   //this()로 위에 생성자를 먼저 실행하게 만든다
        {
            this.hp = hp;
        }
    }
    class Program
    {
        static void Main(string[] args) 
        {
            //Knight knight = new Knight();  //생성자는 new Knight를 함과 동시에 값을 전달한다
            Knight knight = new Knight(50);   
        }
    }
}

