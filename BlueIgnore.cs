using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueIgnore : MonoBehaviour
{
    public PlayerMovement bluePlayer;

    private void Update()
    {
        Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
    }
}
