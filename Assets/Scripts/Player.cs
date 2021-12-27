using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private bool _moving;
    private float _turnDirection;
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        _moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;

        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        if(_moving)
        {
            _rb2D.AddForce(this.transform.up * this.moveSpeed);
        }

        if(_turnDirection != 0.0f)
        {
            _rb2D.AddTorque(_turnDirection * this.turnSpeed);
        }
    }
}
