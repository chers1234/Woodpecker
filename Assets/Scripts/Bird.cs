using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public GameManager manager;

    public bool leftFlag;
    public bool rightFlag;

    public void Left()
    {
        leftFlag = true;
        rightFlag = false;

        if(leftFlag && ((manager.woodArr[1].tag == "WoodL") || (manager.woodArr[0].tag == "WoodL"))) {
            SceneManager.LoadScene("GameOverScene");
            manager.InitCurScore();
        }

        Vector3 scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;

        Vector3 pos = transform.position;
        pos.x = -Mathf.Abs(pos.x);
        transform.position = pos;

        manager.UpdateTimeBarFlag();
    }
    public void Right()
    {
        leftFlag = false;
        rightFlag = true;

        if(rightFlag && ((manager.woodArr[1].tag == "WoodR") || (manager.woodArr[0].tag == "WoodR"))) {
            SceneManager.LoadScene("GameOverScene");
            manager.InitCurScore();
        }

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;

        Vector3 pos = transform.position;
        pos.x = Mathf.Abs(pos.x);
        transform.position = pos;
        
        manager.UpdateTimeBarFlag();
    }
}