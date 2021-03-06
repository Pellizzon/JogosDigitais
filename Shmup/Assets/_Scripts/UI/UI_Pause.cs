using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Restart()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene(0);
    }

    public void Menu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }

}
