using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }

    }
private void OnTriggerExit (Collider other)
    {
          if (other.CompareTag("Enemy"))
          {
                  other.GetComponent<ITakeDamage>().TakeDamage(10);      
          }
    }
}
