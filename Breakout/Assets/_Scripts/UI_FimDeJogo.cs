using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;
    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.vidas > 0)
        {
            message.text = "Você Ganhou!!!";
        }
        else
        {
            message.text = "Você Perdeu!!";
        }

        string[] stats = PlayerPrefs.GetString("Leaderboard_Breakout").Split(',');

        if (stats.Length > 2 && gm.pontos > int.Parse(stats[1]))
        {
            message.text += "\nNova maior pontuação!";
        }
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}