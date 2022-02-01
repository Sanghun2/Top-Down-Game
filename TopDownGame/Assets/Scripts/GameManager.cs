using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("대화창")]
    [SerializeField] Text talkText;
    [SerializeField] GameObject talkBox;
    [SerializeField] Image portrait;
    GameObject curObject;
    ObjData obj;
    string tempTalk;
    bool isAction;
    int talkIndex;
    Color alphaZero;
    Color alphaOne;

    [Header("매니저")][Space(15f)]
    [SerializeField] TalkManager talkManager;
    [SerializeField] QuestManager questManager;

    void Start()
    {
        alphaZero = new Color(1, 1, 1, 0);
        alphaOne = new Color(1, 1, 1, 1);
    }

    public void Action(GameObject scanObject)
    {
        curObject = scanObject;
        Talk();
    }

    public void Talk()
    {
        if (!isAction)
        {
            isAction = true;
            talkBox.SetActive(true);
            obj = curObject.GetComponent<ObjData>();
        }
        
        if (obj.isNPC)
        {
            int questTalkIndex = questManager.GetQuestTalkIndex(obj.id);
            string tTalk = talkManager.GetTalk(obj.id + questTalkIndex, talkIndex);
            tempTalk = tTalk.Split(':')[0];
            if (tempTalk == null)
            {
                questManager.CheckQuest(obj.id);
                talkBox.SetActive(false);
                isAction = false;
                obj = null;
                tempTalk = null;
                curObject = null;
                talkIndex = 0;
            }
            else
            {
                talkText.text = tempTalk;
                portrait.color = alphaOne;
                int portraitIndex = int.Parse(tTalk.Split(':')[1]);
                portrait.sprite = talkManager.GetProtrait(obj.id, talkIndex);
                talkIndex++;
            }
        }
        else
        {
            int questTalkIndex = 0;
            tempTalk = talkManager.GetTalk(obj.id + questTalkIndex, talkIndex);
            if (tempTalk == null)
            {
                talkBox.SetActive(false);
                isAction = false;
                obj = null;
                tempTalk = null;
                curObject = null;
                talkIndex = 0;
            }
            else
            {
                talkText.text = tempTalk;
                portrait.color = alphaZero;
                talkIndex++;
            }
        }
    }

    public bool IsAction() => isAction;
}
