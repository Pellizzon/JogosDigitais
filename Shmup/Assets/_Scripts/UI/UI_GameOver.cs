using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_GameOver : MonoBehaviour
{
    public Text message;
    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        message.text = "Game Over!";
    }
    public void Back()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene(0);
    }
}