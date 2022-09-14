using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    [SerializeField] KeyCode key;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip[] clips;

    public static int score = 0;
    bool canInteract;
    bool pressedToKill = false;
    bool isDead = false;
    bool healthLose = true;
    void Awake()
    {
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && canInteract == true)
        {
            score++;
            pressedToKill = true;
        }
        if (Input.GetKeyDown(key))
        {
            AS.PlayOneShot(clips[0]);
        }

        if (Input.GetKeyDown(key) && healthLose == true)
        {
            GameManager.Health--;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        canInteract = true;
        healthLose = false;

        if (pressedToKill)
        {
            isDead = true;
            Destroy(collision.gameObject);
            AS.PlayOneShot(clips[1]);
            healthLose = true;
        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isDead = pressedToKill == false?false:true;

        canInteract = false;
        pressedToKill = false;
        if (!isDead)
        {
            Destroy(collision.gameObject);
            GameManager.Health--;
            AS.PlayOneShot(clips[2]);
        }
    }
}
