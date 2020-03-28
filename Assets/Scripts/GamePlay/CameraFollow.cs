using UnityEngine;
using System.Collections;
using CommonsGame;

namespace GamePlay
{
	public class CameraFollow : MonoBehaviour
	{
		public float damping = 2;				// Valor de amortiguacion para el seguimiento de la camara
		private Vector3 offset;					// Vector para el Desplazamiento de la camara
		private Transform target;   			// Componente de posicion del personaje que la camara va a seguir

		public void StartCamera(Transform target) 
		{
			this.target = target;
			Vector3 tmp = transform.position;
			tmp.z = target.position.z - 2;
			transform.position = tmp;
			offset = target.transform.position - transform.position;
		}

		void LateUpdate ()
		{
			float currentAngle = transform.eulerAngles.y;
			float desiredAngle = target.transform.eulerAngles.y;
			float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
			Quaternion rotation = Quaternion.Euler(0, angle, 0);
			transform.position = target.transform.position - (rotation * offset);
			transform.LookAt(target.transform);
		}
	}
}