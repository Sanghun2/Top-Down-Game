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
        talkData.Add(500, new string[] {"������ ���̴� ������."});
        talkData.Add(1000, new string[] {"�ȳ�? ���� �絵. �� ����?:1"});
        talkData.Add(2000, new string[] {"���. ���� ó���̾�?:3", "�׷� �絵���� ����.:3", "�� �ؾ����� �˷��ٰž�.:2"});
        //����Ʈ ��ȭ ������
        talkData.Add(10 + 2000, new string[] {"�ȳ�?:3", "�ؿ� �ִ� �ְ� �ʿ��� �� ���� �ֵ�...!:2"});
        talkData.Add(10 + 1000, new string[] {"��...:0"});
        talkData.Add(11 + 1000, new string[] {"���踦 ������ �� �־�? ��򰡿� ��ȴ��� ������...:3"});
        
        talkData.Add(20 + 500, new string[] {"���� ��¦�δ�.", "���� ��� ���踦 �����!"});
        talkData.Add(20 + 2000, new string[] {"�絵���� �� �ɾ� �þ�?:1"});
        talkData.Add(20 + 1000, new string[] {"��� ��������...:1"});
        talkData.Add(21 + 1000, new string[] {"�¾�! �̰ž�!:2", "���� Ż���� �� �־�.:2"});
        
        talkData.Add(30 + 1000, new string[] {"���� ���� �� �־�.:2"});
        talkData.Add(30 + 2000, new string[] {"���� ���±���?:2"});

        //�ʻ�ȭ ������
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
            //�ش� ����Ʈ ���� ������ ��簡 ���� �� �� ó�� ��縦 ������ ��.
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
