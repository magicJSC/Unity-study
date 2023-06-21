using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);  //Raycast의 범위에 가장 앞에 있는 물체를 확인함
        RaycastHit hit;
        if (Physics.Raycast(transform.position, look, out hit, 10))
        {
            Debug.Log($"{hit.collider.gameObject.name}");
        }

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look * 10);   //Raycast의 범위에 모든 오브젝트를 확인함
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"{hit.collider.gameObject.name}");
        }
    }
}
