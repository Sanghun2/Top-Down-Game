using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();
    Dictionary<int, Sprite> portraitData = new Dictionary<int, Sprite>();
    [SerializeField] Sprite[] portraitImage;

    void Start()
    {
        GenerateData();
    }

    public void GenerateData()
    {
        //100 : 상자, 1000 : 루도
        talkData.Add(100, new string[] {"이것은 상자다."});
        talkData.Add(1000, new string[] {"안녕? 나는 루도. 넌 뭐냐?", "음... 여기서 나가고 싶다면 열쇠가 필요해..."});

        portraitData.Add(1000, portraitImage[0]);
        portraitData.Add(1000+1, portraitImage[1]);
        portraitData.Add(1000+2, portraitImage[2]);
        portraitData.Add(1000+3, portraitImage[3]);
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

    public Sprite GetProtrait(int id, int talkIndex)
    {
        if (talkData[id].Length == talkIndex)
        {
            return null;
        }
        else
        {
            return portraitData[id + talkIndex];
        }
    }
}
