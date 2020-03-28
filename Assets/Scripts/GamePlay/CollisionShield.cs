using UnityEngine;
using System.Collections;
using UI;

namespace GamePlay
{
	public class CollisionShield : MonoBehaviour
	{
		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine && !DesafioManager.getInstance ().gameObject.activeSelf) {
				GetComponent<NatureShieldTrick>().ActivarNatureShields(true);
				Invoke("invocarDesafio", 2);
			}
		}

		void invocarDesafio()
		{
			DesafioManager.getInstance ().ActivarDesafio (1);
		}
	}
}