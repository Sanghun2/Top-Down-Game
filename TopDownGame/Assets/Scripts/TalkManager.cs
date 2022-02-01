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
        //100:����, 1000:�絵, 2000:�糪, 5000:�����ѹ���

        //��ȭ ������
        talkData.Add(100, new string[] {"�̰��� ���ڴ�."});
        talkData.Add(5000, new string[] {"������ ���̴� ������."});
        talkData.Add(1000, new string[] {"�ȳ�? ���� �絵. �� ����?:3"});
        talkData.Add(2000, new string[] {"���. ���� ó���̾�?:3", "�׷� �絵���� ����.:3", "�� �ؾ����� �˷��ٰž�.:3"});

        talkData.Add(2000 + 10, new string[] {"�ȳ�?:3", "�ؿ� �ִ� �ְ� �ʿ��� �� ���� �ֵ�...!:3"});
        talkData.Add(1000 + 10, new string[] {"��...:3"});
        talkData.Add(1000 + 11, new string[] {"���踦 ������ �� �־�? ��򰡿� ��ȴ��� ������...:3"});

        //�ʻ�ȭ ������
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
