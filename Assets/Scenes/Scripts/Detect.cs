using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Detect : NetworkBehaviour
{
    public Test con;
    public int id = 0;
    public Ballin ballcon;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            con.AddScoreServerRpc(id);
            ballcon.RestartBall();
        }
    }

}