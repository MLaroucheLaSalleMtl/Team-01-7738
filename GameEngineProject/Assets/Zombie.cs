using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private static int zombieCount;

    private int randomRun;
    private float runSpeed;

    private bool isAttacking = false;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private MikeControl playerStats;
    private Component[] colliders;
    private Animator animator;

    [SerializeField] private float lookRadius = 10f;
    [SerializeField] private int damage = 105;
    [SerializeField] private int health = 50;

    public static int ZombieCount { get { return zombieCount; } set { zombieCount = value; } }

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        colliders = GetComponentsInChildren<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // ---- playerStats = GameObject.Find("FirstPersonCharacter").GetComponent<Stats>();

        randomRun = Random.Range(0, 2);

        if (randomRun == 0)
        {
            animator.SetInteger("randomRun", 0);
            runSpeed = navMeshAgent.speed = Random.Range(5, 8);
        }

        else if (randomRun == 1)
        {
            animator.SetInteger("randomRun", 1);
            runSpeed = navMeshAgent.speed = Random.Range(3, 5);
        }

    }

    // Use this for initialization
    void Start()
    {
        zombieCount++;

        //foreach (Collider collider in colliders)
        //    if (collider != core)
        //        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distace = Vector3.Distance(player.position, transform.position);

        if (distace <= lookRadius)
        {
            navMeshAgent.SetDestination(player.position);
            FaceTarget();

            if (!isAttacking)
            {
                animator.SetInteger("randomAttack", -1);
                navMeshAgent.speed = runSpeed;
            }

            if (distace <= navMeshAgent.stoppingDistance)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(Attack());
                }

                FaceTarget();
            }
            else
            {
                isAttacking = false;
                StopAllCoroutines();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
            Die();
    }

    IEnumerator Attack()
    {
        navMeshAgent.speed = 0;
        animator.SetInteger("randomAttack", Random.Range(0, 2));
        yield return new WaitForSeconds(0.9f);
        // ----StartCoroutine(playerStats.TakeDamage(damage));s
        yield return new WaitForSeconds(1.75f);
        isAttacking = false;
    }

    public void Die()
    {
        StopAllCoroutines();  //Prevents the Zombie deal damage to the player

        Animator animator = GetComponent<Animator>();
        animator.enabled = false;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        // core.enabled = false;
        navMeshAgent.enabled = false;
        this.enabled = false;

        //foreach (Collider collider in colliders)
        //{
        //    if (collider != core)
        //    {
        //        collider.enabled = true;
        //        collider.GetComponent<Rigidbody>().isKinematic = false;
        //    }
        //}

       
        Destroy(gameObject, 60f);
    }

    private void OnDrawGizmosSelected()
    {
        //To see the zombie range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}
