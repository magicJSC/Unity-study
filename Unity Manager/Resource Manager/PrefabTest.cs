using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject tank;
    private void Start()
    {
        tank = Managers.Resource.Instantiate("Tank");
        Managers.Resource.Destroy(tank);
    }
}
