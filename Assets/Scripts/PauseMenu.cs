using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 일시정지
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuCanvas;

    public void Menu()
    {    
            if(GameIsPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
    }

    //게임 재게
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    //게임 일시정지
    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    //메인 메뉴로 이동 시 게임 타임이 0으로 고정된 것을 풀기 위함.
    public void MenuGame()
    {
        Time.timeScale= 1f;
        AudioListener.pause = false;
    }
}

