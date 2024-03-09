using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    int newHealth;
    int maxHealthCnt = 12;

    public GameObject heartPrefab;

    [SerializeField]
    HPSO hpManager;

    List<HPHeart> hearts = new List<HPHeart>();

    private void OnEnable()
    {
        HPSO.OnPlayerHealed += DrawHearts;
        HPSO.OnPlayerDamaged += DrawHearts;
    }
    private void OnDisable()
    {
        HPSO.OnPlayerHealed -= DrawHearts;
        HPSO.OnPlayerDamaged -= DrawHearts;
    }
    private void Start()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();

        float maxHelathRemainder = maxHealthCnt % 4;
        int heartsToMake = (int)(maxHealthCnt / 4 + maxHelathRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }
        newHealth = ChangeHealthValue(hpManager.health);
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(newHealth - (i * 4), 0, 4);
            hearts[i].SetHeartImg((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HPHeart heartComponent = newHeart.GetComponent<HPHeart>();
        heartComponent.SetHeartImg(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HPHeart>();
    }

    public int ChangeHealthValue(float currentHealth)
    {
        //return (int)currentHealth * 4;
        if (currentHealth % 0.25 == 0)
        {
            return (int)(currentHealth / 0.25);
        }
        return (int)(currentHealth / 0.25) + 1;
        
    }
}
