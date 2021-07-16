using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : LivingEntity
{
    public Animator anim;

    [SerializeField]
    Image healthBar;

    public GameObject[] waypoints;
    int current = 0;
    
    public float speed;

    public float stopDistance;

    public enum State
    {
        Idle,
        Attack
    };

    public State currentState;

    public Rigidbody2D rb;

    public GameObject attackTrigger;

    public LayerMask playerMask;

    public float rayDistance;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        healthBar.fillAmount = 1;

        anim = GetComponent<Animator>();

        currentState = State.Idle;

        rb = GetComponent<Rigidbody2D>();

        attackTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dir = 0.0f;
        if(current == 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            dir = -1.0f;
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            dir = 1.0f;
        }
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < stopDistance)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        if (currentState == State.Idle)
        {
            Vector3 movePos = new Vector3(waypoints[current].transform.position.x, transform.position.y, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, movePos, Time.deltaTime * speed);

            anim.SetFloat("Speed", speed);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right * dir, rayDistance, playerMask);

        if (hit)
        {
            currentState = State.Attack;

            AttackPlayer();
        }

        else
        {
            currentState = State.Idle;
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        healthBar.fillAmount = GetCurrentHealth() / maxHealth;
    }

    public override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject);
    }

    public void Attack()
    {
        attackTrigger.SetActive(true);
    }

    public void StopAttack()
    {
        attackTrigger.SetActive(false);
     
        anim.SetBool("IsAttack", false);
    }

    void AttackPlayer()
    {
        anim.SetBool("IsAttack", true);
    }
}
