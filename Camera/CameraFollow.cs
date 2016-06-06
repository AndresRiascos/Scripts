﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.
		public int zoomMaxPerspective= 60;
		public int zoomMinPerspective = 15;
		public int zoomMaxOrthographic= 15;
		public int zoomMinOrthographic = 5;
		//PARA EL CAMBIO DE CAMARA
		public bool orthoOn = false;
		public Camera MainCamera;
		public Camera Camera2;
		public GameObject CamPerspective;
		public GameObject CamOrthographic;
		//FIN CAMBIO CAMARA
        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;
			//CAMARA
			CamPerspective = GameObject.Find("MainCamera");
			MainCamera = CamPerspective.GetComponent<Camera>();
			MainCamera.enabled = true;
			CamOrthographic = GameObject.Find ("Camera2");
			Camera2 = CamOrthographic.GetComponent<Camera>();
			Camera2.enabled = false;		
			//
        }


        void FixedUpdate ()
        {
			if ( Input.GetKeyDown(KeyCode.E) ){
				orthoOn = !orthoOn;
				if (orthoOn) {
					MainCamera.enabled = false;
					Camera2.enabled = true;				
				} else {
					MainCamera.enabled = true;
					Camera2.enabled = false;
				}
			}if (( Input.GetKeyDown(KeyCode.KeypadPlus)) && (MainCamera.enabled == true)){
				Debug.Log ("Angulo: " + MainCamera.transform.localEulerAngles.x);
				Debug.Log ("Posición que debería tomar: " + MainCamera.transform.localPosition);
				int comparar = (int)MainCamera.transform.localEulerAngles.x;
				if(comparar == 30){
					var rotation = Quaternion.Euler(45, 0, 0);
					Vector3 temp = MainCamera.transform.position;
					temp.z = -14f;
					MainCamera.transform.position = temp;
					MainCamera.transform.rotation = rotation;
				}if(comparar == 45){
					var rotation = Quaternion.Euler(60, 0, 0);
					MainCamera.transform.rotation = rotation;
				}if(comparar == 60){
					var rotation = Quaternion.Euler(75, 0, 0);
					Vector3 targetCamPos = target.position + offset;
					Vector3 temp = transform.position;
					temp.z = -8f;
					transform.position = temp;
					// Smoothly interpolate between the camera's current position and it's target position.
					transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);				
					MainCamera.transform.rotation = rotation;
				}if (comparar == 74) {
					var rotation = Quaternion.Euler (90, 0, 0);
					MainCamera.transform.rotation = rotation;
				}if (comparar == 90) {
					MainCamera.transform.rotation = MainCamera.transform.rotation;
				}

				//Debug.Log (MainCamera.transform.localRotation);
			}
			// Mouse wheel moving forwards
			if((Input.GetAxis("Mouse ScrollWheel") > 0) && (MainCamera.fieldOfView > zoomMinPerspective) && (MainCamera.enabled == true)){
				MainCamera.fieldOfView = MainCamera.fieldOfView - 5;
			}
			// Mouse wheel moving backwards
			if((Input.GetAxis ("Mouse ScrollWheel") < 0) && (MainCamera.fieldOfView < zoomMaxPerspective) && (MainCamera.enabled == true)) {
				MainCamera.fieldOfView = MainCamera.fieldOfView + 5;
			}
			if((Input.GetAxis("Mouse ScrollWheel") > 0) && (Camera2.orthographicSize > zoomMinOrthographic) && (Camera2.enabled == true)){
				Camera2.orthographicSize = Camera2.orthographicSize - 1;
			}
			// Mouse wheel moving backwards
			if((Input.GetAxis ("Mouse ScrollWheel") < 0) && (Camera2.orthographicSize < zoomMaxOrthographic) && (Camera2.enabled == true)) {
				Camera2.orthographicSize = Camera2.orthographicSize + 1;
			}else{
				// Create a postion the camera is aiming for based on the offset from the target.
				Vector3 targetCamPos = target.position + offset;
				// Smoothly interpolate between the camera's current position and it's target position.
				transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
			}
        }
			


    }
}