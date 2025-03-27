using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerMovement playermovement;
    public Animator checkpoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpoint.SetBool("Active", true);
            playermovement.initialPosition = transform.position;


            //CoinCounter();
        }
    }
}
