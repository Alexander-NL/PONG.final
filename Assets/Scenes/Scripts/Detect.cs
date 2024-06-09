using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public Test con;
    public int id = 0;
    public Ballin ballcon;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ball")
        {
            con.addScore(id);
            ballcon.RestartBall();
        }
    }
    
}
