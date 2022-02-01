using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public int CPS; //초당 몇 글자가 나오는지
    Text msgText;
    [SerializeField] GameObject endCursor;
    AudioSource audioSource;
    int index;
    float interval;
    public bool isAnim;

    void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            CancelInvoke();
            msgText.text = targetMsg;
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        endCursor.SetActive(false); 
        msgText.text = "";
        index = 0;

        interval = 1f / CPS;
        Invoke("Effecting", interval);
        isAnim = true;
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        //sound
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
        {
            audioSource.Play();
        }
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        endCursor.SetActive(true);
        isAnim = false;
    }
}
