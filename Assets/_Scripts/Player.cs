
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;

    private Vector2 _input;
    [SerializeField]
    private float _speed = 3f;

    public UnityEvent onPlayerDie;
    private void Update()
    {
        _input = Vector2.zero;

        if (Keyboard.current != null)
        {
            _input.x =
                (Keyboard.current.dKey.isPressed ? 1 : 0) -
                (Keyboard.current.aKey.isPressed ? 1 : 0);

            _input.y =
                (Keyboard.current.wKey.isPressed ? 1 : 0) -
                (Keyboard.current.sKey.isPressed ? 1 : 0);
            _input.Normalize();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(onPlayerDie != null)
        {
            onPlayerDie.Invoke();
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = _input*_speed;
        
    }
}
