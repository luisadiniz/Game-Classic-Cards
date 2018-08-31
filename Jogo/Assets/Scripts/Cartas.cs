using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cartas : MonoBehaviour
{
    [SerializeField]
    private Text carta1P1;
    [SerializeField]
    private Text carta1P2;
    [SerializeField]
    private Text carta2P1;
    [SerializeField]
    private Text carta2P2;
    [SerializeField]
    private Text carta3P1;
    [SerializeField]
    private Text carta3P2;
    [SerializeField]
    private Text carta4P1;
    [SerializeField]
    private Text carta4P2;

    [SerializeField]
    List<Text> textosCartas;

    [SerializeField]
    private Sprite fundoBranco;
    [SerializeField]
    private Sprite fundoAzul;

    [SerializeField]
    private Text baralhoText;
    [SerializeField]
    private Text playerVencedor;


    Carta cartaPlayer1;
    Carta cartaPlayer2;

    Carta cartaP1Copas;
    Carta cartaP2Copas;

    Carta cartaP1Ouros;
    Carta cartaP2Ouros;

    Carta cartaP1Espadas;
    Carta cartaP2Espadas;

    Carta cartaP1Paus;
    Carta cartaP2Paus;


    [SerializeField]
    private GameObject fundoBaralho;

    private int contadorClique;

    [SerializeField]
    private GameObject popUpPanel;


    [SerializeField]
    Placar placarScript;
    [SerializeField]
    Funcionamento funcionamentoScript;


    List<string> naipes = new List<string>
    {"Ouros","Copas","Espadas","Paus"
    };

   
    [SerializeField]
    List<Image> fundoCartas;

    [SerializeField]
    List<Sprite> spriteNaipes;

    [SerializeField]
    List<Image> imagemNaipes;
        

    List<int> numero = new List<int>
    {
        1,2,3,4,5,6,7,8,9,10,11,12,13
    };

    List<Carta> ouros;
    List<Carta> copas;
    List<Carta> espadas;
    List<Carta> paus;

   
    public void Baralho()
    {
        ouros = new List<Carta>();
        for (int i = 0; i < numero.Count; i++)
        {
            Carta novaCartaOuros = new Carta();
            novaCartaOuros.naipeCarta = naipes[0];
            novaCartaOuros.numeroCarta = numero[i];

            ouros.Add(novaCartaOuros);
        }

        copas = new List<Carta>();
        for (int i = 0; i < numero.Count; i++)
        {
            Carta novaCartaCopas = new Carta();
            novaCartaCopas.naipeCarta = naipes[1];
            novaCartaCopas.numeroCarta = numero[i];

            copas.Add(novaCartaCopas);
        }

        espadas = new List<Carta>();
        for (int i = 0; i < numero.Count; i++)
        {
            Carta novaCartaEspadas = new Carta();
            novaCartaEspadas.naipeCarta = naipes[2];
            novaCartaEspadas.numeroCarta = numero[i];

            espadas.Add(novaCartaEspadas);
        }

        paus = new List<Carta>();
        for (int i = 0; i < numero.Count; i++)
        {
            Carta novaCartaPaus = new Carta();
            novaCartaPaus.naipeCarta = naipes[3];
            novaCartaPaus.numeroCarta = numero[i];

            paus.Add(novaCartaPaus);
        }

    }


    public void PegarCarta()
    {
        int indexCopas1 = Random.Range(0, copas.Count);
        cartaP1Copas = copas[indexCopas1];
        copas.Remove(cartaP1Copas);
        int indexCopas2 = Random.Range(0, copas.Count);
        cartaP2Copas = copas[indexCopas2];
        copas.Remove(cartaP2Copas);

        int indexOuros1 = Random.Range(0, ouros.Count);
        cartaP1Ouros = ouros[indexOuros1];
        ouros.Remove(cartaP1Ouros);
        int indexOuros2 = Random.Range(0, ouros.Count);
        cartaP2Ouros = ouros[indexOuros2];
        ouros.Remove(cartaP2Ouros);

        int indexEspadas1 = Random.Range(0, espadas.Count);
        cartaP1Espadas = espadas[indexEspadas1];
        espadas.Remove(cartaP1Espadas);
        int indexEspadas2 = Random.Range(0, espadas.Count);
        cartaP2Espadas = espadas[indexEspadas2];
        espadas.Remove(cartaP2Espadas);

        int indexPaus1 = Random.Range(0, paus.Count);
        cartaP1Paus = paus[indexPaus1];
        paus.Remove(cartaP1Paus);
        int indexPaus2 = Random.Range(0, paus.Count);
        cartaP2Paus = paus[indexPaus2];
        paus.Remove(cartaP2Paus);

       
        carta1P1.text = cartaP1Copas.numeroCarta.ToString();
        carta1P2.text = cartaP2Copas.numeroCarta.ToString();

        carta2P1.text = cartaP1Ouros.numeroCarta.ToString();
        carta2P2.text = cartaP2Ouros.numeroCarta.ToString();

        carta3P1.text = cartaP1Espadas.numeroCarta.ToString();
        carta3P2.text = cartaP2Espadas.numeroCarta.ToString();

        carta4P1.text = cartaP1Paus.numeroCarta.ToString();
        carta4P2.text = cartaP2Paus.numeroCarta.ToString();

    }


    public void ContadorBaralhoInicial()
    {
        baralhoText.text = "52";
    }


    public void AtualizaContagemBaralho()
    {
        baralhoText.text = (copas.Count + espadas.Count + ouros.Count + paus.Count).ToString();
    }


    public void EscolhaOuros()
    {
        if (funcionamentoScript.etapa == Funcionamento.EtapaJogo.Meio)
        {
            fundoCartas[0].sprite = fundoAzul;
            fundoCartas[2].sprite = fundoAzul;
            fundoCartas[3].sprite = fundoAzul;

            fundoCartas[4].sprite = fundoAzul;
            fundoCartas[6].sprite = fundoAzul;
            fundoCartas[7].sprite = fundoAzul;

            if (cartaP1Ouros.numeroCarta > cartaP2Ouros.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);

                playerVencedor.text = "Player 1 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player1;

                PlayerqueComeca();
            }
            else if (cartaP1Ouros.numeroCarta < cartaP2Ouros.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);

                playerVencedor.text = "Player 2 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player2;

                PlayerqueComeca();
            }
            if ((copas.Count + espadas.Count + ouros.Count + paus.Count) == 4)
            {
                GameOver();
            }

            else { funcionamentoScript.etapa = Funcionamento.EtapaJogo.Comeco; }

        }

    }


    public void EscolhaCopas()
    {
        if (funcionamentoScript.etapa == Funcionamento.EtapaJogo.Meio)
        {
            fundoCartas[1].sprite = fundoAzul;
            fundoCartas[2].sprite = fundoAzul;
            fundoCartas[3].sprite = fundoAzul;

            fundoCartas[5].sprite = fundoAzul;
            fundoCartas[6].sprite = fundoAzul;
            fundoCartas[7].sprite = fundoAzul;

            if (cartaP1Copas.numeroCarta > cartaP2Copas.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);

                playerVencedor.text = "Player 1 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player1;

                PlayerqueComeca();
            }
            else if (cartaP1Copas.numeroCarta < cartaP2Copas.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);

                playerVencedor.text = "Player 2 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player2;

                PlayerqueComeca();
            }
            if ((copas.Count + espadas.Count + ouros.Count + paus.Count) == 4)
            {
                GameOver();
            }

            else { funcionamentoScript.etapa = Funcionamento.EtapaJogo.Comeco; }

        }
    }

    public void EscolhaEspadas()
    {
        if (funcionamentoScript.etapa == Funcionamento.EtapaJogo.Meio)
        {
            fundoCartas[0].sprite = fundoAzul;
            fundoCartas[1].sprite = fundoAzul;
            fundoCartas[3].sprite = fundoAzul;

            fundoCartas[4].sprite = fundoAzul;
            fundoCartas[5].sprite = fundoAzul;
            fundoCartas[7].sprite = fundoAzul;

            if (cartaP1Espadas.numeroCarta > cartaP2Espadas.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);

                playerVencedor.text = "Player 1 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player1;

                PlayerqueComeca();
            }
            else if (cartaP1Espadas.numeroCarta < cartaP2Espadas.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);

                playerVencedor.text = "Player 2 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player2;

                PlayerqueComeca();
            }
            if ((copas.Count + espadas.Count + ouros.Count + paus.Count) == 4)
            {
                GameOver();
            }

            else { funcionamentoScript.etapa = Funcionamento.EtapaJogo.Comeco; }

        }

    }

    public void EscolhaPaus()
    {
        if (funcionamentoScript.etapa == Funcionamento.EtapaJogo.Meio)
        {
            fundoCartas[1].sprite = fundoAzul;
            fundoCartas[2].sprite = fundoAzul;
            fundoCartas[0].sprite = fundoAzul;

            fundoCartas[5].sprite = fundoAzul;
            fundoCartas[6].sprite = fundoAzul;
            fundoCartas[4].sprite = fundoAzul;

            if (cartaP1Paus.numeroCarta > cartaP2Paus.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_1);

                playerVencedor.text = "Player 1 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player1;

                PlayerqueComeca();
            }
            else if (cartaP1Paus.numeroCarta < cartaP2Paus.numeroCarta)
            {
                placarScript.AdicionaPlacar(PlayerId.PLAYER_2);

                playerVencedor.text = "Player 2 Venceu!";

                funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player2;

                PlayerqueComeca();
            }

            if ((copas.Count + espadas.Count + ouros.Count + paus.Count) == 4)
            {
                GameOver();
            }

            else { funcionamentoScript.etapa = Funcionamento.EtapaJogo.Comeco; }

        }
    }

    public void PlayerqueComeca()
    {
        if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player1)
        {
            fundoCartas[4].GetComponent<Button>().enabled = false;
            fundoCartas[5].GetComponent<Button>().enabled = false;
            fundoCartas[6].GetComponent<Button>().enabled = false;
            fundoCartas[7].GetComponent<Button>().enabled = false;
        }
       
        else if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player2)
            {
                fundoCartas[0].GetComponent<Button>().enabled = false;
                fundoCartas[1].GetComponent<Button>().enabled = false;
                fundoCartas[2].GetComponent<Button>().enabled = false;
                fundoCartas[3].GetComponent<Button>().enabled = false;
            }
        }


    public void GameOver()
    {
        funcionamentoScript.etapa = Funcionamento.EtapaJogo.Fim;

        LimparTextodaCarta();

        for (int i = 0; i < fundoCartas.Capacity; i++)
        {
            fundoCartas[i].enabled = false;
        }

        baralhoText.enabled = false;
        playerVencedor.enabled = false;


        placarScript.LimparTextoPlacar();

        placarScript.PlacarFinal();

        popUpPanel.SetActive(true);

    }


    public void TrocarFundodaCarta(){

        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].sprite = fundoBranco;
        }
    }

    public void TrocarFundoparaOriginal(){

        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].sprite = fundoAzul;
        }
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

    public void LimparTextodaCarta()
    {
        for (int i = 0; i < textosCartas.Count; i++)
        {
            textosCartas[i].enabled = false;
        }

        for(int i = 0; i < imagemNaipes.Count; i++)
        {
            imagemNaipes[i].enabled = false;
        }
    }

    public void AparecerTextodaCarta(){

        for (int i = 0; i < textosCartas.Count; i++)
        {
            textosCartas[i].enabled = true;
        }

        for (int i = 0; i < imagemNaipes.Count; i++)
        {
            imagemNaipes[i].enabled = true;
        }

    }

    public void AparecerImagemFundo(){
        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].enabled = true;
        }
    }


    public void LimparTextoVitoria()
    {
        playerVencedor.text = "";
    }



}