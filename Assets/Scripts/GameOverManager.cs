using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text curScoreText;
    public Text highScoreText;

    private static int curScore = 0;
    private int highScore = 0;

    private string curScoreKey = "key-CS";
    private string highScoreKey = "key-HS";

    void Awake() {
        InitHighScore();
        InitCurScore();
    }

    private void InitHighScore() {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString("0");
    }

    private void InitCurScore() {
        curScore = PlayerPrefs.GetInt(curScoreKey, 0);
        curScoreText.text = curScore.ToString("0");
    }
}