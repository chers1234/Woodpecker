using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    public GameManager manager;

    public float maxTime; // 5f
    public float decreaseTime; // maxTime
    public float increaseTime; // 0.5f

    Image timeBar;

    // Start is called before the first frame update
    void Start()
    {
        timeBar = GetComponent<Image>();
        decreaseTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.startFlag) return;

        if(decreaseTime > 0) {
            decreaseTime -= Time.deltaTime;
            timeBar.fillAmount = decreaseTime / maxTime;
        } else {
            SceneManager.LoadScene("GameOverScene");
            Time.timeScale = 0;
        }

        if(manager.timeBarFlag) {
            manager.timeBarFlag = false;

            if(decreaseTime >= maxTime) {
                decreaseTime = maxTime;
            }
            
            decreaseTime += increaseTime;
        }
    }
}
