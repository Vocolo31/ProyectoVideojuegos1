using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Spikes spikes;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (other.gameObject.CompareTag("Player"))
        {
            spikes.close();
            animator.SetBool("Push", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        animator.SetBool("Push", false);

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(spikeMovement(0.5f));
        }
    }

    IEnumerator spikeMovement(float time) 
    {
        spikes.close();

        yield return new WaitForSeconds(time);

        spikes.open();
    }
}
