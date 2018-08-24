using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    [SerializeField]
    private Text placarText;
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
        placarText.text = "Placar" + "\n" + "Jogador 1: " + placar1 + "\n" + "Jogador 2: " + placar2;
    }

    public void PlacarFinal(){
        placarFinalText.text = placarText.text;
    }

    public void DestruirTextPlacar(){
        Destroy(placarText);
    }

}
