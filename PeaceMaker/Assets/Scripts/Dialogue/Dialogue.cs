using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string name;
    [Tooltip("��系��")]
    public string[] dialogues;
    [Tooltip("��ȭID")]
    public int talkId;
    [Tooltip("���ϴ� ��� Id")]
    public int[] talkerId;

    [HideInInspector]
    public string[] spriteName;


}

