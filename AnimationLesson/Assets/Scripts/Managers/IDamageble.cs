using UnityEngine;
using System.Collections;

//an interface for all gameobjects that took damage
public interface IDamageable
{
    void TakeDamage(float _damage);
}
