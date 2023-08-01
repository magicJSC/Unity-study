using System;

namespace Exercise
{


    //스택 : LIFO(후입선출 Last in First out)
    // 큐 : FIFO(선입선출 First in First out)
 
    // [1] [2] [3] ->
    //스텍은 [1]이 가장 늦게 와서 [1]이 먼저 나간다
    //큐는 [3]이 가장 빨리 와서 [3]이 먼저 나간다
    class Study
    {


        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);  
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);


            int data = stack.Pop();         //스택이여서 4를 선출해준다
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            int data2 = queue.Dequeue();    //큐여서 1을 선출해준다

        }
    }
}