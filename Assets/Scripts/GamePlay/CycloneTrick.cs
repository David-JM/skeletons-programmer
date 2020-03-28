using UnityEngine;
using System.Collections;

namespace GamePlay
{
	public class CycloneTrick : MonoBehaviour 
	{
		public GameObject cyclone;

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine)
				Activar (true);
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine)
				Activar (false);
		}

		public void Activar(bool activar)
		{
			cyclone.SetActive (activar);
		}
	}
}