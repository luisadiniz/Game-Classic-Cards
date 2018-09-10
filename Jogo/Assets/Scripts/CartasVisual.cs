using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CartasVisual : MonoBehaviour{

    public Text textoDaCarta;
    public Image imagemDoNaipe;
    public Image fundoDaCarta;

    [SerializeField]
    public Sprite fundoBranco;
    [SerializeField]
    public Sprite fundoAzul;

    [SerializeField]
    private Animator virarCartas;


      
    public void VirarFundoCarta(bool virarOuNao)
    {

        if (virarOuNao) 
        { 
            virarCartas.SetBool("Virar", false);
        }

        else 
        { 
            virarCartas.SetBool("Virar", true);
        }

    }

    public void MudarTextoCarta(string textoVisualDaCarta){

        textoDaCarta.text = textoVisualDaCarta; 
    }

    public void PlayAnimation(){
        virarCartas.SetBool("Virar", true);
    }

}
