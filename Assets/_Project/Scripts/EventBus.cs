using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
     public static event Action<float> OnEnemyDied;
     public static event Action OnGameOver;

    public static void EnemyDied(float value)
    {
        OnEnemyDied?.Invoke(value);
    } 

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
