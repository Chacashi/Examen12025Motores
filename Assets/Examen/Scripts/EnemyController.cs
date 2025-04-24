using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] protected int damage;

    public int Damage => damage * -1;

}
