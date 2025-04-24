using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody _compRigidbody;
    Vector3 _direction;
    [SerializeField] private float speed;


    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        _compRigidbody.linearVelocity = _direction * speed;
    }


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }


    void SetDirection(Vector2 value)
    {
        //_direction = new Vector3( v)
    }

}
