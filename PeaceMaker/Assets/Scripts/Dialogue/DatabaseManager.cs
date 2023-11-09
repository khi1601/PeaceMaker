using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    [SerializeField]
    string csv_FileName;

    public Dictionary<int, Dialogue> QuestDic = new();

    public static bool isFinish = false;

    public override void Awake()
    {
        base.Awake();
        if (!isFinish )
        {
            gameObject.GetComponent<DialogueParser>().Parse(csv_FileName);
            isFinish = true;
            if(isFinish ) { Debug.Log("ÆÄ½Ì ¿Ï·á"); }
        }
    }

    public Dialogue GetDialogue(int _talkId)
    {
        if( QuestDic.ContainsKey( _talkId ) ) { return QuestDic[ _talkId ]; } else { return null; }
    }
}
