using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject woodMPrefab;
    public GameObject woodLPrefab;
    public GameObject woodRPrefab;

    GameObject[] woodM;
    GameObject[] woodL;
    GameObject[] woodR;
    GameObject[] targetPool;

    void Awake()
    {
        woodM = new GameObject[6];
        woodL = new GameObject[6];
        woodR = new GameObject[6];

        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < woodM.Length; i++)
        {
            woodM[i] = Instantiate(woodMPrefab);
            woodM[i].SetActive(false);
        }

        for (int i = 0; i < woodL.Length; i++)
        {
            woodL[i] = Instantiate(woodLPrefab);
            woodL[i].SetActive(false);
        }
        for (int i = 0; i < woodR.Length; i++)
        {
            woodR[i] = Instantiate(woodRPrefab);
            woodR[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "WoodM":
                targetPool = woodM;
                break;
            case "WoodL":
                targetPool = woodL;
                break;
            case "WoodR":
                targetPool = woodR;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }
}
