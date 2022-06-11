using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Transform _gun;
    [SerializeField] GameObject _bullet;

    PlayerController _playerController;

    float _heath = 100.0f;

    bool _isShooted = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
        Shoot();
    }

    void LookAt()
    {
        Vector3 direction = _player.transform.position - transform.position;
        _gun.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), direction);
    }

    void Shoot()
    {
        if (!_isShooted)
        {
            _isShooted = true;
            Instantiate(_bullet, _gun.transform.position, _gun.transform.rotation);
            StartCoroutine(ShootRate());
        }
        
    }

    IEnumerator ShootRate()
    {
        yield return new WaitForSeconds(1);
        _isShooted = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.PlayerHeath -= 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            _heath -= 10;
            if (_heath <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
