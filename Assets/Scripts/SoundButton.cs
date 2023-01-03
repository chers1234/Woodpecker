using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;

    private string bgmMuteKey = "key-BM";

    private bool muted = false;

    // Start is called before the first frame update
    public void Start()
    {
        if(!PlayerPrefs.HasKey(bgmMuteKey)) {
            PlayerPrefs.SetInt(bgmMuteKey, 0);
            Load();
        } else {
            Load();
        }

        UpdateButtonIcon();
    }

    // Update is called once per frame
    public void SoundClick()
    {
        if(!muted) {
            muted = true;  
        } else {
            muted = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon() {
        if(!muted) {
            soundOn.enabled = true;
            soundOff.enabled = false;
        } else {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }

    private void Load() {
        muted = PlayerPrefs.GetInt(bgmMuteKey) == 1;
    }
    private void Save() {
        PlayerPrefs.SetInt(bgmMuteKey, muted ? 1 : 0);
    }
}
