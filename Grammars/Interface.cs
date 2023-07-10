using System;

namespace CSharp
{
   class Program
    {
        abstract class Monster      //Monster를 상속 받으면 Shout가 무조건 있어야함
        {
            public abstract void Shout() //abstract가 붙으면 추상적이게 됨 그래서 뒤에 내용이 있으면 안됨 예 : { int i =4;}
        }

        interface IFlyable
        {
            void Fly();     //내용은 없이 쓴다
        }
        class Orc : Monster 
        {
            public override void Shout()
            {
                Console.WriteLine("우가");
            }
        }

        class FlyableOrc : Orc, IFlyable   //상속 할 때 다중으로 하면 함수가 있으면 어떤 내용을 실행할지 몰라서
        {
            public void Fly()  //상속한 interface애 있는 함수를 써야한다
            {

            }
        }

        static void DoFly(IFlyable flyable)
        {
            flyable.Fly();
        }
        static void Main(string[] args)
        {
            IFlyable flyable = new FlyableOrc();
            DoFly(flyable);
        }
    }
}
