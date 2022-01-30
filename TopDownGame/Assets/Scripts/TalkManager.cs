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
        //100 : ����, 1000 : �絵
        talkData.Add(100, new string[] {"�̰��� ���ڴ�."});
        talkData.Add(1000, new string[] {"�ȳ�? ���� �絵. �� ����?", "��... ���⼭ ������ �ʹٸ� ���谡 �ʿ���..."});

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
