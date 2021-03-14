using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reutilizado do projeto Breakout
/*
Adaptado de: 
https://www.grimoirehex.com/unity-3d-local-leaderboard/

Referencias extras:
https://www.youtube.com/watch?v=y7RPVvwjrsA&ab_channel=PressStart
*/
public class PlayerInfo
{
    public string name;
    public int score;

    public PlayerInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

public class LeaderBoard : MonoBehaviour
{
    public InputField userName;
    public Text display;

    List<PlayerInfo> collectedStats;

    GameManager gm;

    void Start()
    {
        display.text = "";
        gm = GameManager.GetInstance();
        collectedStats = new List<PlayerInfo>();
        carregaLeaderBoard();
    }

    public void Submit()
    {
        //So enviamos para leaderboard se o input nao estiver vazio
        if (userName.text != "")
        {
            PlayerInfo stats = new PlayerInfo(userName.text, gm.score);

            //adiciona nova informacao a lista de informacoes
            collectedStats.Add(stats);

            //limpa o campo do input
            userName.text = "";

            //faz sort para deixar visivel somente os maiores scores
            ordenaStats();
        }
    }

    void ordenaStats()
    {
        for (int i = collectedStats.Count - 1; i > 0; i--)
        {
            if (collectedStats[i].score > collectedStats[i - 1].score)
            {
                PlayerInfo tempInfo = collectedStats[i - 1];
                collectedStats[i - 1] = collectedStats[i];
                collectedStats[i] = tempInfo;
            }
        }

        //Atualiza PlayerPref que guarda os valores da leaderboard
        atualizaPlayerPrefsString();
    }

    void atualizaPlayerPrefsString()
    {
        string stats = "";

        //Add cada nome e score da lista para a string
        for (int i = 0; i < collectedStats.Count; i++)
        {
            //as virgulas serao usadas para a separacao do nome e pontuacao
            stats += collectedStats[i].name + ",";
            stats += collectedStats[i].score + ",";
        }

        //salva a string
        PlayerPrefs.SetString("Leaderboard_Breakout", stats);

        atualizaLeaderboard();
    }

    void atualizaLeaderboard()
    {
        display.text = "";
        string pos = "";

        for (int i = 0; i <= collectedStats.Count - 1; i++)
        {
            switch (i)
            {
                default:
                    pos = "th ";
                    break;
                case 0: // 1st
                    pos = "st ";
                    break;
                case 1: //2nd
                    pos = "nd ";
                    break;
                case 2: //3rd
                    pos = "rd ";
                    break;

            }
            display.text += (i + 1) + pos + collectedStats[i].name + " : " + collectedStats[i].score + "\n";
        }
    }

    void carregaLeaderBoard()
    {
        //carrega a string que foi salva anteriormente
        string stats = PlayerPrefs.GetString("Leaderboard_Breakout", "");

        //cria uma lista a partir da informacao recebida;
        //como esta salvo assim:
        //<nome1>, <score1>, <nome2>, <score2>, ...
        //separamos todas as virgulas, obtendo uma lista 
        //[<nome1>, <score1>, <nome2>, <score2>, ...] 
        //e iterando sobre ela de maneira adequada
        string[] stats2 = stats.Split(',');

        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i], int.Parse(stats2[i + 1]));
            collectedStats.Add(loadedInfo);
            atualizaLeaderboard();
        }
    }

    public void limpaPlayerPrefs()
    {
        //deleta o que estava salvo
        PlayerPrefs.DeleteKey("Leaderboard_Breakout");

        //limpa display
        display.text = "";

        //corrige um bug de quando limpar, ainda continuava com lixo anterior
        Start();
    }
}