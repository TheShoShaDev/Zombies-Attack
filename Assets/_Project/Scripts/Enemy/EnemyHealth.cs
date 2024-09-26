using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
	[SerializeField] private Enemy enemy;

	[Header("Info")]
	[SerializeField] private float __maxHealth;


    protected override void Start()
	{
        _maxHealth = __maxHealth;
        base.Start();
    }

	private void OnEnable()
	{
		enemy.DamageTaken += OnDecreseHealth;
	}

	private void OnDestroy()
	{
		enemy.DamageTaken -= OnDecreseHealth;
	}

	private void OnDisable()
	{
		enemy.DamageTaken -= OnDecreseHealth;
	}

	protected override void OnDecreseHealth(float value)
	{
		Vector3 _localScale = transform.localScale;
		Vector3 _newScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);

		base.OnDecreseHealth(value);

		if(_currentHealth <= 0)
		{
			Destroy(gameObject);
			Destroy(enemy);
			return;
		}
	}
}
