using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cartas : MonoBehaviour
{
    [SerializeField]
    private int numeroCarta1;
    [SerializeField]
    private int numeroCarta2;

    [SerializeField]
    private string naipeCarta1;
    [SerializeField]
    private string naipeCarta2;

    [SerializeField]
    private Text carta1;
    [SerializeField]
    private Text carta2;
    [SerializeField]
    private Text naipeTrunfoText;
    [SerializeField]
    private Text placarText;

    private int placar1;
    private int placar2;


    private string naipeTrunfo;


    private string cartaJogador1;

    List<string> naipes = new List<string>
    {"Ouros","Copas","Espadas","Paus"
    };


    public void Carta()
    {
        numeroCarta1 = Random.Range(1, 13);
        numeroCarta2 = Random.Range(1, 13);

        int index = Random.Range(0, naipes.Count);
        int index2 = Random.Range(0, naipes.Count);
     
        naipeCarta1 = naipes[index];
        naipeCarta2 = naipes[index2];
       

        carta1.text = numeroCarta1.ToString() + "\n" + naipeCarta1;
        carta2.text = numeroCarta2.ToString() + "\n" + naipeCarta2;
    }

    public void NaipeTrunfo(){
        int index = Random.Range(0, naipes.Count);

        naipeTrunfo = naipes[index];

        naipeTrunfoText.text = naipeTrunfo;


    }

    // Começo do Jogo
    void Start()
    {
        Carta();
        NaipeTrunfo();

        placar1 = 0;
        placar2 = 0;

        Comparacao();
        AtualizarPlacar();

    }

    void Update(){
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("CLIQUEI!!");

            Carta();
            NaipeTrunfo();

            Comparacao();
            AtualizarPlacar();
        }
            
    }
   

    // adiciona o valor no placar do jogador 1
    public void AdicionaPlacar1(int newplacar1Value)
    {
        placar1 += newplacar1Value;
        AtualizarPlacar();
    }

    // adiciona o valor no placar do jogador 2
    public void AdicionaPlacar2(int newplacar2Value)
    {
        placar2 += newplacar2Value;
        AtualizarPlacar();
    }

    public void AtualizarPlacar (){

        placarText.text = "Placar" + "\n" + "Jogador 1: " + placar1 + "\n" + "Jogador 2: " + placar2 ;
    }

    void Comparacao()
    {
        if (numeroCarta1 > numeroCarta2)
        {
            AdicionaPlacar1(10);
        }

        else if (numeroCarta1 < numeroCarta2){
            AdicionaPlacar2(10);
        }
    }
}