using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttact : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("IsAttact",true);
        }
    }

    public void StopAttackAnim()
    {
        anim.SetBool("IsAttact", false);
    }
}
