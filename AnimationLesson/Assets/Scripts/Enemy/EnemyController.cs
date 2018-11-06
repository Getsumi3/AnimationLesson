using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : DamageableEntity {

    
    public float attackRange = 1.5f;
    private float distance = 1.5f;

    private Transform target;
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        FollowTarget(speed);
    }

    private void FollowTarget(float _speed)
    {
        //enemy default direction
        Vector2 direction = Vector2.zero;

        if (target != null)
        {
            //if target was detected - enable run animation and move to target
            EnableAnimatorState("run");

            //face the sprite 
            direction = (target.position - transform.position).normalized;
            if (direction.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }

            //check distance between enemy and player
            distance = Vector2.Distance(target.position, transform.position);

            //attack if player is in range
            if (distance < attackRange)
            {
                EnableAnimatorState("attack");
                _speed = 0;
            }
            //if player isn't in range, move to target
            if (distance >= attackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
                EnableAnimatorState("run");
                _speed = 3f;
            }

            //stop following taget if his HP <= 0
            if (target.GetComponent<PlayerController>().health <= 0)
            {
                target = null;
            }
        }
        else
        {
            direction = Vector2.zero;
            EnableAnimatorState("idle");
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
