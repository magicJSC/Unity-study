using System;
using System.Reflection;   //reflextion을 사용하기위해 사용
namespace CSarp
{
    class Monster
    {
        public int hp;
        protected  int attack;
        private int speed;
        
        void Attack();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            Type type = monster.GetType();  //class에 모든 정보를 빼온다

            var field = type.GetFields(System.Reflection.BindingFlags.Public
                | GetFields(System.Reflection.BindingFlags.NonPublic
                | GetFields(System.Reflection.BindingFlags.Static
                | GetFields(System.Reflection.BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic) 
                { 
                    access = "public";

                }
                else if (field.IsPrivate)
                {
                    access = "private";
                }
                //acceess는 protexted,public,private
                //field.FieldType.Name은 int,float
                //field.Name은 hp,attack,speed
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");  
            }
        }
    }
}
