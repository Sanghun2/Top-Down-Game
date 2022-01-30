using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    [SerializeField] TalkManager talkManager;

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
        tempTalk = talkManager.GetTalk(obj.id, talkIndex);
        if (obj.isNPC)
        {
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
                portrait.color = alphaOne;
                portrait.sprite = talkManager.GetProtrait(obj.id, talkIndex);
                talkIndex++;
            }
        }
        else
        {
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
