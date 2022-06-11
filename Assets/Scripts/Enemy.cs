using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager _gameManager;
    Transform _playerPos;
    Rigidbody2D _enemyRb;
    PlayerController _playerController;

    float _speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        Vector2 direction = _playerPos.position - transform.position;
        _enemyRb.AddForce(direction.normalized * _speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Destroy(gameObject);
            _gameManager.Score += 30;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.PlayerHeath -= 5;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
