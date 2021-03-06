using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList = new Dictionary<int, QuestData>();

    void Awake()
    {
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("첫 마을 방문", 
            new int[] {2000, 1000}));
        questList.Add(20, new QuestData("열쇠 찾기",
            new int[] {500, 1000}));
        questList.Add(30, new QuestData("마을 탈출",
            new int[] { 10000 }));
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

        ControlObject();
        
        //모든 퀘스트가 완료되면 실행되는 로직
        if (questActionIndex == questList[questID].npcID.Length)
        {
            NextQuest();
        }

        return questList[questID].questName;
    }

    public string CheckQuest()
    {
        return questList[questID].questName;
    }

    void NextQuest()
    {
        if (questID < 30)
        {
            questID += 10;
        }
        questActionIndex = 0;
    }

    public void ControlObject()
    {
        if (questID == 20)
        {
            if (questActionIndex == 1)
            {
                questObject[0].SetActive(false);
            }
        }
        else if (questID > 20)
        {
            questObject[0].SetActive(false);
        }
    }
}
