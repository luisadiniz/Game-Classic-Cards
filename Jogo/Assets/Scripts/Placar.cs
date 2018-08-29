using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    [SerializeField]
    private Text placarTextP1;
    [SerializeField]
    private Text placarTextP2;
    [SerializeField]
    private Text placarFinalText;

    private int placar1;
    private int placar2;

    [SerializeField]
    private int score;

    Cartas cartasScript;


    public void PlacarInicial(){
        placar1 = 0;
        placar2 = 0;

        placarTextP1.text = "Placar: " + placar1;
        placarTextP2.text = "Placar: " + placar2;
    }

    public void AdicionaPlacar(PlayerId playerId)
    {
        if (playerId == PlayerId.PLAYER_1)
        {
            placar1 += score;
        }
        else if (playerId == PlayerId.PLAYER_2)
        {
            placar2 += score;
        }

        AtualizarPlacar();

    }

    public void AtualizarPlacar()
    {
        placarTextP1.text = "Placar: " + placar1;
        placarTextP2.text = "Placar: " + placar2;

    }


    public void PlacarFinal(){
        placarFinalText.text = "Placar" + "\n" + "\n" + "Jogador 1: " + placar1 + "\n" + "\n" + "Jogador 2: " + placar2;
    }

    public void LimparTextoPlacar()
    {
        placarTextP1.enabled = false;
        placarTextP2.enabled = false;
    }
}
