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
    public bool isnowTalking = false;

    int contextCnt = 0;
    Dialogue dialogues;
    // Start is called before the first frame update
    void Start()
    {
        talkText.text = string.Empty;
    }

    public void Action(GameObject _scanObj)
    {
        Debug.Log("talkmanager action 실행");
        scanObj = _scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Dialogue dialogues = DatabaseManager.Instance.GetDialogue(objData.id);
        
        Talk(dialogues);
        talkPanel.SetActive(isAction);

    }
    public void skipTalk()
    {
        Debug.Log("skip 실행");

        string talkData = string.Empty;
        talkText.text = string.Empty;
        talkData = dialogues.contexts[contextCnt];
        isnowTalking = false ;
    }
    void Talk(Dialogue p_dialogue)
    {
        string talkData = string.Empty;
        dialogues = p_dialogue;
        if(contextCnt<p_dialogue.contexts.Length)
        {
            talkText.text = string.Empty;
            talkData = p_dialogue.contexts[contextCnt];
            talkNameText.text = p_dialogue.name[contextCnt];
            
            StartCoroutine(TypeLine(talkData));
            contextCnt++;
            isAction = true;
            return;
            
        }
        else
        {
            isAction = false;
            contextCnt = 0;
            return;
        }
    }

    IEnumerator TypeLine(string _talkText)
    {
        ChangeSprite();
        foreach (char c in _talkText.ToCharArray())
        {
            isnowTalking = true;
            talkText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isnowTalking = false;
    }

    void ChangeSprite()
    {
        if (dialogues.spriteName[contextCnt]!="") 
        {
            SpriteChange(dialogues.spriteName[contextCnt]);
        }
    }
    public void SpriteChange(string p_spriteName)
    {
        Image thisImg = portraitImg.GetComponent<Image>();

        Sprite t_sprite = Resources.Load("Portraits/" + p_spriteName, typeof(Sprite)) as Sprite;
        thisImg.sprite = t_sprite;
        
    }
}
