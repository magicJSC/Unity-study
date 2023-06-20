using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {

    }

    float _yAngle = 0.0f;
    void Update()
    {
        //_yAngle += Time.deltaTime * 100.0f;
        //transform.eulerAngles = new Vector3(0,_yAngle,0);
        //transform.Rotate(new Vector3(0,Time.deltaTime *100.0f,0));
        //transform.rotation = Quaternion.Euler(new Vector3(0, _yAngle, 0));

        if (Input.GetKey(KeyCode.W))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 1.0f);   //Quaternion.Rotation으로 방향을 전환하고 속도설정 1.0f은최대
            transform.position += _speed * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 1.0f);
            transform.position += _speed * Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 1.0f);
            transform.position += _speed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 1.0f);
            transform.position += _speed * Vector3.left * Time.deltaTime;
        }
    }
}
