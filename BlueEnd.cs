using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnd : MonoBehaviour
{
    public bool blueInPlace;

    // Start is called before the first frame update
    void Start()
    {
        blueInPlace = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Blue"))
        {
            blueInPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Blue"))
        {
            blueInPlace = false;
        }
    }
}
