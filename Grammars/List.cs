using System;
using System.Collections.Generic;  

namespace grammars
{
    class Program
    {
        class Monster
        {
            public int id;
            public Monster(int id) { this.id = id; }
        }
        static void Main(string[] args)
        {
            //int를 key라하고 Monster를 value라 부르는데 key가 있으면 value를 쉽게 찾을수있다
            List<int> list = new List<int>();
            
            //사용 방법
            list.Add(1);  //리스트에 1을 넣는다



            bool found = list.Remove(1); //지운다면 true

        }
    }
}

