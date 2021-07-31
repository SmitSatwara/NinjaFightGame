using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttact : MonoBehaviour
{
    public Animator anim;

    public LayerMask enemyMask;

    [SerializeField]
    CharacterController2D character;

    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("IsAttact",true);
        }
    }

    public void AttackAnim()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * character.CheckFaceSide(), rayDistance, enemyMask);

        if (hit)
        {
            Debug.Log("Player Attack");
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(20.0f);
        }
    }

    void StopAttack()
    {
        anim.SetBool("IsAttact", false);
    }
}
