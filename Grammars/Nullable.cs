using System;

namespace CSarp
{
    class Program
    {
        class Monster()
        {
            public int id(get;set;);
        }
        static void Main()
        {
            int? number = null;
            number = 3;
            int a = number.Value;  //그냥 number만 넣으면 오류

            int b = number ?? 0;   //값이 null이 아니라면 number겂을 b에 넣어주고 아니면 0을 넣는다

            Monster monster = null;
            if(monster != null)
            {
                int _monster.id = monster.id; 
            }
            int? id = monster?.id;

            if(monster == null)
            {
                id = null;
            }
            else
            {
                id = monster.id;
            }
        }
    }
     
}