using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcionamento : MonoBehaviour {

    [SerializeField]
    Cartas cartasScript;

    [SerializeField]
    Placar placarScript;


    public void Start()
    {
        cartasScript.EsconderPopUp();
        cartasScript.TabuleiroOn();

        cartasScript.Baralho();

        cartasScript.ContadorBaralhoInicial();

        cartasScript.PegarCarta();
        cartasScript.NaipeTrunfo();

        placarScript.PlacarInicial();

        cartasScript.Comparacao();
        placarScript.AtualizarPlacar();

        cartasScript.ZerarContadorClique();

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !cartasScript.GameOver1)
        {
            cartasScript.PegarCarta();

            cartasScript.Comparacao();

            cartasScript.AtualizaContagemBaralho();
            placarScript.AtualizarPlacar();

            cartasScript.AdicionarClique();       
        }
    }
}
