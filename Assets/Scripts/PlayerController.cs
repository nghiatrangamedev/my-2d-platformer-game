using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _sword;
    Rigidbody2D _playerRb;

    float _speed = 30.0f;
    float _jumpForce = 10.0f;
    float _heath = 100.0f;
    float _horizontalInput;
    float _verticalInput;

    bool _isOnGround = false;
    bool _isFaceRight = true;


    public float PlayerHeath
    {
        get 
        { 
            return _heath;
        }

        set
        {
            _heath = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // Take input from the player
    void PlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayerAttack());
        }
    }

    // Use physic to move the player
    void PlayerMovement()
    {
        if (_horizontalInput > 0)
        {
            if (!_isFaceRight)
            {
                FlipPLayer();
            }

            _playerRb.AddForce(Vector2.right * _horizontalInput * _speed);
        }

        else if (_horizontalInput < 0)
        {
            if (_isFaceRight)
            {
                FlipPLayer();
            }

            _playerRb.AddForce(Vector2.right * _horizontalInput * _speed);
        }

        if (_verticalInput != 0 && _isOnGround)
        {
            _playerRb.AddForce(Vector2.up * _verticalInput * _jumpForce, ForceMode2D.Impulse);
        }
    }

    // Flip PLayer
    void FlipPLayer()
    {
        _isFaceRight = !_isFaceRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    // Player Attack
    IEnumerator PlayerAttack()
    {
        _sword.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        _sword.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = false;
        }
    }

}
