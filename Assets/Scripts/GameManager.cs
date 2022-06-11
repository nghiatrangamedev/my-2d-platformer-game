using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _player;
    
    PlayerController _playerController;

    float _timeStart = 2.0f;
    float _timeRate = 1.0f;
    float _currentHeath = 100.0f;

    public float Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();

        InvokeRepeating("SpawnEnemy", _timeStart, _timeRate);

        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        BossApper();
    }

    void SpawnEnemy()
    {
        float randomPosX = Random.Range(-1, 2);
        if (randomPosX != 0 && Score < 100)
        {
            Vector3 randomPos = new Vector3(randomPosX * 35, -7,  0);
            Instantiate(_enemy, randomPos, _enemy.transform.rotation);
        }

    }

    void BossApper()
    {
        if (Score >= 100)
        {
            _boss.SetActive(true);
        }
        
    }

    void CheckHealth()
    {
        if (_currentHeath != _playerController.PlayerHeath)
        {
            _currentHeath = _playerController.PlayerHeath;
            Debug.Log(_currentHeath);
        }

        if (_currentHeath == 0)
        {
            Destroy(_player);
            Debug.Log("Game Over");
        }
    }
}
