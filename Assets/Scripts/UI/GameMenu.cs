using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using CommonsGame;

namespace UI
{
	public class GameMenu : MonoBehaviour 
	{
		public GameObject pnlSonido;
		public GameObject pnlOptions;
		public AudioMixer music;

		private static GameMenu instance;
		public static GameMenu getInstance()
		{
			return instance;
		}

		void Start()
		{
			instance = this;
			gameObject.SetActive (false);
		}

		public void Activar()
		{
			SoundsManager.getInstance ().Play ();
			gameObject.SetActive (!gameObject.activeSelf);
		}

		public void Sonido()
		{
			SoundsManager.getInstance ().Play ();
			pnlOptions.SetActive (false);
			pnlSonido.SetActive (true);
		}

		public void setMasterVol(float lv)
		{
			music.SetFloat ("masterVol", lv);
		}

		public void Atras()
		{
			SoundsManager.getInstance ().Play ();
			pnlSonido.SetActive (false);
			pnlOptions.SetActive (true);
		}

		public void Salir()
		{
			SoundsManager.getInstance ().Play ();
			CleanScene.Instance.Clean ();
			Network.Disconnect ();
			Application.LoadLevel (Commons.sceneMenu);
		}
	}
}