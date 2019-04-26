using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{

    private bool isAttacking = false;
    private bool isStuned = false;

    private GameManager gameManager;
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Stats playerStats;
    private Component[] colliders;
    private Animator animator;

    [SerializeField] private float runSpeed = 1f;
    [SerializeField] private float lookRadius = 10f;
    [SerializeField] private int damage = 50;
    [SerializeField] private int health = 100;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        colliders = GetComponentsInChildren<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = GameObject.FindObjectOfType<Stats>();
    }


    // Update is called once per frame
    void Update()
    {
        float distace = Vector3.Distance(player.position, transform.position);

        if (distace <= lookRadius && !isStuned)
        {
            navMeshAgent.SetDestination(player.position);

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
        else if (distace > lookRadius)
        {
            if (isStuned)
            {
                Invoke("Unstun", 10f);
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
        Debug.Log("Is being hit");
        if (health <= 0)
            Stun();
    }

    IEnumerator Attack()
    {
        navMeshAgent.speed = 0;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.9f);
        playerStats.TakeDamage(damage);
        yield return new WaitForSeconds(1.75f);
        isAttacking = false;
    }

    void Stun()
    {
        StopAllCoroutines();
        isStuned = true;
        animator.SetBool("Stun", true);

        navMeshAgent.enabled = false;
    }

    void Unstun()
    {
        animator.SetBool("Stun", false);
        health = 60;
        isStuned = false;
        navMeshAgent.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        //To see the zombie range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
