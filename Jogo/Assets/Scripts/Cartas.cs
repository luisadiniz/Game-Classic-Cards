using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cartas : MonoBehaviour
{
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
    public List<CartasVisual> cartasVisuais = new List<CartasVisual>();


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

        cartasVisuais[0].MudarTextoCarta(maoPlayer1[naipes[0]].numeroCarta.ToString());
        cartasVisuais[1].MudarTextoCarta(maoPlayer1[naipes[1]].numeroCarta.ToString());
        cartasVisuais[2].MudarTextoCarta(maoPlayer1[naipes[2]].numeroCarta.ToString());
        cartasVisuais[3].MudarTextoCarta(maoPlayer1[naipes[3]].numeroCarta.ToString());

        cartasVisuais[4].MudarTextoCarta(maoPlayer2[naipes[0]].numeroCarta.ToString());
        cartasVisuais[5].MudarTextoCarta(maoPlayer2[naipes[1]].numeroCarta.ToString());
        cartasVisuais[6].MudarTextoCarta(maoPlayer2[naipes[2]].numeroCarta.ToString());
        cartasVisuais[7].MudarTextoCarta(maoPlayer2[naipes[3]].numeroCarta.ToString());


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

    public void EscolhaDasCartas(string naipe)
    {
        if (funcionamentoScript.etapa == Funcionamento.EtapaJogo.Meio)
        {
            CartasViradas(true);

            if (naipe == "Copas")
            {
                cartasVisuais[0].VirarFundoCarta(false);
                cartasVisuais[4].VirarFundoCarta(false);

            }

            if (naipe == "Ouros")
            {
                cartasVisuais[1].VirarFundoCarta(false);
                cartasVisuais[5].VirarFundoCarta(false);
            }

            if (naipe == "Espadas")
            {
               
                cartasVisuais[2].VirarFundoCarta(false);
                cartasVisuais[6].VirarFundoCarta(false);

            }

            if (naipe == "Paus")
            {
                cartasVisuais[3].VirarFundoCarta(false);
                cartasVisuais[7].VirarFundoCarta(false);
            }

            Comparacao(naipe);
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

        for (int i = 0; i < cartasVisuais.Count/2; i++)
        {
            cartasVisuais[i].fundoDaCarta.GetComponent<Button>().enabled = funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player1;
        }

        for (int i = cartasVisuais.Count/2; i < cartasVisuais.Count; i++)
        {
            cartasVisuais[i].fundoDaCarta.GetComponent<Button>().enabled = funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player2;
        }
        
    }


    public void GameOver()
    {
        funcionamentoScript.etapa = Funcionamento.EtapaJogo.Fim;

        for (int i = 0; i < cartasVisuais.Count; i++)
        {
            cartasVisuais[i].gameObject.SetActive(false);
        }

        baralhoText.enabled = false;
        playerVencedor.enabled = false;

        placarScript.LimparTextoPlacar();
        placarScript.PlacarFinal();

        popUpPanel.SetActive(true);

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


    public void LimparTextoVitoria()
    {
        playerVencedor.text = "";
    }

  

    public void CartasViradas(bool virarOuNao)
    {
       for (int i = 0; i < cartasVisuais.Count; i++)
        {
            cartasVisuais[i].VirarFundoCarta(virarOuNao);
        }
    }

    public void AnimarCartas(){
        for (int i = 0; i < cartasVisuais.Count; i++)
        {
            cartasVisuais[i].PlayAnimation();
        }
    }

    public void CartasPlayerRivalViradas()
    {
        if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player2)
        {
            for (int i = 0; i < cartasVisuais.Count / 2; i++)
            {
                cartasVisuais[i].VirarFundoCarta(true);
            }
        }

        if (funcionamentoScript.jogador == Funcionamento.JogadorRodada.Player1)
        {
            for (int i = cartasVisuais.Count / 2; i < cartasVisuais.Count; i++)
            {
                cartasVisuais[i].VirarFundoCarta(true);
            }
        }
    }

       

}