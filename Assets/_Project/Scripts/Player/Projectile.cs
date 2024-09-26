using System.Collections;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Vector3 _targetDir;
	private float _damage;
	private float _moveSpeed = 2;

	public GameObject HitSpawnPrefab;

	private Vector2 _direction;


    public void Initialize(Vector3 targetDir, float damage)
	{
		this._targetDir = targetDir;
		this._damage = damage;
        StartCoroutine(DestroyInTime());

        _direction = (_targetDir - transform.position).normalized;
    }
	 
	private void Update()
    {
        transform.position += (Vector3)(_direction * _moveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.GetDamage(_damage);

			if (HitSpawnPrefab != null)
			{
				Instantiate(HitSpawnPrefab, transform.position, Quaternion.identity);
			}

			Destroy(gameObject);
		}
	}

	public IEnumerator DestroyInTime()
	{
		yield return new WaitForSeconds(6);
		if (gameObject != null)
		{
			Destroy(gameObject);
		}
	}
}
