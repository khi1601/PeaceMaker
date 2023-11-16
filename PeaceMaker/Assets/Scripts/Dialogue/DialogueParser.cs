using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public void Parse(string _CSVFileName)
    {
        List<Dialogue> dialoguelist = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Debug.Log(row[3]);
            if (row[0].Trim().Equals("end") || row[3].Trim().Equals("")) continue;

            Dialogue dialogue = new Dialogue();
            dialogue.talkId = int.Parse(row[3].Trim());

            int loopNum = 0;
            while (!row[3].Trim().Equals("end")) //하나의 대화
            {
                if (loopNum++ > 10000) throw new Exception("Infinite loop");

                List<string> talkerName = new List<string>(); //말하는 사람 이름
                List<string> contextList = new List<string>(); //대사
                List<string> spriteList = new List<string>(); //해당초상화
                do
                {
                    talkerName.Add(row[2].ToString());
                    contextList.Add(row[4].ToString());
                    spriteList.Add(row[5].ToString());
                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else break;
                } while (row[3] == "" || !row[3].Equals("end"));
                dialogue.name=talkerName.ToArray();
                dialogue.contexts = contextList.ToArray();
                dialogue.spriteName = spriteList.ToArray();
            }
            DatabaseManager.Instance.QuestDic.Add(dialogue.talkId, dialogue);
        }
    }
}
