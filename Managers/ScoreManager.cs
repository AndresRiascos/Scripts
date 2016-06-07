using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // puntuacion del jugador.


        Text text;                      // referencia al componente de texto.


        void Awake ()
        {
            // configuracion de referencias
            text = GetComponent <Text> ();

            // reinciar puntuacion 
            score = 0;
        }


        void Update ()
        {
            // mostrar en panatalla la palbra "score" seguido del la puntuacion.
            text.text = "Score: " + score;
        }
    }
}