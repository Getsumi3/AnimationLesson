using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    //set the target Tag in inspector
    public string targetTag;

    //set weapon damage
    public float damage = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            collision.gameObject.GetComponent<DamageableEntity>().TakeDamage(damage);
        }
    }
}
