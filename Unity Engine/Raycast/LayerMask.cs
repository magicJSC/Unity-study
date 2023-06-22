using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2 : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");  //오브젝트의 tag를 얻는다
            //int mask = (1<<6) | (1<<7);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"{hit.collider.gameObject.tag}");
            }
        }
    }
}
