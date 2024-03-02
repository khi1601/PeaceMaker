using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HPScriptableObject", menuName = "ScriptableObjects/HP")]

public class HPSO : ScriptableObject
{
    public float health = 0f;
    public float maxHealth = 3.0f;

    public static event Action OnPlayerHealed;
    public static event Action OnPlayerDamaged;

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            //���ӿ����̺�Ʈ �߻�
        }

    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        OnPlayerHealed?.Invoke();
        if (health > maxHealth) //�ִ� ü���� �ѱ��
        {
            health = maxHealth;
        }
    }
}
