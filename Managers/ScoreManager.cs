﻿using UnityEngine;
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
<<<<<<< HEAD
            // mostrar en panatalla la palbra "score" seguido del la puntuacion.
=======
			if (score>=50&& (Application.loadedLevelName!="level2")) {
				Application.LoadLevel (1);
			}
            // Set the displayed text to be the word "Score" followed by the score value.
>>>>>>> origin/master
            text.text = "Score: " + score;
        }
    }
}