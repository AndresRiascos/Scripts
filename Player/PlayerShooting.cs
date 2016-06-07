using UnityEngine;
using UnityEngine;

namespace CompleteProject
{
	public class PlayerShooting : MonoBehaviour
	{
<<<<<<< HEAD
		public int damagePerShot = 20;                  // el daño inflingido por cada bala.
		public float timeBetweenBullets = 0.15f;        // tiempo entre cada disparo.
		public float range = 100f;                      // la distancia del disparo.


		float timer;                                    // temporizador para indicar cuando disparar.
		Ray shootRay;                                   // arreglo para la municion.
		RaycastHit shootHit;                            // arreglo para los golpes que da la bala
		int shootableMask;                              // una mascara para determinar cuando hace dano.
		ParticleSystem gunParticles;                    // referente a las particulas del sistema.
		LineRenderer gunLine;                           // referente a la trayectoria de la bala.
		AudioSource gunAudio;                           // referente al sonido del disparo.
		Light gunLight;                                 // referente a la luz del disparo.
		public Light faceLight;								
		float effectsDisplayTime = 0.2f;                // efectos entre disparos
		public int lengthOfLineRenderer = 20;           // es el numero de lineas que va a tener la onda
=======
		public int damagePerShot = 100;                  // The damage inflicted by each bullet.
		public float timeBetweenBullets = 0.15f;        // el tiempo entre cada disparo
		public float range = 100f;                      // The distance the gun can fire.


		float timer;                                    // A timer to determine when to fire.
		Ray shootRay;                                   // A ray from the gun end forwards.
		RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
		int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
		ParticleSystem gunParticles;                    // Reference to the particle system.
		LineRenderer gunLine;                           // Reference to the line renderer.
		LineRenderer gunLineCenter;
		AudioSource gunAudio;                           // Reference to the audio source.
		Light gunLight;                                 // Reference to the light component.
		public Light faceLight;								// Duh
		float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
		public int lengthOfLineRenderer = 20;// agregueeeee, es el número de lineas que va a tener la onda, si se quiere mas bonita, hay que colocarle mas 
>>>>>>> origin/master


		void Awake ()
		{
			// mascara para el disparo.
			shootableMask = LayerMask.GetMask ("Shootable");

			// configuracion de las referencias
			gunParticles = GetComponent<ParticleSystem> ();
			gunLine = GetComponent <LineRenderer> ();
			gunLineCenter = GetComponent <LineRenderer> ();
			gunAudio = GetComponent<AudioSource> ();
			gunLight = GetComponent<Light> ();
			gunLine.SetVertexCount (lengthOfLineRenderer);  // asigne el numero de vertices que va a tener la linea
			//faceLight = GetComponentInChildren<Light> ();
		}


		void Update ()
		{
			// tiempo.
			timer += Time.deltaTime;

			#if !MOBILE_INPUT
			// si el boton de disparo esta presionado y el tiempo entre disparos es distito de cero.
			if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
			{
				// ... dispare
				Shoot ();
			}
			#else

			if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
			{
			// ..
			Shoot();
			}
			#endif
			// si el tiempo se ha excedido..
			if(timer >= timeBetweenBullets * effectsDisplayTime)
			{
				// ...desactivar efectos de sonido del disparo.
				DisableEffects ();
			}
		}


		public void DisableEffects ()
		{
			//desactivar la linea de disparo y luz.
			gunLine.enabled = false;
			faceLight.enabled = false;
			gunLight.enabled = false;
			gunLineCenter.enabled = false;

		}


		void Shoot ()
		{
			// reiniciar tiempo
			timer = 0f;

			// reproducir sonido del arma.
			gunAudio.Play ();

			// activar luz
			gunLight.enabled = true;
			faceLight.enabled = true;

			// detener las particulas
			gunParticles.Stop ();
			gunParticles.Play ();

			// activar la linea de la bala
			gunLine.enabled = true;
			gunLineCenter.enabled = true;
			//gunLineCenter.SetPosition(0, transform.position);
			//gunLine.SetPosition (0, transform.position);////////// comente esto, para agregarlo en la funcion abajo, esto da el inicio de la trayectoria, quien lo iba a pensar, jeje 

			// ajustar el arreglo de disparo que inicia en el extremo de la pistola en direccion hacia adelante 
			shootRay.origin = transform.position;
			shootRay.direction = transform.forward;

			// ejecute el Raycast si golpea un objeto dentro del rango...
			if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
			{
				// si golpea a un enemigo ir al componente de salud del enemigo
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

<<<<<<< HEAD
				// si el enemigo tiene salud...
=======
				//PARA GENERAR DAÑO ALEATORIO
				// lo pongo en ese rango para poder que sea positvo el numero de la funcion coseno
				float funcionCos = Mathf.Cos (Random.Range(-Mathf.PI/2, Mathf.PI/2));             
				int danoF = (int)(funcionCos * 100); 
				if (danoF <= 30) {
					damagePerShot = danoF;//se asigna el valor al la variable daño
				} else {
					damagePerShot = 30;
				}
				//fin

				// If the EnemyHealth component exist...
>>>>>>> origin/master
				if(enemyHealth != null)
				{
					// ... herir al enemigo
					enemyHealth.TakeDamage (damagePerShot, shootHit.point);
				}

<<<<<<< HEAD

=======
				// Set the second position of the line renderer to the point the raycast hit.			
				Vector3 dir = (shootHit.point-transform.position).normalized;
>>>>>>> origin/master
				Vector3[] points = new Vector3[lengthOfLineRenderer];// se crea un arreglo de vectores de 3 dimensiones, donde se guardara cada vertice de la linea
				float t = Time.time;
				float tamanoDivisiones = (shootHit.point - transform.position).magnitude/lengthOfLineRenderer;
				int i = 1;
				points [0] = transform.position;
				while (i < lengthOfLineRenderer) {
					points[i] = new Vector3((i*tamanoDivisiones*dir.x)+transform.position.x,shootHit.point.y,(Mathf.Sin(i + t))+(i*tamanoDivisiones*dir.z)+transform.position.z);
					i++;
				}
				//gunLineCenter.SetPosition(1, shootHit.point);
				gunLine.SetPositions(points);// crea una linea por todos los vertices guardados en el arreglo 
			}
			// si no se ha golpeado nada...
			else
			{
				// ... posicionar en la siguiente direccion de la pistola
				gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			}
		}
	}
}