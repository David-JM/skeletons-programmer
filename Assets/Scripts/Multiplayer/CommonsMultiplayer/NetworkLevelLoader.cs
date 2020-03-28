using UnityEngine;
using System.Collections;

namespace CommonsMultiplayer
{
	public class NetworkLevelLoader : MonoBehaviour 
	{
		// Singleton
		public static NetworkLevelLoader Instance
		{
			get
			{
				if(instance == null)
				{
					GameObject go = new GameObject("_networkLevelLoader");
					// Oculta el objeto del hierarchy en el editor
					go.hideFlags = HideFlags.HideInHierarchy;
					instance = go.AddComponent<NetworkLevelLoader>();
					GameObject.DontDestroyOnLoad(go);
				}
				return instance;
			}
		}
		private static NetworkLevelLoader instance;
		
		public void LoadLevel(int indexLevel, int prefix = 0)
		{
			StopAllCoroutines();
			StartCoroutine (doLoadLevel (indexLevel, prefix));
		}

		// desactiva la cola de red, carga el nivel, espera 2 frames, activa de uevo la cola de red
		IEnumerator doLoadLevel(int index, int prefix)
		{
			Network.SetSendingEnabled (0, false);
			Network.isMessageQueueRunning = false;
			Network.SetLevelPrefix (prefix);
			Application.LoadLevel (index);
			yield return null;
			yield return null;
			
			Network.isMessageQueueRunning = true;
			Network.SetSendingEnabled (0, true);
		}
	}
}