using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	
	[Header("References")]
	[SerializeField] private Rigidbody2D _rigidBody;
	[SerializeField] private Enemy _hostEnemy;

	[Header("Stats")]
	[SerializeField] private float _movespeed = 2f;

	[SerializeField] private Transform _target;
	private Vector2 _direction;

	private void Start()
	{
		_target = _hostEnemy.Target;
	}

    private void Update()
    {
        _direction = (_target.position - transform.position).normalized;

        _rigidBody.velocity = _direction * _movespeed;

        Vector3 lookDirection = _target.position - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void OnValidate()
	{
		_rigidBody ??= GetComponent<Rigidbody2D>();
		_hostEnemy ??= GetComponent<Enemy>();
	}
}
