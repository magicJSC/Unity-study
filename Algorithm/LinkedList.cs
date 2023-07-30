using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class MyLinkedListNode<T>
    {
        public T Data;            //데이터가 들어감
        //주소값 저장  
        public MyLinkedListNode<T> Next;    //다음 주소      
        public MyLinkedListNode<T> Prev;    //이전 주소
    }
    //O(1)
    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;    //첫번쨰
        public MyLinkedListNode<T> Tail = null;    //마지막
        public int Count =0;
        public MyLinkedListNode<T> AddLast(T data)  //data는 추가할것
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;
            //만약 방이 없다면 ,새로 추가한 방이 Head다
            if(Head ==  null)
            {
                Head = newRoom;
            }

            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }
            Tail = newRoom;
            Count++;
            return newRoom;
        }
        //O(1)
        public void Remove(MyLinkedListNode<T> room)    //room은 삭제할 것
        {
            //기존의 첫번째 방의 다음방을 첫번째 방으로 인정한다
            if(Head == room)
            {
                Head = Head.Next;
            }
            //기존의 마지막방의 이전방을 마지막 방으로 인정한다
            if(Tail == room)
            {
                Tail = Tail.Prev;
            }
            if(room.Prev != null)
            {
                room.Prev.Next = room.Next;
            }
            if(room.Next != null)
            {
                room.Next.Prev = room.Prev; 
            }
            Count--;
        }
    }
    
    class Board
    {
        public int[] _data = new int[25];                       //배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();   //연결리스트
        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
             MyLinkedListNode<int> node =  _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
