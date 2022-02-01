using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] npcID;

    public QuestData(string questName, int[] npcID)
    {
        this.questName = questName;
        this.npcID = npcID;
    }
}
