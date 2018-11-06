using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to detect when Player is near
public class Radar : MonoBehaviour {

    private EnemyController enemy;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.Target = collision.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.Target = null;
        }
    }
}
