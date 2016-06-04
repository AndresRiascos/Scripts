using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.
		public float zoomZ = 0.002f;


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;
        }


        void FixedUpdate ()
        {

			// Mouse wheel moving forwards
			if(Input.GetAxis("Mouse ScrollWheel") > 0)
			{
				Vector3 Zoom = new Vector3 (0, 10,0);//para hacer el zoom pero creo que no sirve
				//target.localScale += Zoom; //con esto escalo solamente el muñeco pero no el ambiente
				Vector3 targetCamPos = target.position + offset ;
				// Smoothly interpolate between the camera's current position and it's target position.
				//Vector3 temp = transform.localPosition;
				//temp.x += 0.1f;
				//temp.y += 10f;
				//temp.z += 0.1f;
				//transform.localPosition = temp;
				Camera.main.fieldOfView = Camera.main.fieldOfView - 5;
				transform.position = Vector3.Lerp (transform.position , targetCamPos , smoothing * Time.deltaTime);
			}

			// Mouse wheel moving backwards
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				Vector3 targetCamPos = target.position + offset;
				// Smoothly interpolate between the camera's current position and it's target position.
				Camera.main.fieldOfView = Camera.main.fieldOfView + 5;
				transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
			} else {
				// Create a postion the camera is aiming for based on the offset from the target.
				Vector3 targetCamPos = target.position + offset;
				// Smoothly interpolate between the camera's current position and it's target position.
				transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
			}
        }
    }
}