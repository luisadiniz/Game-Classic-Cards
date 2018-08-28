﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cartas : MonoBehaviour
{
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

    [SerializeField]
    private Text baralhoText;


    Carta cartaPlayer1;
    Carta cartaPlayer2;

    private string naipeTrunfo;
    [SerializeField]
    private GameObject fundoTrunfo;
    [SerializeField]
    private GameObject fundoPlacar;

    private int contadorClique;

    private bool gameOver;

    [SerializeField]
    private GameObject popUpPanel;


    [SerializeField]
    Placar placarScript;
    Funcionamento funcionamentoScript;


    List<string> naipes = new List<string>
    {"Ouros","Copas","Espadas","Paus"
    };

    [SerializeField]
    private Image imagemCarta1;
    [SerializeField]
    private Image imagemCarta2;
    [SerializeField]
    private Image imagemTrunfo;


    [SerializeField]
    List<Sprite> imagemNaipes;
        

    List<int> numero = new List<int>
    {
        1,2,3,4,5,6,7,8,9,10,11,12,13
    };

    List<Carta> baralho;

    public bool GameOver1
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public void Baralho()
    {
        baralho = new List<Carta>();

        for (int i = 0; i < naipes.Count; i++)
        {
            for (int j = 0; j < numero.Count; j++)
            {
                Carta novaCarta = new Carta();
                novaCarta.naipeCarta = naipes[i];
                novaCarta.numeroCarta = numero[j];

                baralho.Add(novaCarta);
            }
        }
    }


    public void PegarCarta()
    {

        int indexBaralho1 = Random.Range(0, baralho.Count);
        cartaPlayer1 = baralho[indexBaralho1];
        baralho.Remove(cartaPlayer1);


        int indexBaralho2 = Random.Range(0, baralho.Count);
        cartaPlayer2 = baralho[indexBaralho2];
        baralho.Remove(cartaPlayer2);

        if (cartaPlayer1.naipeCarta == naipes[0])
        {
            imagemCarta1.sprite = imagemNaipes[0];
        }
        else if (cartaPlayer1.naipeCarta == naipes[1])
        {
            imagemCarta1.sprite = imagemNaipes[1];
        }
        else if (cartaPlayer1.naipeCarta == naipes[2])
        {
            imagemCarta1.sprite = imagemNaipes[2];
        }
        else if (cartaPlayer1.naipeCarta == naipes[3])
        {
            imagemCarta1.sprite = imagemNaipes[3];
        }

        if (cartaPlayer2.naipeCarta == naipes[0])
        {
            imagemCarta2.sprite = imagemNaipes[0];
        }
        else if (cartaPlayer2.naipeCarta == naipes[1])
        {
            imagemCarta2.sprite = imagemNaipes[1];
        }
        else if (cartaPlayer2.naipeCarta == naipes[2])
        {
            imagemCarta2.sprite = imagemNaipes[2];
        }
        else if (cartaPlayer2.naipeCarta == naipes[3])
        {
            imagemCarta2.sprite = imagemNaipes[3];
        }


        carta1.text = cartaPlayer1.numeroCarta.ToString();
        carta2.text = cartaPlayer2.numeroCarta.ToString();

    }


    public void ContadorBaralhoInicial()
    {
        baralhoText.text = "52";
    }


    public void AtualizaContagemBaralho()
    {
        baralhoText.text = baralho.Count.ToString();
    }


    public void NaipeTrunfo()
    {
        int index = Random.Range(0, naipes.Count);

        naipeTrunfo = naipes[index];
        naipeTrunfoText.text = naipeTrunfo;

        if (naipeTrunfo == naipes[0])
        {
            imagemTrunfo.sprite = imagemNaipes[0];
        }
        else if (naipeTrunfo == naipes[1])
        {
            imagemTrunfo.sprite = imagemNaipes[1];
        }
        else if (naipeTrunfo  == naipes[2])
        {
            imagemTrunfo.sprite = imagemNaipes[2];
        }
        else if (naipeTrunfo == naipes[3])
        {
            imagemTrunfo.sprite = imagemNaipes[3];
        }

    }


    public void Comparacao()
    {

        if (cartaPlayer1.naipeCarta == naipeTrunfo && cartaPlayer2.naipeCarta == naipeTrunfo)
        {
            if (cartaPlayer1.numeroCarta > cartaPlayer2.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
            }

            else if (cartaPlayer1.numeroCarta < cartaPlayer2.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);
            }
        }
        else if (cartaPlayer1.naipeCarta == naipeTrunfo && cartaPlayer2.naipeCarta != naipeTrunfo)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
        }
        else if (cartaPlayer2.naipeCarta == naipeTrunfo && cartaPlayer1.naipeCarta != naipeTrunfo)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_2);
        }

        else if (cartaPlayer1.numeroCarta > cartaPlayer2.numeroCarta)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_1);
        }

        else if (cartaPlayer1.numeroCarta < cartaPlayer2.numeroCarta)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_2);
        }

        if (baralho.Count == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOver1 = true;

        carta1.enabled = false;
        carta2.enabled = false;

        fundocarta1.SetActive(false);
        fundocarta2.SetActive(false);

        naipeTrunfoText.enabled = false;

        fundoTrunfo.SetActive(false);
        fundoPlacar.SetActive(false);

        placarScript.DestruirTextPlacar();

        placarScript.PlacarFinal();

        popUpPanel.SetActive(true);

        // desabilitar naipe do trundo e da carta
        imagemTrunfo.gameObject.SetActive(false);
        imagemCarta1.gameObject.SetActive(false);
        imagemCarta2.gameObject.SetActive(false);


    }



    public void EsconderPopUp()
    {
        popUpPanel.SetActive(false);
    }


    public void ZerarContadorClique()
    {
        contadorClique = 0;
    }

    public void AdicionarClique()
    {
        contadorClique++;
    }

    public void TabuleiroOn()
    {
        carta1.enabled = true;
        carta2.enabled = true;

        fundocarta1.SetActive(true);
        fundocarta2.SetActive(true);

        naipeTrunfoText.enabled = true;

        fundoTrunfo.SetActive(true);

    }
}