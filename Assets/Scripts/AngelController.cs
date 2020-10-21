using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{
    private Animator anim;
    private Transform target;
    [SerializeField] // editor
    private float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform; // our location i think :/
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (speed != 0f)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("Horizontal", (target.position.x - transform.position.x));
            anim.SetFloat("Vertical", (target.position.y - transform.position.y));
            anim.SetFloat("lastMoveX", (target.position.x - transform.position.x));
            anim.SetFloat("lastMoveY", (target.position.y - transform.position.y));
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        } else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Flashlight")
        {
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Flashlight")
        {
            Invoke("ResetSpeed", (Random.Range(0.2f, 5f)));
        }
    }

    public void ResetSpeed()
    {
        speed = 3.5f;
    }
}
