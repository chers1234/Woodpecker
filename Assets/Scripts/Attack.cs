using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameManager manager;

    public bool atkFlag;

    public void BtnAtk() {
        if(!atkFlag) {
            Debug.Log("Attack ON !!");
            atkFlag = true;
            manager.OnAttackBox();
        }
    }
}
