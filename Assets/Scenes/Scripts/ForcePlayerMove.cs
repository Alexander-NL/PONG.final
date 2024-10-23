using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ForcePlayerMove : NetworkBehaviour
{
    public Vector3 player1SpawnPosition = new Vector3(-7.7f, 0f, -10f);
    public Vector3 player2SpawnPosition = new Vector3(7.7f, 0f, -10f);
    public Color player2Color = Color.red;

    private Renderer playerRenderer;

    private void Start(){
        playerRenderer = GetComponent<Renderer>();
        Debug.Log("Voidstart");

        if (IsLocalPlayer)
        {
            Debug.Log("IslocalPlayer");
            SetPlayerPosition();
        }
    }

    private void SetPlayerPosition()
    {
        if (IsServer)
        {
            Debug.Log("insideSetplayerPositionFunction");
            transform.position = player1SpawnPosition;
        }
        else
        {
            transform.position = player2SpawnPosition;
            ChangePlayer2Color();
        }
    }

    private void ChangePlayer2Color(){
        if (playerRenderer != null){
            playerRenderer.material.color = player2Color;
        }
    }

    public override void OnNetworkSpawn(){
        base.OnNetworkSpawn();

        if (IsLocalPlayer){
            SetPlayerPosition();
        }
    }
}
