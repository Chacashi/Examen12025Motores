using UnityEngine;
using UnityEngine.UIElements;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody _compRigidbody;
    Vector3 _direction;

    [Header("RaycastJump")]
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private Transform origin;
    [SerializeField] private Color collision;
    [SerializeField] private Color notCollision;
    RaycastHit hit;


    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canJump;
    [SerializeField] private bool isDoubleJump;
    [SerializeField] private bool isJump;

    [Header("Life")]

    [SerializeField] private int currentLife;
    [SerializeField] private int maxLife;

    public int CurrentLife => currentLife;
    public int MaxLife => maxLife;

    [Header("Points")]
    [SerializeField] private int currentPointsPlayer;
    public int CurrentPointsPlayer => currentPointsPlayer;


    public static event Action OnPlayerDeath;
    public static event Action OnPlayerTakeCoin;
    public static event Action OnPlayerTakeHeart;
    public static event Action OnPlayerReceiveDamage;
    public static event Action OnPlayerTakeTrush;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetLife(maxLife);
    }

    private void Update()
    {
        if (currentLife <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        _compRigidbody.linearVelocity = new Vector3(_direction.x * speed, _compRigidbody.linearVelocity.y, _direction.z * speed);
       

        if (Physics.Raycast(origin.position, Vector3.down, out hit, rayDistance, rayLayer))
        {
            Debug.DrawRay(origin.position, Vector3.down * hit.distance, collision);
            isJump = true;
            isDoubleJump = true;
        }
        else
        {

            Debug.DrawRay(origin.position, Vector3.down * rayDistance, notCollision);
            isJump = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle"))
        {
          
                AddLife(other.gameObject.GetComponent<EnemyController>().Damage);
                OnPlayerReceiveDamage?.Invoke();
      

        }

        if (other.gameObject.tag == "tacho")
        {
            OnPlayerTakeTrush?.Invoke();
        }


        if (other.gameObject.tag == "dead")
        {
            OnPlayerDeath?.Invoke();
        }

        if (other.gameObject.tag == "coin")
        {
            AddPoints(other.gameObject.GetComponent<ItemController>().Points);
            OnPlayerTakeCoin?.Invoke();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "heart")
        {
            AddLife(other.gameObject.GetComponent<ItemController>().Points);
            OnPlayerTakeHeart?.Invoke();
            Destroy(other.gameObject);
        }
    }


    private void OnEnable()
    {
        InputReaderGame.OnPlayerMovement += SetDirection;
        InputReaderGame.OnPressSpace += DoJump;
    }

    private void OnDisable()
    {
        InputReaderGame.OnPlayerMovement -= SetDirection;
        InputReaderGame.OnPressSpace -= DoJump;
    }


    void SetDirection(Vector2 value)
    {
        _direction = new Vector3(value.x, 0, value.y);
    }


    void DoJump(bool active)
    {
        canJump = active;
            if (canJump)
            {
                if (isJump)
                {
                    _compRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                    canJump = false;
                }
                else if (isDoubleJump)
                {
                    _compRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                    isDoubleJump = false;
                    canJump = false;
                }
            }
        
        
        
    }


    public void SetLife(int maxLife)
    {
        currentLife = maxLife;
    }

    public void AddLife(int pointLife)
    {

        currentLife = Mathf.Clamp(currentLife + pointLife, 0, maxLife);

    }

    public void AddPoints(int points)
    {
        currentPointsPlayer += points;

    }

}

