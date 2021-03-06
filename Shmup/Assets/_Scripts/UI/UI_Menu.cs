using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Menu : MonoBehaviour
{
    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Start()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene(0);
    }
}