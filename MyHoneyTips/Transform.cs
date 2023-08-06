using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    int Speed = 6;
    Vector3 vec = Vector3.zero;

    Rigidbody2D rigid;
    void Update()
    {
        //transform으로 움직였을 경우 충돌한다면 떨림현상이 발생한다
        transform.position += Speed * vec * Time.deltaTime;

        //이때 rigidbody를 이용해 움직이면 해결된다
        rigid.velocity = vec * Speed;
    }
}
