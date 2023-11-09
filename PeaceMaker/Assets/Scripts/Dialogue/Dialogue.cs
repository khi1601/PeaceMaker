using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [Tooltip("���ϴ� ��� Id")]
    public int[] talkerId;
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string[] name;
    [Tooltip("��ȭID")]
    public int talkId;
    [Tooltip("��系��")]
    public string[] contexts;
    [HideInInspector]
    public string[] spriteName;

    [Tooltip("����")]
    public string[] soundName;

}

