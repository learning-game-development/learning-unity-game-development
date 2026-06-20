using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Vector2 launchVector = new Vector2(50, 200);

    // Start is called before the first frame update
    public void LaunchAllPlayers()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();

        foreach(PlayerController player in players)
        {
            player.GetComponent<Rigidbody2D>().AddForce(launchVector);
        }
    }
}
