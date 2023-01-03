using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Sfx {
        Attack
    };

    public float originPos; // = -4.26f(Root), = -3.575f(root2);
    public float newPos; // = -0.69f;
    public float bgmPlayGrad;

    public bool timeBarFlag;
    public bool startFlag;

    public GameObject[] woodObjs;
    public GameObject[] woodArr;

    public GameObject atkObj;
    public GameObject timeBarObj;

    public AudioSource bgmPlay; // Chunkey Monkey
    public AudioSource[] sfxPlay; // 1

    public AudioClip[] sfxPlayClip;

    public Transform[] spawnPoints;

    public Text curScoreText;
    public Text highScoreText;

    private static int curScore = 0;
    private int highScore = 0;
    private int sfxCursor;

    private float bgmPlaySpan;

    private string curScoreKey = "key-CS";
    private string highScoreKey = "key-HS";
    private string bgmMuteKey = "key-BM";

    void Awake() {
        CreateTree();
        InitHighScore();
    }

    void Start() {
        InitBGMPlay();
    }

    void Update() {
        if(PlayerPrefs.GetInt(bgmMuteKey) == 1) {
            bgmPlay.volume = 0.0f;
        } else {
            GradBGMPlay();
        }
    }

    public void CreateTree() {
        int ranWood;

        GameObject newWood;

        woodArr = new GameObject[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(i <= 2) {
                woodArr[i] = Instantiate(woodObjs[0]);
                spawnPoints[i].position = new Vector3(0, originPos, 0);
                woodArr[i].transform.position = spawnPoints[i].position;
                originPos += 0.69f;
                continue;
            }

            if(woodArr[i - 1].tag == "WoodM") {
                ranWood = Random.Range(0, 3);

                newWood = Instantiate(woodObjs[ranWood]);
                newWood.transform.position = SetWoodSpawnPosition(ranWood, i, originPos);

                woodArr[i] = newWood;

                originPos += 0.69f;
            } else {
                spawnPoints[i].position = new Vector3(0, originPos, 0);
                newWood = Instantiate(woodObjs[0]);
                newWood.transform.position = spawnPoints[i].position;

                woodArr[i] = newWood;

                originPos += 0.69f;
            }
        }
    }

    public void InitHighScore() {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString("0");
    }

    public void InitCurScore() {
        curScore = 0;
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

    public void SfxPlay(Sfx type) {
        switch(type) {
            case Sfx.Attack:
                // sfxPlay[sfxCursor].clip = sfxPlayClip[Random.Range(0, 3)];
                sfxPlay[sfxCursor].clip = sfxPlayClip[0];
                break;
        }

        sfxPlay[sfxCursor].Play();
        // sfxCursor = (sfxCursor + 1) % sfxPlay.Length;
    }

    public void OnAttackBox() {
        if(!startFlag) {
            startFlag = true;
        }
        atkObj.SetActive(true);
    }

    public void OffAttackBox() {
        atkObj.SetActive(false);
        
        SfxPlay(Sfx.Attack);
        
        int ranWood;
        GameObject newWood;

        if(woodArr[woodArr.Length - 1].tag == "WoodM") {
            ranWood = Random.Range(0, 3);

            newWood = Instantiate(woodObjs[ranWood]);
            newWood.transform.position = SetWoodSpawnPosition(ranWood, spawnPoints.Length - 1, spawnPoints[spawnPoints.Length - 1].position.y);

            MoveWood(newWood);
        } else {
            newWood = Instantiate(woodObjs[0]);

            spawnPoints[spawnPoints.Length - 1].position = new Vector3(0, spawnPoints[spawnPoints.Length - 1].position.y, 0);

            newWood.transform.position = spawnPoints[spawnPoints.Length - 1].position;

            MoveWood(newWood);
        }

        ScoreUp();
    }

    public void UpdateTimeBarFlag() {
        timeBarFlag = true;
    }

    private Vector3 SetWoodSpawnPosition(int woodIdx, int spawnIdx, float posY) {
        switch(woodIdx) {
            case 0: // Middle
                spawnPoints[spawnIdx].position = new Vector3(0, posY, 0);
                break;
            case 1: // Left
                spawnPoints[spawnIdx].position = new Vector3(-0.42f, posY, 0);
                break;
            case 2: // Right
                spawnPoints[spawnIdx].position = new Vector3(0.42f, posY, 0);
                break;
        }

        return spawnPoints[spawnIdx].position;
    }

    private void MoveWood(GameObject wood) {
        for(int i = 0; i < spawnPoints.Length - 1; i++) {
            woodArr[i] = woodArr[i + 1];
            switch(woodArr[i].tag) {
                case "WoodM":
                    spawnPoints[i].position = new Vector3(0, spawnPoints[i].position.y, 0);
                    break;
                case "WoodL":
                    spawnPoints[i].position = new Vector3(-0.42f, spawnPoints[i].position.y, 0);
                    break;
                case "WoodR":
                    spawnPoints[i].position = new Vector3(0.42f, spawnPoints[i].position.y, 0);
                    break;
            }
            woodArr[i].transform.position = spawnPoints[i].position;
        }
        woodArr[spawnPoints.Length - 1] = wood;
    }

    private void ScoreUp() {
        curScore++;
        curScoreText.text = curScore.ToString();

        PlayerPrefs.SetInt(curScoreKey, curScore);
        if(curScore > highScore) {
            PlayerPrefs.SetInt(highScoreKey, curScore);
        }
    }
}
