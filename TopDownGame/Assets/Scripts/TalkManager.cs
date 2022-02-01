using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();
    Dictionary<int, Sprite> portraitData = new Dictionary<int, Sprite>();
    [SerializeField] Sprite[] NPC1PortraitImage;
    [SerializeField] Sprite[] NPC2PortraitImage;

    void Start()
    {
        GenerateData();
    }

    public void GenerateData()
    {
        //100:상자, 1000:루도, 2000:루나, 5000:수상한바위

        //대화 데이터
        talkData.Add(100, new string[] {"이것은 상자다."});
        talkData.Add(500, new string[] {"수상해 보이는 바위다."});
        talkData.Add(1000, new string[] {"안녕? 나는 루도. 넌 뭐냐?:1"});
        talkData.Add(2000, new string[] {"어서와. 여긴 처음이야?:3", "그럼 루도에게 가봐.:3", "뭘 해야할지 알려줄거야.:2"});
        //퀘스트 대화 데이터
        talkData.Add(10 + 2000, new string[] {"안녕?:3", "밑에 있는 애가 너에게 할 말이 있데...!:2"});
        talkData.Add(10 + 1000, new string[] {"음...:0"});
        talkData.Add(11 + 1000, new string[] {"열쇠를 구해줄 수 있어? 어딘가에 흘렸던거 같은데...:3"});
        
        talkData.Add(20 + 500, new string[] {"무언가 반짝인다.", "손을 뻗어서 열쇠를 얻었다!"});
        talkData.Add(20 + 2000, new string[] {"루도에게 말 걸어 봤어?:1"});
        talkData.Add(20 + 1000, new string[] {"어디에 떨어졌지...:1"});
        talkData.Add(21 + 1000, new string[] {"맞아! 이거야!:2", "이젠 탈출할 수 있어.:2"});
        
        talkData.Add(30 + 1000, new string[] {"이제 나갈 수 있어.:2"});
        talkData.Add(30 + 2000, new string[] {"이제 가는구나?:2"});

        //초상화 데이터
        portraitData.Add(1000 + 0, NPC1PortraitImage[0]); //angry
        portraitData.Add(1000 + 1, NPC1PortraitImage[1]); //idle
        portraitData.Add(1000 + 2, NPC1PortraitImage[2]); //smile
        portraitData.Add(1000 + 3, NPC1PortraitImage[3]); //talk

        portraitData.Add(2000 + 0, NPC2PortraitImage[0]);
        portraitData.Add(2000 + 1, NPC2PortraitImage[1]);
        portraitData.Add(2000 + 2, NPC2PortraitImage[2]);
        portraitData.Add(2000 + 3, NPC2PortraitImage[3]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            //해당 퀘스트 진행 순서에 대사가 없을 때 맨 처음 대사를 가지고 옴.
            if (!talkData.ContainsKey(id-id%10))
            {
                return GetTalk(id-id%100, talkIndex);
            }
            else
            {
                return GetTalk(id-id%10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }

    public Sprite GetProtrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
