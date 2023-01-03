using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public GameManager manager;

    public float deltaPos; // deltaPos > 0
    public float speed; // Object Move Speed

    Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameObject.name) {
            case "Guide Left":
                deltaPos = -Mathf.Abs(deltaPos);
                break;
            case "Guide Right":
                deltaPos = Mathf.Abs(deltaPos);
                break;
        }

        Vector3 v = currentPos;
        v.x += deltaPos * Mathf.Sin(Time.time * speed); // Max and invert handling of left and right movements
        transform.position = v;

        if(manager.startFlag) {
            Debug.Log(gameObject);
            gameObject.SetActive(false);
        }
    }
}
