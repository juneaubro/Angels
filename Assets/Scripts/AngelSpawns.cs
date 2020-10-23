using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelSpawns : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;

    private int randNum;

    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(0, 5);

        if (randNum == 0)
            transform.position = new Vector3(Spawn1.transform.position.x, Spawn1.transform.position.y, transform.position.z);
        if (randNum == 1)
            transform.position = new Vector3(Spawn2.transform.position.x, Spawn2.transform.position.y, transform.position.z);
        if (randNum == 2)
            transform.position = new Vector3(Spawn3.transform.position.x, Spawn3.transform.position.y, transform.position.z);
        if (randNum == 3)
            transform.position = new Vector3(Spawn4.transform.position.x, Spawn4.transform.position.y, transform.position.z);
    }
}
