using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;

public class RelayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI joinCodeText;
    [SerializeField] private TMP_InputField joinCodeInputField;

    [SerializeField] private GameObject[] WaitingRoom;
    [SerializeField] private GameObject[] Gameplay;

    [SerializeField] private Ballin Ballin;

    private int connectedPlayers = 0;

    private async void Start()
    {
        await InitializeUnityServicesAsync();

        SetActiveObjects(WaitingRoom, true);
        SetActiveObjects(Gameplay, false);
        
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    private async Task InitializeUnityServicesAsync()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void StartRelay()
    {
        string joinCode = await StartHostWithRelay();
        joinCodeText.text = joinCode;
    }

    public async void JoinRelay()
    {
        await StartClientWithRelay(joinCodeInputField.text);

        SetActiveObjects(WaitingRoom, false);
        SetActiveObjects(Gameplay, true);
    }

    private async Task<string> StartHostWithRelay(int maxConnections = 2)
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        return NetworkManager.Singleton.StartHost() ? joinCode : null;
    }

    private async Task<bool> StartClientWithRelay(string joinCode)
    {
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

        return NetworkManager.Singleton.StartClient();
    }

    private void OnClientConnected(ulong clientId)
{
    connectedPlayers++;

    if (connectedPlayers == 2)
    {
        Debug.Log("Both players are connected.");
        SetActiveObjects(WaitingRoom, false);
        SetActiveObjects(Gameplay, true);

        if (NetworkManager.Singleton.LocalClientId == clientId && Ballin != null)
        {
            Ballin.GoBall();
        }
    }
}

    private void SetActiveObjects(GameObject[] objects, bool active)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(active);
        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        }
    }
}
