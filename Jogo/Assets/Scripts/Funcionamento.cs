using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcionamento : MonoBehaviour {

    [SerializeField]
    Cartas cartasScript;

    [SerializeField]
    Placar placarScript;

    private bool cartasViradas;


    public void Start()
    {
        cartasViradas = true;

        cartasScript.EsconderPopUp();
        cartasScript.TabuleiroOn();

        cartasScript.Baralho();

        cartasScript.ContadorBaralhoInicial();

        cartasScript.LimparTextodaCarta();
        cartasScript.LimparTextoVitoria();

        cartasScript.NaipeTrunfo();

        placarScript.PlacarInicial();

        cartasScript.ZerarContadorClique();

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !cartasScript.GameOver1)
        {
            if (cartasViradas)
            {
                cartasScript.TrocarFundodaCarta();
                cartasScript.AparecerTextodaCarta();

                cartasScript.PegarCarta();

                cartasScript.Comparacao();

                cartasScript.AtualizaContagemBaralho();
                placarScript.AtualizarPlacar();

                cartasScript.AdicionarClique();

                CartasViradasFalso();

            }
            else {
                cartasScript.TrocarFundoparaOriginal();
                cartasScript.LimparTextodaCarta();
                cartasScript.LimparTextoVitoria();

                CartasViradasVerdadeiro();
            }
        }
    }

    public void CartasViradasFalso()
    {
        cartasViradas = false;
    }

    public void CartasViradasVerdadeiro()
    {
        cartasViradas = true;
    }
}
