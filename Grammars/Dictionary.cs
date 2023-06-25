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
            Dictionary<int,Monster> dic = new Dictionary<int,Monster>();
            
            //사용 방법
            dic.Add(1, new Monster(1));
            

            Monster mon;
            bool found = dic.TryGetValue(1,out mon);  //0에 값을 찾아소 mon에 값을 넣는다 성공하면 true
            dic.Remove(1);
            dic.Clear();
        }
    }
}

