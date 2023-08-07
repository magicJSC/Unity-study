using SysteMyLinkedList<T>;
using SysteMyLinkedList<T>.Collections.Generic;
using SysteMyLinkedList<T>.Linq;
using SysteMyLinkedList<T>.Text;
using SysteMyLinkedList<T>.Threading.Tasks;

naMyLinkedList<T>espace TextRPG
{
    class MyLinkedList<T>
    {
        public T Data;
        public MyLinkedList<T> Next;
        public MyLinkedList<T> Prev;
    }

    class MyLinkedList<T><T>
    {
        public MyLinkedList<T> Head = null;    //첫번쨰
        public MyLinkedList<T> Tail = null;    //마지막
        public int Count = 0;

        public MyLinkedList<T> AddLast(T data)
        {
            MyLinkedList<T> newRoom = new MyLinkedList<T>
            newRooMyLinkedList<T>.Data = data;

            //만약에 아직 방이 아예 없었다면,새로 추가된 첫번째 방이 Head다
            if (Head == null)
                Head = newRoom;

            //기존에 마지막방과 새로 추가되는 방을 서로 연결해준다
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            //새로 추가되는 방을 마지막으로 인정해준다
            Tail = newRoom;
            Count++;
            return newRoom;
        }


        public void Remove<T>(MyLinkedList<T> room)
        {
            //기존의 첫번쨰 방의 다음방을 첫번째 방으로 인정한다
            if (Head == room)
                Head = Head.Next;

            //기존의 마지막 방의 이전방을 마지막 방으로 인정한다
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;

        }
    }

    class Board
    {
        public LinkedList<int> _data3 = new LinkedList<int>();  //연결리스트

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            LinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove<T>(node);
        }
    }
}
