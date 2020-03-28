using UnityEngine;
using System.Collections;
using Multiplayer;
using CommonsGame;

namespace GamePlay
{
	public class SalidaLaberinto : MonoBehaviour 
	{
		private ServerMain serverMain;

		void Start()
		{
			serverMain = GameObject.FindWithTag (Commons.tagMultiplayer).GetComponent<ServerMain> ();
		}

		void OnTriggerEnter(Collider other)
		{
			other.GetComponent<PlayerController> ().enabled = false;
			serverMain.GuardarGanador (other.GetComponent<StatsPlayer> ().getNetPlayer ());
		}
	}
}