using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Attack") {
            Debug.Log("Attack OFF !!");

            Destroy(gameObject);

            Attack atkLogic = other.gameObject.GetComponent<Attack>();
            atkLogic.atkFlag = false;
            atkLogic.manager.OffAttackBox();
        }
    }
}
