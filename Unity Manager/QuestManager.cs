using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager
{

    Dictionary<int,QuestData> questlist = new Dictionary<int, QuestData>();
    Dictionary<int,Define.Quest> questtype= new Dictionary<int, Define.Quest>();
    class QuestData
    {
        public GameObject mo;
        public int count;
        public QuestData(GameObject mo, int count = 0)
        {
            this.mo = mo;
            this.count = count;
        }
    }
    int topindex = 0;
   public void AddPick(GameObject go,int count)
    {
        questlist.Add(topindex, new QuestData(go,count));
        questtype.Add(topindex, Define.Quest.Pick);
        topindex++;
    }

    public void AddReach(GameObject go)
    {
        questlist.Add(topindex, new QuestData(go));
        questtype.Add(topindex, Define.Quest.Reach);
        topindex++;
    }
    public void Check(GameObject go,int ObtainObj)
    {
        for(int i =0;i<questlist.Count;i++)
        {
            QuestData questData = questlist[i];
            Define.Quest type = questtype[i];
            switch(type)
            {
                case Define.Quest.Pick:
                    if(questData.count == ObtainObj)
                        questlist.Remove(i);
                    break;
                case Define.Quest.Reach:
                    if(questData.mo == go)
                        questlist.Remove(i);
                    break;

            }
        }
    }
}
