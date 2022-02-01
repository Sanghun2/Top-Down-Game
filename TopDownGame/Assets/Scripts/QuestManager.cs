using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionIndex;
    Dictionary<int, QuestData> questList = new Dictionary<int, QuestData>();

    void Awake()
    {
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("ù ���� �湮", 
            new int[] {2000, 1000}));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questID + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questID].npcID[questActionIndex])
        {
            questActionIndex++;
        }
        //��� ����Ʈ�� �Ϸ�Ǹ� ����Ǵ� ����
        if (questActionIndex == questList[questID].npcID.Length)
        {
            NextQuest();
        }

        return questList[questID].questName;
    }

    void NextQuest()
    {
        questID += 10;
        questActionIndex = 0;
    }
}
