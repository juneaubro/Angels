using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    public GameObject angel;
    public GameObject aMusic;
    public GameObject iMusic;
    public GameObject eMusic;
    public GameObject xploSFX;
    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            try
            {
                cam.minPos = newMinPos;
                cam.maxPos = newMaxPos;
                col.transform.position += movePlayer;
                if (eMusic.activeInHierarchy == false) // eMusic.SetActive(false) no work
                {
                    angel.SetActive(true);
                    aMusic.SetActive(true);
                    iMusic.SetActive(false);
                    xploSFX.SetActive(true);
                    Invoke("DisXploSFX",2);
                }
            } catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    void DisXploSFX()
    {
        xploSFX.SetActive(false);
    }
}
