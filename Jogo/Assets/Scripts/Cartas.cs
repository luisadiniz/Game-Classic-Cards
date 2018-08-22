using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cartas : MonoBehaviour
{
    private int numeroCarta1;
    private int numeroCarta2;

    private string naipeCarta1;
    private string naipeCarta2;
    [SerializeField]
    private Text naipeTrunfoText;

    [SerializeField]
    private Text carta1;
    [SerializeField]
    private Text carta2;
    [SerializeField]
    private GameObject fundocarta1;
    [SerializeField]
    private GameObject fundocarta2;


    private string naipeTrunfo;
    [SerializeField]
    private GameObject fundoTrunfo;

    private int contadorClique;
    [SerializeField]
    private Text gameOverText;
    private bool gameOver;

    [SerializeField]
    private int maxTurns;

    [SerializeField]
    Placar placarScript;
    Funcionamento funcionamentoScript;


    List<string> naipes = new List<string>
    {"Ouros","Copas","Espadas","Paus"
    };


	public void Carta()
    {
        numeroCarta1 = Random.Range(1, 13);
        numeroCarta2 = Random.Range(1, 13);

        int index = Random.Range(0, naipes.Count);
        int index2 = Random.Range(0, naipes.Count);

        naipeCarta1 = naipes[index];
        naipeCarta2 = naipes[index2];


        carta1.text = numeroCarta1.ToString() + "\n" + naipeCarta1;
        carta2.text = numeroCarta2.ToString() + "\n" + naipeCarta2;
    }

    public void NaipeTrunfo()
    {
        int index = Random.Range(0, naipes.Count);

        naipeTrunfo = naipes[index];

        naipeTrunfoText.text = naipeTrunfo;

    }


    public void Comparacao()
    {

        if (naipeCarta1 == naipeTrunfo && naipeCarta2 == naipeTrunfo)
        {
            if (numeroCarta1 > numeroCarta2)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
                Debug.Log("Player 1 ganhou");
            }

            else if (numeroCarta1 < numeroCarta2)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);
                Debug.Log("Player 1 ganhou");
            }
        }
        else if (naipeCarta1 == naipeTrunfo && naipeCarta2 != naipeTrunfo)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
        }
        else if (naipeCarta2 == naipeTrunfo && naipeCarta1 != naipeTrunfo)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_2);
        }

        else if (numeroCarta1 > numeroCarta2)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
        }

        else if (numeroCarta1 < numeroCarta2)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_2);        
        }

        if(contadorClique == maxTurns){
            GameOver();
        }
        
    }

    public void GameOver(){
        gameOverText.text = "Game Over!";

        Destroy(carta1);
        Destroy(carta2);
        Destroy(fundocarta1);
        Destroy(fundocarta2);
        Destroy(naipeTrunfoText);
        Destroy(fundoTrunfo);

        //placarText.transform.position = new Vector3(410, 200, 0);

    }

    public void LimparGameText(){
        gameOverText.text = "";
        gameOver = false;

    }

    public void ZerarContadorClique()
	{
        contadorClique = 0;
	}

    public void AdicionarClique(){
        contadorClique++;
    }
}