using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : LivingEntity
{
    public CharacterController2D controller;
    public Animator anim;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float crouchSpeed = 0f;
    bool jump = false;
    bool crouch = false;

    [SerializeField]
    Image healthBar;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        healthBar.fillAmount = 1;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        anim.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.W))
        {
             jump = true;
            anim.SetBool("IsJumpping",true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
            OnCrouching(true);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            OnCrouching(false);
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        healthBar.fillAmount = GetCurrentHealth() / maxHealth;

        if(GetCurrentHealth() <= 0.0f)
        {
            OnDeath();
        }
    }

    public override void OnDeath()
    {
        base.OnDeath();
        //Destroy(gameObject);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Onlanding()
    {
        anim.SetBool("IsJumpping", false);
    }
    public void OnCrouching(bool IsCrouch)
    {
        anim.SetBool("IsCrouch", IsCrouch);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
