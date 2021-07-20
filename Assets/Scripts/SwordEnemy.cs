using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<Enemy>().enemyFire)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if (GetComponent<Enemy>().enemyFire)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }

    }
private void OnTriggerEnter(Collider other)
    {

          if (other.CompareTag("Player"))
          {
                  other.GetComponent<PlayerMove>().TakeDamage(20);      
          }
    }
}
