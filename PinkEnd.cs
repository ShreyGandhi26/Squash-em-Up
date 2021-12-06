using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnd : MonoBehaviour
{
    public bool pinkInPlace;


    // Start is called before the first frame update
    void Start()
    {
        pinkInPlace = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Pink"))
        {
            pinkInPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Pink"))
        {
            pinkInPlace = false;
        }
    }
}
