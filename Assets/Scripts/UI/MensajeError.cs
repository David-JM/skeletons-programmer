using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CommonsGame;

namespace UI
{
	public class MensajeError : MonoBehaviour 
	{
		private bool goMenu = false;

		private static MensajeError instance;
		public static MensajeError getInstance()
		{
			return instance;
		}
		
		void Start()
		{
			instance = this;
			gameObject.SetActive (false);
		}

		public void LanzarMensaje(string msg, bool goMenu)
		{
			this.goMenu = goMenu;
			gameObject.SetActive (true);
			GetComponentInChildren<Text> ().text = msg;
		}
		
		public void OnClickOk()
		{
			gameObject.SetActive (false);
			if (goMenu) {
				CleanScene.Instance.Clean();
				Application.LoadLevel (Commons.sceneMenu);
			}
		}
	}
}