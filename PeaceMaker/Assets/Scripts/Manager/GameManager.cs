using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class GameManager : MyBox.Singleton<GameManager>
{
    [SerializeField]
    private List<GameObject> curMapMonsters = new List<GameObject>();
    private void Awake()
    {
        InitializeSingleton(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        FindMapMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindMapMonsters()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Monster");

        foreach (GameObject obj in allObjects)
        {
            curMapMonsters.Add(obj);
        }
    }
    public void ReMapMonsters(GameObject obj)
    {
        for(int i=0;i< curMapMonsters.Count;i++)
        {
            if(curMapMonsters[i] == obj)
            {
                curMapMonsters.RemoveAt(i);
            }
        }
    }
    public List<GameObject> GetCurMapMonsters()
    {
        return curMapMonsters;
    }
}
