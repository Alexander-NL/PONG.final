## About
Multi-Pong is a 2D pong game that uses Relay and Netcode Unity package so it can have Multiplayer LAN support (up to 2 players). You can Host lobby or Join other people lobby by inputing a randomized 6 letter code. polished version and easily scaleable for online multiplayer using a server

<tbody>
    <tr>
      <td><img src="https://github.com/Alexander-NL/PONG.final/blob/main/NewPong.gif"/></td>
    </tr>
<br>

## Scripts and Features
scripts:
|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `RelayManager.cs` | for using Relay in Unity to Host and Join Multiplayer with randomized 6 Letters lobby which 2 players can join without manually setting it up using only Netcode|
| `ForcePlayerMove.cs` | to overide Unity netcode default spawn location and spawn players at different place |
| `Test.cs` | to keep track of the score using oncollision2d and addScoreserverRPC |
| `Ballin.cs` | Any function that is related to the ball and its movement like when it adds a score, and ranomized start vector so it doesnt always shoot the same area |
| `etc`  | |

This project also uses these package:
- Universal RP
- Netcode Gameobject
- Relay
  
Post Processing used:
- Bloom
- Vignette

the game has:
1. Pong gameplay
2. Multiplayer support (up to 2 players) by using Relay and Netcode Unity
3. Free copyrighted SFX and BGM already included
4. Multiplayer lobby which can be hosted and joined by using a randomized 6 letter code
5. QOL like ball changing colour for every hit

<br>

## Game controls
The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| A,D           | Standard movement |

<br>

## Notes
this game is developed in **Unity Editor 2022.3.11f1**

ASSET USED:
1. BG: Synth Cities Environment

LINK:
1. https://ansimuz.itch.io/cyberpunk-street-environment

Itch.io:
https://alexnathan.itch.io/pong

BG: Synth Cities Environment
https://ansimuz.itch.io/cyberpunk-street-environment
