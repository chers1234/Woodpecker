using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 

// Admob API
using GoogleMobileAds.Api;

//scene 전환 
public class Scenemanager : MonoBehaviour
{
    public Canvas gameOverCanvas;

    private int clickedBtn; // 0: PlayScene, 1: TitleScene, 2: Exit

    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // Test Key
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910"; // Test Key
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    //게임 플레이 scene으로 전환
    public void ChangeScene()
    {
        clickedBtn = 0;

        RequestInterstitial();

        // When you want call Interstitial show
        StartCoroutine(showInterstitial());

        IEnumerator showInterstitial()
        {
            while(!this.interstitial.IsLoaded())
            {
                yield return new WaitForSeconds(0.2f);
            }

            this.interstitial.Show();

            gameOverCanvas.sortingOrder = -1;
        }
    }

    // TitleScene으로 전환
    public void ChangeSceneMainMenu()
    {
        clickedBtn = 1;

        RequestInterstitial();

        // When you want call Interstitial show
        StartCoroutine(showInterstitial());

        IEnumerator showInterstitial()
        {
            while(!this.interstitial.IsLoaded())
            {
                yield return new WaitForSeconds(0.2f);
            }

            this.interstitial.Show();

            gameOverCanvas.sortingOrder = -1;
        }
        
        // SceneManager.LoadScene("TitleScene");
    }

    //게임 종료
    public void ChangeSceneEXIT()
    {
        clickedBtn = 2;

        #if UNITY_EDITOR   //위에는 유니티 에디터에서 종료하는 방식
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();    
        #endif 
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        switch(clickedBtn)
        {
            case 0: // 0: PlayScene
                // MonoBehaviour.print("HandleAdClosed event received");
                SceneManager.LoadScene("PlayScene");
                break;
            case 1: // 1: TitleScene
                // MonoBehaviour.print("HandleAdClosed event received");
                SceneManager.LoadScene("TitleScene");
                break;
        }

        // // MonoBehaviour.print("HandleAdClosed event received");
        // SceneManager.LoadScene("PlayScene");
    }
    
}
