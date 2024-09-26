using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public event Action<float> DamageTaken;

	public event Action<float> HealthIncreesed;

	public event Action<float> EnemyDied;

	public Transform Target;

	[SerializeField] private int _value;

    public void GetDamage(float value)
    {
		DamageTaken?.Invoke(value);
    }

	public void IncreseStats(float extDamage, float extHP)
	{
		HealthIncreesed?.Invoke(extHP);
	}

    private void OnDestroy()
    {
		EventBus.EnemyDied(_value);
    }

}
