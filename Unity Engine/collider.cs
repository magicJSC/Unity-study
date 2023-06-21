using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    /*발동 조건
    1. 나 또는 부딪힌 오브젝트에 Rigidbody가 있어야한다 (isKinematic : Off)
    2. 나에게 Collider가 있어야한다 (IsTrigger : Off)
    3. 부딪친 오브젝트에 Collider가 있어야한다 (IsTrigger : Off)
    */
    private void OnCollisionEnter(Collision collision)  //collision은 부딪친 오브젝트
    {
        Debug.Log($"collision{collision.gameObject.name}");
    }

    /*
    1. 둘다 collider가 있어야한다
    2. 둘 중 하나는 istrigger가 되야한다
    3. 둘 중 하나는 RigidBody가 있어야한다
    */
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log($"Trigger{other.gameObject.name}");
    }