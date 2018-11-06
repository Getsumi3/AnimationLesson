using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class for any gameobject that have health and took damage
public class DamageableEntity : MonoBehaviour, IDamageable
{
    protected float maxHealth;
    public float health;
    public Image hpBar;

    public float speed;

    protected Animator anim;

    void Awake()
    {
        maxHealth = health;
        hpBar.fillAmount = 1f;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        hpBar.fillAmount = health / maxHealth;

        if (health > 0)
        {
            anim.Play("hit");
        }
        else
        {
            anim.Play("die");
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hpBar.transform.parent.gameObject.SetActive(false);

        }
    }


}
