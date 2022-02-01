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
        questList.Add(10, new QuestData("첫 마을 방문", 
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
        //모든 퀘스트가 완료되면 실행되는 로직
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
