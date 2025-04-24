using UnityEngine;

public class EnemyMobile : EnemyController
{
    [Header("Movement")]
    [SerializeField] protected float speed;
    Rigidbody _compRigidbody;


    [Header("Patron")]
    [SerializeField] private Transform[] enemyTargets;
    private Transform currentTarget;
    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentTarget = enemyTargets[1];
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("target2"))
        {
            currentTarget = enemyTargets[0];

        }

        if (other.gameObject.CompareTag("target1"))
        {
            currentTarget = enemyTargets[1];

        }
    }


}
