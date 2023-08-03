using System;
using System.Collections;

namespace Exercise
{
    class PriorityQueue<T> where T : IComparable<T>
    {

        List<T> _heap = new List<T>();
        //O(logN)
        public void Push(T data)
        {
            //힙의 맨끝에 새로운 데이터를 삽입한다
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                //도장깨기 시도
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                //두값을 교체 
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치를 이동한다
                now = next;
            }
        }
        //O(logN)
        public T Pop()
        {
            //반환할 데이터를 따로 저장
            T ret = _heap[0];

            //마지막 데이터를 루트로 이동한다
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            //역으로 내려가는 도장꺠기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                //왼쪽값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                //오른쪽값이 현재값보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                //왼쪽과 오른쪽 값이 현재값보다 작으면 종료
                if (next == now)
                    break;

                //두값을 교체 
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                //검사 위치를 이동한다
                now = next;
            }

            return ret;
        }
        public int Count()
        {
            return _heap.Count;
        }
    }
    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo(Knight other)
        {
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight { Id = 20 });
            q.Push(new Knight { Id = 10 });
            q.Push(new Knight { Id = 30 });
            q.Push(new Knight { Id = 90 });
            q.Push(new Knight { Id = 40 });

            while (q.Count() != 0)
            {
                Console.WriteLine(q.Pop().Id);
            }
        }
    }
}