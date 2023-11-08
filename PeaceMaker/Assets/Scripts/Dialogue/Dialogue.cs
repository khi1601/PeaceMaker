using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 치는 캐릭터 이름")]
    public string name;
    [Tooltip("대사내용")]
    public string[] dialogues;
    [Tooltip("대화ID")]
    public int talkId;
    [Tooltip("말하는 사람 Id")]
    public int[] talkerId;

    [HideInInspector]
    public string[] spriteName;


}

