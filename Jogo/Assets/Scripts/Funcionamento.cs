using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcionamento : MonoBehaviour {

    [SerializeField]
    Cartas cartasScript;

    [SerializeField]
    Placar placarScript;

    public enum EtapaJogo { Comeco, Meio, Fim };
    public EtapaJogo etapa;

    public enum JogadorRodada {Player1, Player2}
    public JogadorRodada jogador;


    public void Start()
    {
        etapa = EtapaJogo.Comeco;

        cartasScript.EsconderPopUp();
        cartasScript.CriarBaralho();

        cartasScript.ContadorBaralhoInicial();

        cartasScript.AparecerImagemFundo();
        cartasScript.TextoDaCarta(false);

        cartasScript.LimparTextoVitoria();
        placarScript.PlacarInicial();

        cartasScript.ZerarContadorClique();

    }



    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && etapa == EtapaJogo.Comeco)
        {
            cartasScript.TrocarFundoDaCarta(cartasScript.fundoBranco);
            cartasScript.TextoDaCarta(true);

            cartasScript.DistribuirCartas();

            cartasScript.AtualizaContagemBaralho();
            placarScript.AtualizarPlacar();

            cartasScript.AdicionarClique();

            cartasScript.CartasViradas();

            etapa = EtapaJogo.Meio;

        }
    }
}
