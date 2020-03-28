using UnityEngine;
using System.Collections;
using CommonsGame;
using UI;

namespace GamePlay
{
	public class CollisionCyclone : MonoBehaviour 
	{
		private bool xDirSumar = false;

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine && !DesafioManager.getInstance ().gameObject.activeSelf) {
				if (other.transform.position.x < 150)
					xDirSumar = true;
				other.gameObject.GetComponent<PlayerController> ().FijarAnimacionMovimiento (Commons.FALLING_DOWN, false);
			}
		}

		void OnTriggerStay(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine) {
				Vector3 posTmp = other.attachedRigidbody.position;
				Vector3 dir = new Vector3 (0, 1, 0);
				dir.z = posTmp.z < 141 ? 1 : 0;
				if (xDirSumar)
					dir.x = posTmp.x < 150 ? 1 : 0;
				else
					dir.x = posTmp.x > 150 ? -1 : 0;
				other.attachedRigidbody.velocity = (dir * 5);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine && !DesafioManager.getInstance ().gameObject.activeSelf)
				DesafioManager.getInstance ().ActivarDesafio (3);
		}
	}
}