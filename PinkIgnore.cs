using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkIgnore : MonoBehaviour
{
    public PlayerMovement pinkPlayer;

    private void Update()
    {
        Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
    }
}
