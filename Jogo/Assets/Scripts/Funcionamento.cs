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
        cartasScript.LimparGameText();
        cartasScript.Carta();
        cartasScript.NaipeTrunfo();

        placarScript.PlacarInicial();

        cartasScript.Comparacao();
        placarScript.AtualizarPlacar();

        cartasScript.ZerarContadorClique();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cartasScript.Carta();

            cartasScript.Comparacao();
            placarScript.AtualizarPlacar();

            cartasScript.AdicionarClique();       
        }
    }
}
