using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{
	public class LobbyManager : MonoBehaviour 
	{
		private static LobbyManager instance;
		public static LobbyManager getInstance()
		{
			return instance;
		}
		
		void Start()
		{
			instance = this;
		}

		public void Activar(string texto)
		{
			GetComponentInChildren<Text> ().text = texto;
		}

		public void Desactivar()
		{
			gameObject.SetActive (false);
		}
	}
}