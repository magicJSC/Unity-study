﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefab/{path}");
        return GameObject.Instantiate(prefab, parent);
    }
    public void Destroy(GameObject go)
    {
        if (go = null)
            return;

        Object.Destroy(go);
    }

}
