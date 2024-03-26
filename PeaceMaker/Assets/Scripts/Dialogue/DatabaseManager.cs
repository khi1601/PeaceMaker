using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    [SerializeField]
    string csv_FileName_Kor;
    [SerializeField]
    string csv_FileName_Eng;
    [SerializeField]
    string csv_FileName_JP;

    //public Dictionary<int, Dictionary<int, Dialogue>> newQuestDic = new();
    public Dictionary<int, Dialogue> QuestDic = new();
    public Dictionary<int, Dialogue> QuestDic_Kor;
    public Dictionary<int, Dialogue> QuestDic_Eng;
    public Dictionary<int, Dialogue> QuestDic_Jp;

    public static bool isFinish = false;

    public override void Awake()
    {
        base.Awake();
        if (!isFinish )
        {
            gameObject.GetComponent<DialogueParser>().Parse(csv_FileName_Kor);
            QuestDic_Kor = new Dictionary<int, Dialogue>( QuestDic);
            QuestDic.Clear();
            gameObject.GetComponent<DialogueParser>().Parse(csv_FileName_Eng);
            QuestDic_Eng = new Dictionary<int, Dialogue>(QuestDic);
            QuestDic.Clear();
            gameObject.GetComponent<DialogueParser>().Parse(csv_FileName_JP);
            QuestDic_Jp = new Dictionary<int, Dialogue>(QuestDic);
            QuestDic.Clear();
            isFinish = true;
            if(isFinish ) { Debug.Log("ÆÄ½Ì ¿Ï·á"); }
            
        }
    }

    public Dialogue GetDialogue(int _talkId)
    {

        //if( QuestDic.ContainsKey( _talkId ) ) { return QuestDic[ _talkId ]; } else { return null; }
        int curLocaleIndex = LocaleManager.Instance.curLocale;
        switch(curLocaleIndex)
        {
            case 0:
                if (QuestDic_Eng.ContainsKey(_talkId))
                {
                    return QuestDic_Eng[_talkId];
                }
                else return null;
            case 1:
                if (QuestDic_Jp.ContainsKey(_talkId))
                {
                    return QuestDic_Jp[_talkId];
                }
                else return null;
            case 2:
                if (QuestDic_Kor.ContainsKey(_talkId))
                {
                    return QuestDic_Kor[_talkId];
                }
                else return null;
            default: return null;
        }
       /* if (curLocaleIndex == 0)
        {
            if(QuestDic_Eng.ContainsKey(_talkId))
            {
                return QuestDic_Eng[_talkId];
            }
            else return null;
        }
        else
        {
            if(QuestDic_Kor.ContainsKey(_talkId))
            {
                return QuestDic_Kor[_talkId];
            }
            else return null;
        }*/
    }
}
