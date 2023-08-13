using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extention
{
    public static void BindEvent(this GameObject go,Action<PointerEventData> action,Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go,action,type);
    }
}
