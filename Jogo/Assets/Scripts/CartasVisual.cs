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
      
    public void VirarFundoCarta(bool virarOuNao)
    {

        if (virarOuNao) 
        { 
            fundoDaCarta.sprite = fundoAzul;
            imagemDoNaipe.enabled = false;
            textoDaCarta.enabled = false;
        }

        else 
        { 
            fundoDaCarta.sprite = fundoBranco;
            imagemDoNaipe.enabled = true;
            textoDaCarta.enabled = true;
        }

    }

    public void MudarTextoCarta(string textoVisualDaCarta){

        textoDaCarta.text = textoVisualDaCarta; 
    }


}
