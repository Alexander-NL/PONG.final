using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Test : NetworkBehaviour
{
    public GameObject WinObject1, WinObject2;
    public TMP_Text score1;
    public TMP_Text score2;
    public Ballin ballcon;

    private NetworkVariable<int> scorePlayer1 = new NetworkVariable<int>();
    private NetworkVariable<int> scorePlayer2 = new NetworkVariable<int>();

    [ServerRpc(RequireOwnership = false)]
    public void AddScoreServerRpc(int id)
    {
        if (NetworkManager.Singleton.ConnectedClients.Count < 2)
        {
            return;
        }

        if (id == 1)
        {
            scorePlayer1.Value++;
        }
        else if (id == 2)
        {
            scorePlayer2.Value++;
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        score1.text = scorePlayer1.Value.ToString();
        score2.text = scorePlayer2.Value.ToString();
    }

    private void Start()
    {
        scorePlayer1.OnValueChanged += (oldValue, newValue) => UpdateScoreUI();
        scorePlayer2.OnValueChanged += (oldValue, newValue) => UpdateScoreUI();
    }

    void FixedUpdate()
    {
        if (IsServer)
        {
            if (scorePlayer1.Value == 5)
            {
                ballcon.ResetBall(); 
                ShowEndScreen(true);
                ResetScores();
            }
            else if (scorePlayer2.Value == 5)
            {
                ballcon.ResetBall(); 
                ShowEndScreen(false);
                ResetScores();
            }
        }
    }

    private void ShowEndScreen(bool isHostWinner)
    {
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                if (isHostWinner)
                {
                    WinObject1.SetActive(true);
                }
                else
                {
                    WinObject2.SetActive(true);
                }
            }
            else
            {
                if (isHostWinner)
                {
                    WinObject1.SetActive(true);
                }
                else
                {
                    WinObject2.SetActive(true);
                }
            }
        }
    }

    private void ResetScores()
    {
        scorePlayer1.Value = 0;
        scorePlayer2.Value = 0;
        UpdateScoreUI();
    }
}
