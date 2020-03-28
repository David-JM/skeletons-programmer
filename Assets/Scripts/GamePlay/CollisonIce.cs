using UnityEngine;
using System.Collections;
using CommonsGame;

namespace GamePlay
{
	public class CollisonIce : MonoBehaviour 
	{
		public float speed = 8f;

		void OnTriggerStay(Collider other)
		{
			other.attachedRigidbody.velocity = other.transform.forward * speed;
			other.gameObject.GetComponent<PlayerController> ().FijarAnimacionMovimiento (Commons.FALLING_DOWN, false);
		}
	}
}