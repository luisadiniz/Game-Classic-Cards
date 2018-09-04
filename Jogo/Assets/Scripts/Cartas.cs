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
    public Sprite fundoBranco;
    [SerializeField]
    public Sprite fundoAzul;

    [SerializeField]
    private Text baralhoText;
    [SerializeField]
    private Text playerVencedor;


    [SerializeField]
    private GameObject fundoBaralho;

    private int contadorClique;

    [SerializeField]
    private GameObject popUpPanel;


    [SerializeField]
    Placar placarScript;
    [SerializeField]
    Funcionamento funcionamentoScript;

    [SerializeField]
    List<Image> fundoCartas;

    [SerializeField]
    List<Sprite> spriteNaipes;

    [SerializeField]
    List<Image> imagemNaipes;


    List<string> naipes = new List<string>
    {"Copas","Ouros","Espadas","Paus"
    };


    List<int> numero = new List<int>
    {
        1,2,3,4,5,6,7,8,9,10,11,12,13
    };


    Dictionary<string, List<Carta>> baralho;

    Dictionary<string, Carta> maoPlayer1;
    Dictionary<string, Carta> maoPlayer2;


    public void CriarBaralho()
    {
        baralho = new Dictionary<string, List<Carta>>();
        for (int i = 0; i < naipes.Count; i++)
        {
            List<Carta> cartas = new List<Carta>();

            for (int j = 0; j < numero.Count; j++)
            {
                Carta novaCarta= new Carta();
                novaCarta.numeroCarta = numero[j];
                novaCarta.naipeCarta = naipes[i];
                cartas.Add(novaCarta);
            }

            baralho.Add(naipes[i], cartas);
        }

    }


    public void DistribuirCartas()
    {
        maoPlayer1 = new Dictionary<string, Carta>();
        maoPlayer2 = new Dictionary<string, Carta>();

        DistribuirMao(maoPlayer1);
        DistribuirMao(maoPlayer2);

        carta1P1.text = maoPlayer1[naipes[0]].numeroCarta.ToString();
        carta1P2.text = maoPlayer2[naipes[0]].numeroCarta.ToString();

        carta2P1.text = maoPlayer1[naipes[1]].numeroCarta.ToString();
        carta2P2.text = maoPlayer2[naipes[1]].numeroCarta.ToString();

        carta3P1.text = maoPlayer1[naipes[2]].numeroCarta.ToString();
        carta3P2.text = maoPlayer2[naipes[2]].numeroCarta.ToString();

        carta4P1.text = maoPlayer1[naipes[3]].numeroCarta.ToString();
        carta4P2.text = maoPlayer2[naipes[3]].numeroCarta.ToString();

    }

    private void DistribuirMao(Dictionary<string, Carta> mao) 
    {
        for (int i = 0; i < naipes.Count; i++)
        {
            int randomIndex = Random.Range(0, baralho[naipes[i]].Count);

            if (mao.ContainsKey(naipes[i]))
            {
                mao[naipes[i]] = baralho[naipes[i]][randomIndex];    
            }
            else
            {
                mao.Add(naipes[i], baralho[naipes[i]][randomIndex]);
            }

            baralho[naipes[i]].Remove(mao[naipes[i]]);
        }
    }


    public void ContadorBaralhoInicial()
    {
        baralhoText.text = "52";
    }


    public void AtualizaContagemBaralho()
    {
        baralhoText.text = NumeroDeCartas().ToString();
    }

    private int NumeroDeCartas(){
        int contadorCartas = 0;
        for (int i = 0; i < naipes.Count; i++)
        {
            contadorCartas += baralho[naipes[i]].Count;
        }
        return contadorCartas;
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

            fundoCartas[0].sprite = fundoBranco;
            fundoCartas[4].sprite = fundoBranco;

            TextoDaCarta(false);

            imagemNaipes[0].enabled = true;
            imagemNaipes[4].enabled = true;

            textosCartas[0].enabled = true;
            textosCartas[4].enabled = true;

            Comparacao("Copas");
        }
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

            fundoCartas[1].sprite = fundoBranco;
            fundoCartas[5].sprite = fundoBranco;

            TextoDaCarta(false);

            imagemNaipes[1].enabled = true;
            imagemNaipes[5].enabled = true;

            textosCartas[1].enabled = true;
            textosCartas[5].enabled = true;

            Comparacao("Ouros");
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

            TextoDaCarta(false);

            fundoCartas[2].sprite = fundoBranco;
            fundoCartas[6].sprite = fundoBranco;

            imagemNaipes[2].enabled = true;
            imagemNaipes[6].enabled = true;

            textosCartas[2].enabled = true;
            textosCartas[6].enabled = true;

            Comparacao("Espadas");
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

            TextoDaCarta(false);

            fundoCartas[3].sprite = fundoBranco;
            fundoCartas[7].sprite = fundoBranco;

            imagemNaipes[3].enabled = true;
            imagemNaipes[7].enabled = true;

            textosCartas[3].enabled = true;
            textosCartas[7].enabled = true;

            Comparacao("Paus");
        }
    }

    public void Comparacao(string naipe)
    {
        if (maoPlayer1[naipe].numeroCarta > maoPlayer2[naipe].numeroCarta)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_1);

            playerVencedor.text = "Player 1 Venceu!";

            funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player1;

            PlayerqueComeca();
        }
        else if (maoPlayer1[naipe].numeroCarta < maoPlayer2[naipe].numeroCarta)
        {
            placarScript.AdicionaPlacar(PlayerId.PLAYER_2);

            playerVencedor.text = "Player 2 Venceu!";

            funcionamentoScript.jogador = Funcionamento.JogadorRodada.Player2;

            PlayerqueComeca();
        }

        if ( NumeroDeCartas() == 4)
        {
            GameOver();
        }

        else
        {
            funcionamentoScript.etapa = Funcionamento.EtapaJogo.Comeco;
        }
    }

    public void PlayerqueComeca()
    {

        for (int i = 0; i < fundoCartas.Count/2; i++)
        {
            fundoCartas[i].GetComponent<Button>().enabled = funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player1;

        }

        for (int i = fundoCartas.Count/2; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].GetComponent<Button>().enabled = funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player2;
        }
        
    }


    public void GameOver()
    {
        funcionamentoScript.etapa = Funcionamento.EtapaJogo.Fim;

        TextoDaCarta(false);

        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].enabled = false;
        }

        baralhoText.enabled = false;
        playerVencedor.enabled = false;


        placarScript.LimparTextoPlacar();

        placarScript.PlacarFinal();

        popUpPanel.SetActive(true);

    }



    public void TrocarFundoDaCarta( Sprite fundo )
    {

        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].sprite = fundo;
        }
    }

    public void TrocarFundoparaOriginal()
    {

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

    public void TextoDaCarta(bool atividade)
    {
        for (int i = 0; i < textosCartas.Count; i++)
        {
            textosCartas[i].enabled = atividade;
        }

        for (int i = 0; i < imagemNaipes.Count; i++)
        {
            imagemNaipes[i].enabled = atividade;
        }
    }


    public void AparecerImagemFundo()
    {
        for (int i = 0; i < fundoCartas.Count; i++)
        {
            fundoCartas[i].enabled = true;
        }
    }


    public void LimparTextoVitoria()
    {
        playerVencedor.text = "";
    }

    public void CartasViradas()
    {
        if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player1)
        {
            for (int i = fundoCartas.Count / 2; i < fundoCartas.Count; i++)
            {
                textosCartas[i].enabled = false;

                fundoCartas[i].sprite = fundoAzul;

                imagemNaipes[i].enabled = false;

            }
        }

        else if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player2)
        {
            for (int i = 0; i < fundoCartas.Count / 2; i++)
            {
                textosCartas[i].enabled = false;

                fundoCartas[i].sprite = fundoAzul;

                imagemNaipes[i].enabled = false;
            }
        }
    }

}