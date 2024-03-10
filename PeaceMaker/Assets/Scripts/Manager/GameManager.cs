using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.SceneManagement;

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
        curMapMonsters.Clear();
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
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindMapMonsters();
        Debug.Log("신규 씬이 로드되었습니다.");
    }
}
