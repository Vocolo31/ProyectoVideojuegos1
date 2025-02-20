using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime = 0.5f;
    public float activeTime = 2f;
    public float Timer = 0f;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        GetDownPlatform();
    }

    void GetDownPlatform()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.2f;
            effector.rotationalOffset = 0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.2f;
                Timer = activeTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Timer > 0f)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                effector.rotationalOffset = 0f;
                Timer = 0f;
            }
        }


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
        }*/
    }
}
