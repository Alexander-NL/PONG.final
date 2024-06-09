using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    public GameObject WinObject1 , WinObject2;
    public TMP_Text score1;
    public TMP_Text score2;
    int scoreplayer1 = 0;
    int scoreplayer2 = 0;
    public Ballin ballcon;

    public void addScore(int id)
    {
        if(id == 1)
        {
            scoreplayer1++;
            score1.text=scoreplayer1.ToString();
        }
        else if(id == 2)
        {
            scoreplayer2++;
            score2.text=scoreplayer2.ToString();
        }
    }

    void FixedUpdate()
    {
        if(scoreplayer1==5)
        {
            ballcon.ResetBall();
            WinObject1.SetActive(true);
            scoreplayer1=0;
            scoreplayer2=0;
        }
        else if(scoreplayer2==5)
        {
            ballcon.ResetBall();
            WinObject2.SetActive(true);
            scoreplayer1=0;
            scoreplayer2=0;
        }
    }
}
