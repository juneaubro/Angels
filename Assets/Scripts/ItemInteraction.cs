using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject block;
    public GameObject tnt1;
    public GameObject tnt2;
    public GameObject tnt3;
    public GameObject tnt4;
    public GameObject keyForLockedRoom;
    public GameObject keyForExitDoor;
    public GameObject keyDoor;
    public GameObject exitDoor;
    public GameObject roomKeyText;
    public GameObject exitKeyText;
    public GameObject angel;
    public GameObject bigLight;
    public GameObject winText;
    public GameObject fL;

    public Animator tntExplode1;
    public Animator tntExplode2;
    public Animator tntExplode3;
    public Animator tntExplode4;

    private bool hasRoomKey;
    private bool hasExitKey;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "tntTrigger")
        {
            try
            {
                tntExplode1.SetBool("explode", true);
                tntExplode2.SetBool("explode", true);

                Destroy(tnt1, 3);
                Destroy(block, 2.7f);
                Destroy(tnt2, 3);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        if(col.name == "DoorCloseTrigger")
        {
            try
            {
                tnt3.SetActive(true);
                tnt4.SetActive(true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        if(col.name == "pressure plate")
        {
            try
            {
                tntExplode3.SetBool("longerExplode", true);
                tntExplode4.SetBool("longerExplode", true);

                Destroy(tnt3, 5);
                Destroy(tnt4, 5);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        if(col.name == "KeyForLockedRoom")
        {
            try
            {
                Destroy(keyForLockedRoom);
                hasRoomKey = true;
                roomKeyText.SetActive(true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        if(col.name == "KeyDoor" && hasRoomKey == true)
        {
            keyDoor.SetActive(false);
        }
        if(col.name == "KeyForExitDoor")
        {
            try
            {
                Destroy(keyForExitDoor);
                hasExitKey = true;
                exitDoor.SetActive(true);
                exitKeyText.SetActive(true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        if(col.name == "ExitDoor" && hasExitKey == true)
        {
            winText.SetActive(true);
            angel.SetActive(false);
            bigLight.SetActive(true);
            fL.SetActive(false);
        }
    }
}
