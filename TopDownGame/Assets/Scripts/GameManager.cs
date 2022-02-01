using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header("대화창")]
    [Space(15f)]
    [SerializeField] TypeEffect talkText;
    [SerializeField] GameObject talkBox;
    [SerializeField] Image portrait;
    GameObject scanObject;
    [SerializeField] Animator talkBoxAnim;
    [SerializeField] Animator portraitAnim;
    Sprite prevSprite;
    bool isAction;
    int talkIndex;
    Color alphaZero;
    Color alphaOne;

    [Header("메뉴창")]
    [Space(15f)]
    [SerializeField] GameObject menuSet;
    [SerializeField] Text questText;

    [Header("매니저")][Space(15f)]
    [SerializeField] TalkManager talkManager;
    [SerializeField] QuestManager questManager;

    void Start()
    {
        alphaZero = new Color(1, 1, 1, 0);
        alphaOne = new Color(1, 1, 1, 1);

        GameLoad();

        questText.text = questManager.CheckQuest();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf) menuSet.SetActive(false);
            else menuSet.SetActive(true);
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkBoxAnim.SetBool("isShow", isAction);
    }

    public void Talk(int id, bool isNPC)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (talkText.isAnim)
        {
            talkText.SetMsg("");
            return;
        }
        else
        {
            //set data
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //end talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0; //대화가 다 끝나면 대화초기화
            questText.text = questManager.CheckQuest(id);
            return;
        }

        if (isNPC)
        {
            //show portrait
            talkText.SetMsg(talkData.Split(':')[0]);
            portrait.sprite = talkManager.GetProtrait(id, int.Parse(talkData.Split(':')[1]));
            portrait.color = alphaOne;
            //portrait animation
            if (prevSprite != portrait.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevSprite = portrait.sprite;
            }
        }
        else
        {
            talkText.SetMsg(talkData);
            portrait.color = alphaZero;
        }

        isAction = true;
        talkIndex++;
    }

    public bool IsAction() => isAction;

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestID", questManager.questID);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);

        PlayerPrefs.Save();
        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questID = PlayerPrefs.GetInt("QuestID");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x,y,0);
        questManager.questID = questID;
        questManager.questActionIndex = questActionIndex;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
