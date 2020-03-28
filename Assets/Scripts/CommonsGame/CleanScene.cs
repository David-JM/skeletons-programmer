using UnityEngine;
using System.Collections;
using CommonsGame;
using CommonsMultiplayer;
using UI;

namespace CommonsGame
{
	public class CleanScene : MonoBehaviour 
	{
		// Singleton
		public static CleanScene Instance
		{
			get
			{
				if(instance == null)
				{
					GameObject go = new GameObject("_cleanScene");
					// Oculta el objeto del hierarchy en el editor
					go.hideFlags = HideFlags.HideInHierarchy;
					instance = go.AddComponent<CleanScene>();
					GameObject.DontDestroyOnLoad(go);
				}
				return instance;
			}
		}
		private static CleanScene instance;

		public void Clean()
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Commons.tagPlayer);
			foreach (GameObject target in gameObjects) {
				Destroy(target);
			}
			Destroy (SoundsManager.getInstance ().gameObject);
			Destroy (GameObject.FindWithTag (Commons.tagMultiplayer));
			Destroy (MensajeError.getInstance ().GetComponentInParent<Transform> ().gameObject);
			Destroy (gameObject);
		}
	}
}