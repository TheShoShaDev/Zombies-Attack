using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attacking")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPos;

    public Transform _xMark;

    private float _timeSinceLastAttack;
    private bool _isGameOver = false;

    [Header("CurInfo")]
    [SerializeField] private float _currentDamage;
    [SerializeField] private float _currentAttackSpeed;

    private void Update()
    {
        if(_isGameOver)
        {
            return;
        }

        _timeSinceLastAttack += Time.deltaTime;

        if (_timeSinceLastAttack >= 1 / _currentAttackSpeed)
        {
             Attack();
            _timeSinceLastAttack = 0;
        }
    }

    public void Attack()
    {
        GameObject _proj = Instantiate(_projectilePrefab, _projectileSpawnPos.position, Quaternion.identity);
        _proj.GetComponent<Projectile>().Initialize(_xMark.position, _currentDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {   
            _isGameOver = true;
            EventBus.GameOver();
        }
    }
}
