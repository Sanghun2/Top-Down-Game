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
        talkData.Add(5000, new string[] {"수상해 보이는 바위다."});
        talkData.Add(1000, new string[] {"안녕? 나는 루도. 넌 뭐냐?:3"});
        talkData.Add(2000, new string[] {"어서와. 여긴 처음이야?:3", "그럼 루도에게 가봐.:3", "뭘 해야할지 알려줄거야.:3"});

        talkData.Add(2000 + 10, new string[] {"안녕?:3", "밑에 있는 애가 너에게 할 말이 있데...!:3"});
        talkData.Add(1000 + 10, new string[] {"음...:3"});
        talkData.Add(1000 + 11, new string[] {"열쇠를 구해줄 수 있어? 어딘가에 흘렸던거 같은데...:3"});

        //초상화 데이터
        portraitData.Add(1000, NPC1PortraitImage[0]);
        portraitData.Add(1000+1, NPC1PortraitImage[1]);
        portraitData.Add(1000+2, NPC1PortraitImage[2]);
        portraitData.Add(1000+3, NPC1PortraitImage[3]);

        portraitData.Add(2000, NPC2PortraitImage[0]);
        portraitData.Add(2000 + 1, NPC2PortraitImage[1]);
        portraitData.Add(2000 + 2, NPC2PortraitImage[2]);
        portraitData.Add(2000 + 3, NPC2PortraitImage[3]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkData[id].Length == talkIndex)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetProtrait(int id, int portraitIndex)
    {
        if (talkData[id].Length == portraitIndex)
        {
            return null;
        }
        else
        {
            return portraitData[id + portraitIndex];
        }
    }
}
