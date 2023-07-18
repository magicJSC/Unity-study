using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditorInternal;
using TMPro;
using UnityEngine.EventSystems;

public class Menu : UI_Base
{


    enum Texts
    {
        Continue,
        Option,
        Mainmenu,
        Leave
    }
    enum Images
    {
        Image
    }

    private void Start()
    {
        Choice<TextMeshProUGUI>(typeof(Texts));                     //UI_Base에게 enum Texts를 준다
        Choice<Image>(typeof(Images));
        GameObject go = GetImage((int)Images.Image).gameObject;
        UI_Event evt = go.GetComponent<UI_Event>();
        AddUIEvent(go,(PointerEventData data) => { go.transform.position = data.position; },Define.UIEvent.Click);
        GetText((int)Texts.Continue).color = Color.red;
    }
    
}
