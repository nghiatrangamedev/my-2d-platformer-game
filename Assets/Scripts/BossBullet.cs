using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    PlayerController _playerController;
    float _speed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward() 
    {
        transform.Translate(new Vector2(1,0) * _speed * Time.deltaTime);
        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.PlayerHeath -= 10;
            Destroy(gameObject);
        }
    }
}
