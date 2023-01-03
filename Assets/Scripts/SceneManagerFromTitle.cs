using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerFromTitle : MonoBehaviour
{
    public void ToPlayScene() {
        SceneManager.LoadScene("PlayScene");
    }

    public void ToExit() {
        #if UNITY_EDITOR // 유니티 에디터에서 종료하는 방식
            UnityEditor.EditorApplication.isPlaying = false;
        #else // // Application에서 종료하는 방식
            Application.Quit();    
        #endif 
    }
}
