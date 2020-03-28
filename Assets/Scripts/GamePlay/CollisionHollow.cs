using UnityEngine;
using System.Collections;
using CommonsGame;
using UI;

namespace GamePlay
{
	public class CollisionHollow : MonoBehaviour 
	{
		public GameObject fogSkull;

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine)
				other.GetComponent<PlayerController> ().FijarAnimacionMovimiento (Commons.FALLING_DOWN, false);
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.GetComponent<NetworkView> ().isMine && !DesafioManager.getInstance ().gameObject.activeSelf) {
				if(Commons.tagLavaHollow.Equals(tag))
					DesafioManager.getInstance ().ActivarDesafio (2);
				else{
					fogSkull.SetActive(true);
					DesafioManager.getInstance ().ActivarDesafio (4);
				}
				other.GetComponent<PlayerController> ().FijarAnimacionMovimiento (Commons.DEAD, false);
			}
		}
	}
}