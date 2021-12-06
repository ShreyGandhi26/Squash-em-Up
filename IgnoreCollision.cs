using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public GameObject pinkPlayer;
    public GameObject bluePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(),bluePlayer.GetComponent<Collider2D>());
    }
}
