using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;
    public Animator hearts;
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (other.gameObject.CompareTag("Player"))
        {
            float currentLife = hearts.GetFloat("Life");
            Respawn(player);
            hearts.SetFloat("Life", currentLife - 0.1f);
            player.DeathCounter++;
            //TriesCounter();
            player.playerSpeed = player.startSpeed;
        }
    }

    void Respawn(PlayerMovement player)
    {
        player.transform.position = player.initialPosition;
        player.rb.velocity = Vector2.zero;
    }

    public void open()
    {
        animator.SetBool("openedSpike", true);
    }

    public void close() 
    {
        animator.SetBool("openedSpike", false);
    }
}
