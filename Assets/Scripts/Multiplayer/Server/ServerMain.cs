using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CommonsMultiplayer;
using CommonsGame;
using DataManager;

namespace Multiplayer
{
	public class ServerMain : MonoBehaviour 
	{
		private float playerPosZ = 1;
		private float playerPrefabPositionZ = 149;
		private int puntosExperto = 60;
		private int puntosPrincipiante = 30;
		private SpawnPlayerManager spawnPlayer;

		void Start()
		{
			spawnPlayer = GetComponent<SpawnPlayerManager> ();
			StartCoroutine (TryInitServer ());
		}

		void Update()
		{
			if (Network.peerType == NetworkPeerType.Server)
			{
				if (Network.connections.Length == 0)
					RestartGame();
				else if (Network.connections.Length < 2) 				// OJOOOOOOOO CON ESTE < 1 ES <  2
					StopAllCoroutines ();
				else if (spawnPlayer.getGanadores ().Count == 3) 
				{
					spawnPlayer.SetGameState(false);
					RestartGame();
				}
			}
		}

		IEnumerator TryInitServer()
		{
			yield return new WaitForSeconds (3);
			Network.InitializeServer (Commons.numPlayers, int.Parse (Commons.portHades), !Network.HavePublicAddress ());
			if (Network.peerType == NetworkPeerType.Disconnected) {
				yield return new WaitForSeconds (3);
				Network.InitializeServer (Commons.numPlayers, int.Parse (Commons.portHades), !Network.HavePublicAddress ());
			}		
		}

		public void GuardarGanador (NetworkPlayer netPlayer)
		{
			int puntos = 0;
			switch (spawnPlayer.getPlayers () [netPlayer].Lifes) 
			{
			case 2:
				puntos = 5;
				break;
			case 3:
				puntos = 10;
				break;
			}

			if (Commons.experto.Equals (spawnPlayer.getPlayers () [netPlayer].Nivel))
				puntos += puntosExperto;
			else
				puntos += puntosPrincipiante;

			puntosExperto -= 10;
			puntosPrincipiante -= 10;

			spawnPlayer.AgregarGanador (netPlayer, puntos);
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_user", spawnPlayer.getPlayers () [netPlayer].PlayerName);
			form.AddField ("myform_points", puntos);
			form.AddField ("myform_nivel", spawnPlayer.getPlayers () [netPlayer].Nivel);
			form.AddBinaryData ("binary", new byte[1]);
			StartCoroutine (waitForRequest (new WWW (Commons.urlGuardarPuntos, form)));
		}
		
		IEnumerator waitForRequest(WWW guardarPuntos)
		{
			yield return guardarPuntos;
			if (guardarPuntos.error != null)
				Debug.Log (guardarPuntos.error);
			else if (!Commons.msgTrue.Equals (guardarPuntos.text))
				Debug.Log (guardarPuntos.text);
			guardarPuntos.Dispose ();
		}

		void RestartGame()
		{
			spawnPlayer.getGanadores().Clear();
			spawnPlayer.getPlayers().Clear();
			spawnPlayer.GameOn = false;
			playerPosZ = 1;
			puntosExperto = 60;
			puntosPrincipiante = 30;
		}

		// Funcion que se ejecuta en un servidor cuando es inicializado
		void OnServerInitialized()
		{
			Debug.Log("Servidor up");
		}

		// Funcion que se ejecuta cuando un cliente se ha conectado
		void OnPlayerConnected(NetworkPlayer netPlayer) 
		{
			Debug.Log("New Player conected");
			spawnPlayer.EnviarPlayerPosition (netPlayer, playerPrefabPositionZ+playerPosZ);
			playerPosZ++;
			if (playerPosZ == 16)
				playerPosZ = 1;
			
			if (spawnPlayer.GameOn)
				spawnPlayer.SetGameState (true, netPlayer);
			else if (Network.connections.Length >= 2)                //OJOOOOOO CON EL >= 1 es >= 2
			{
				StopAllCoroutines();
				StartCoroutine (timeCont ());
			}
			StartCoroutine (buscarLogeados (netPlayer));
		}


		IEnumerator buscarLogeados(NetworkPlayer netPlayer)
		{
			Debug.Log ("Entro a buscarLogeados");
			int cont = 0;
			string name = "";
			bool bandera = true;
			while (bandera) {
				yield return new WaitForSeconds (3);
				name = spawnPlayer.getPlayers()[netPlayer].PlayerName;
				if(name.Length > 1){
					bandera = false;
					foreach (KeyValuePair<NetworkPlayer, PlayerInfo> player in spawnPlayer.getPlayers())
						if (player.Value.PlayerName.Equals (name))
							cont++;
					if(cont > 1)
						Network.CloseConnection(netPlayer, false);

				}
			}
		}

		IEnumerator timeCont()
		{
			Debug.Log("Entro al contador de tiempo limite....");
			for (int i = 20; i > 0; i--)
				yield return new WaitForSeconds (1);

			spawnPlayer.SetGameState (true);
			spawnPlayer.GameOn = true;
		}

		// Funcion que se ejecuta en un servidor cuando un cliente se ha desconectado
		void OnPlayerDisconnected(NetworkPlayer netPlayer) 
		{
			Debug.Log ("Player disconected");
			Network.RemoveRPCs (netPlayer);
			Network.DestroyPlayerObjects(netPlayer);
			spawnPlayer.EliminarPlayer (netPlayer);
		}
	}
}