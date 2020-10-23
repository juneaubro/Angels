using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public GameObject bigRoomKeyText;
    public GameObject bigExitKeyText;
    public GameObject exitKeyText;              // should probably move this stuff to thier own script. because what would happen when I make level 2 on another scene?
    public GameObject angel;                    // Ill have all this stuff that isnt being used :/
    public GameObject bigLight;
    public GameObject winText;
    public GameObject winMenuBtn;
    public GameObject winQuitBtn;
    public GameObject winRetryBtn;
    public GameObject fL;
    public GameObject eMusic;
    public GameObject aMusic;
    public GameObject iMusic;
    public GameObject buttonSFX;
    public GameObject explosionSFX;
    public GameObject KeyDoorBlocker;
    public GameObject keySFX;
    public GameObject doorSFX;
    public GameObject weepSFX;
    public GameObject footSFX;
    public GameObject normalCanvas;
    public GameObject deathCanvas;
    public GameObject noteText;

    public Animator tntExplode1;
    public Animator tntExplode2;
    public Animator tntExplode3;
    public Animator tntExplode4;

    private bool hasRoomKey;
    private bool hasExitKey;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "chest")
        {
            noteText.SetActive(true);

            Invoke("DisableNoteText", 8);
        }

        if (col.name == "tntTrigger")
        {
            try
            {
                buttonSFX.SetActive(true);
                Invoke("DisableButtonSFX", 1);
                tntExplode1.SetBool("explode", true);
                tntExplode2.SetBool("explode", true);

                Invoke("PlayExplosionSFX", 2.45f);
                Invoke("DisableExplosionSFX", 5);

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
                buttonSFX.SetActive(true);
                Invoke("DisableButtonSFX", 1);

                tntExplode3.SetBool("longerExplode", true);
                tntExplode4.SetBool("longerExplode", true);

                Invoke("PlayExplosionSFX", 4.5f);
                Invoke("DisableExplosionSFX", 7.5f);

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
                keySFX.SetActive(true);

                Invoke("DisableKeySFX", 1);

                hasRoomKey = true;
                bigRoomKeyText.SetActive(true);

                Invoke("DesBigTexts", 5);

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
            KeyDoorBlocker.SetActive(false);

            doorSFX.SetActive(true);

            Invoke("DisableDoorSFX", 1);
        }
        if(col.name == "KeyForExitDoor")
        {
            try
            {
                Destroy(keyForExitDoor);
                keySFX.SetActive(true);

                Invoke("DisableKeySFX", 1);

                hasExitKey = true;
                bigExitKeyText.SetActive(true);

                Invoke("DesBigTexts", 5);

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
            if (eMusic.activeInHierarchy == false)
            {
                doorSFX.SetActive(true);

                Invoke("DisableDoorSFX", 1);
            }

            try
            {
                winText.SetActive(true);
                angel.SetActive(false);
                bigLight.SetActive(true);
                Destroy(fL);
                eMusic.SetActive(true);
                aMusic.SetActive(false);
                weepSFX.SetActive(false);
                winMenuBtn.SetActive(true);
                winQuitBtn.SetActive(true);
                winRetryBtn.SetActive(true);
            }
            catch
            {

            }
        }
        if (col.name == "Angel")
        {
            normalCanvas.SetActive(false);
            deathCanvas.SetActive(true);
            iMusic.SetActive(false);
            aMusic.SetActive(false);
            weepSFX.SetActive(false);
            Destroy(footSFX);
            Destroy(angel);
        }
    }

    void DesBigTexts()
    {
        if(hasRoomKey == true)
        {
            Destroy(bigRoomKeyText);
        }

        if(hasExitKey == true)
        {
            Destroy(bigExitKeyText);
        }
    }

    void DisableButtonSFX()
    {
        buttonSFX.SetActive(false);
    }

    void DisableExplosionSFX()
    {
        explosionSFX.SetActive(false);
    }

    void PlayExplosionSFX()
    {
        explosionSFX.SetActive(true);
    }

    void DisableKeySFX()
    {
        keySFX.SetActive(false);
    }

    void DisableDoorSFX()
    {
        doorSFX.SetActive(false);
    }

    void DisableNoteText()
    {
        noteText.SetActive(false);
    }
}
