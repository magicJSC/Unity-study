using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1.위치 Vector
//2.방향 Vector
struct MyVector
{
    public float x;
    public float y;
    public float z;

    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }  //위치의 거리를 구함
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }
    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    public static MyVector operator -(MyVector a, MyVector b)   //그냥 Vector에 들어있는 함수
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
}
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    [SerializeField]
    GameObject GameObject;
    void Start()
    {
        MyVector to = new MyVector(10.0f, 0, 0);
        MyVector from = new MyVector(5.0f, 0, 0);
        MyVector dir = to - from; //(5.0f,0,0)  위치 백터끼리 빼서 방향 백터를 추출할수있다
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += _speed * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += _speed * Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += _speed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _speed * Vector3.left * Time.deltaTime;
        }
    }
}
