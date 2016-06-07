using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // referente a la posicion del jugador.
        PlayerHealth playerHealth;      // referente a la salud del jugador.
        EnemyHealth enemyHealth;        // referente a la salud del enemigo.
        NavMeshAgent nav;               // referente a la malla de navegador.


        void Awake ()
        {
            // configuracion de las referencias
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <NavMeshAgent> ();
        }


        void Update ()
        {
            // si el enemigo y jugador tiene salud mayor a cero...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
<<<<<<< HEAD
                // ... establece el destino del enemigo a traves de la malla hasta el jugador.
				Vector3 pos = new Vector3(0,0,0);
=======
                // ... set the destination of the nav mesh agent to the player.
>>>>>>> origin/master
                nav.SetDestination (player.position);
            }
            // otra manera..
            else
            {
                // ...desactivar malla de navegacion.
                nav.enabled = false;
            }
        }
    }
}