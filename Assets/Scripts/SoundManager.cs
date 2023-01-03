using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float bgmPlayGrad;

    public AudioSource bgmPlay; // Potato

    private string bgmMuteKey = "key-BM";

    private float bgmPlaySpan;

    // Start is called before the first frame update
    void Start()
    {
        InitBGMPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(bgmMuteKey) == 1) {
            bgmPlay.volume = 0.0f;
        } else {
            GradBGMPlay();
        }
    }

    public void InitBGMPlay() {
        bgmPlay.Play();
        bgmPlaySpan = 0.0f;
    }

    public void GradBGMPlay() {
        bgmPlaySpan += Time.deltaTime;

        if(bgmPlaySpan > bgmPlayGrad) {
            bgmPlay.volume = 0.6f;
        } else {
            bgmPlay.volume = bgmPlaySpan / (bgmPlayGrad * 1.6f);
        }
    }
}
