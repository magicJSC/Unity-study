using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    GameObject tank;
    void Start()
    {
        tank = Manager.Resource.Instantiate("Tank");
        prefab = Resources.Load<GameObject>("Prefab/Tank");  //[SerializeField]를 쓰지 않을 떄 사용 => resouses폴더에서 Prefab에 있는 Tank를 오브젝트로 설정
        tank = Instantiate(prefab); //Gameobject인 prefab을 생성
        Destroy(tank, 3.0f);  //3초뒤에 삭제
    }



}
