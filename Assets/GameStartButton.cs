using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public PlayerController playerController;

    public void OnClickStartGame()
    {
        playerController.StartGame();
    }
}
