using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkManager:Singleton<TalkManager>
{
    [SerializeField]
    private GameObject talkPanel;

    [SerializeField]
    private Image portraitImg;
    [SerializeField]
    private TMP_Text talkNameText;
    [SerializeField]
    private TMP_Text talkText;

    [SerializeField]
    private float textSpeed;

    private GameObject scanObj;
    private bool isAction;
    private bool isnowTalking;


    // Start is called before the first frame update
    void Start()
    {
        talkText.text = string.Empty;
    }

    public void Action(GameObject _scanObj)
    {
        scanObj = _scanObj;
        Debug.Log("talkmanager action 실행");
        Talk(scanObj.name + "이다!");
        isAction = true;
        talkPanel.SetActive(isAction);

    }

    void Talk(string _talkText)
    {
        StartCoroutine(TypeLine(_talkText));
    }

    IEnumerator TypeLine(string _talkText)
    {
        foreach (char c in _talkText.ToCharArray())
        {
            isnowTalking = true;
            talkText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isnowTalking = false;
        isAction = false;
        //talkPanel.SetActive(isAction) ;
    }

    void ChangeSprite()
    {
        if(portraitImg != null) 
        {
            StartCoroutine(SpriteChangeCoroutine(portraitImg));
        }
    }
    IEnumerator SpriteChangeCoroutine(Image _portraitImg)
    {
        yield return new WaitForSeconds(3.0f);
    }
}
