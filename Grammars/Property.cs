using System;

namespace CShep
{
    class Program
    {
        class Knight
        {
            protected hp;
            public int HP;
            {
                get { return hp; } set {  this.hp = value; }
            }
        }
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            
            knight.HP = 10;  //값을 넣어줄떄
            int hp = knight.HP;   //닶을 가져올떄
        }
    }
}
