using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSwitch : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject[] Transparent_platforms;
    public float goDown = 0.2f;
    private Vector3 currentPos;
    private int i = 0;


    private void Start()
    {
        for (i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(false);
        }
        for (i = 0; i < Transparent_platforms.Length; i++)
        {
            Transparent_platforms[i].SetActive(true);
        }
        currentPos = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Pink"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - goDown, transform.position.z);
            for (i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(true);
            }
            for (i = 0; i < Transparent_platforms.Length; i++)
            {
                Transparent_platforms[i].SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Pink"))
        {
            transform.position = currentPos;
            for (i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(false);
            }
            for (i = 0; i < Transparent_platforms.Length; i++)
            {
                Transparent_platforms[i].SetActive(true);
            }
        }
    }

}