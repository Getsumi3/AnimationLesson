using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DamageableEntity {


    void Start()
    {
        anim = GetComponent<Animator>();
        EnableAnimatorState("idle");
    }
    // Update is called once per frame
    void Update ()
    {
        Move();
        Attack();
	}

    private void Move()
    {
        //get WASD or ARROWS input 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //set the direction according to input
        Vector2 direction = new Vector2(h, v);
        transform.Translate(direction * speed * Time.deltaTime);

        //flip sprite if we go left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //if player press move keys then play walk animation, else play idle animation
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            EnableAnimatorState("walk");
        }
        else
        {
            EnableAnimatorState("idle");
        }


    }

    private void Attack()
    {
        //play attack animation if player press SPACE. //attack logics in Attack.cs
        if (Input.GetButton("Jump"))
        {
            EnableAnimatorState("attack");
        }
    }

    //animator state controller

    private void DisableAnimatorStates(Animator _anim, string _stateName)
    {
        foreach (AnimatorControllerParameter param in _anim.parameters)
        {
            if (param.name != _stateName)
            {
                _anim.SetBool(param.name, false);
            }
        }
    }

    private void EnableAnimatorState(string _stateName)
    {
        DisableAnimatorStates(anim, _stateName);
        anim.SetBool(_stateName, true);
    }
}
