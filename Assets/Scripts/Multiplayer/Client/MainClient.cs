using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CommonsGame;
using DataManager;
using CommonsMultiplayer;
using UI;

namespace Multiplayer
{
	public class MainClient : MonoBehaviour
	{
		public Character character;
		private SpawnPlayerManager spawnPlayer;

		void Start()
		{
			spawnPlayer = GetComponent<SpawnPlayerManager> ();
		}

		void Update()
		{
			if (spawnPlayer.getPlayerPosition () > 0 && Application.loadedLevel == Commons.sceneMenu)
				NetworkLevelLoader.Instance.LoadLevel (Commons.sceneIceMap);
		}

		public void JoinServer(Commons.Server serverSelected)
		{
			Loading.getInstance ().Activar ();
			if (serverSelected == Commons.Server.Shadow)
				Network.Connect (Commons.ipServer, int.Parse (Commons.portShadow));
			else if (serverSelected == Commons.Server.Hades)
				Network.Connect (Commons.ipServer, int.Parse (Commons.portHades));
		}

		public GameObject InstanciarPersonaje()
		{
			GameObject pj;
			switch(PlayerInfoManager.Instance.getPlayer().Prefab)
			{
			case 0:
				pj = character.warlord;
				PlayerInfoManager.Instance.getPlayer().IconPlayer = character.iconWarlord;
				break;
			case 1:
				pj = character.sorcerer;
				PlayerInfoManager.Instance.getPlayer().IconPlayer = character.iconSorcerer;
				break;
			case 2:
				pj = character.footman;
				PlayerInfoManager.Instance.getPlayer().IconPlayer = character.iconFootman;
				break;
			case 3:
				pj = character.archer;
				PlayerInfoManager.Instance.getPlayer().IconPlayer = character.iconArcher;
				break;
			default:
				pj = character.warlord;
				PlayerInfoManager.Instance.getPlayer().IconPlayer = character.iconWarlord;
				break;
			}
			Vector3 tmp = pj.transform.position;
			tmp.z = spawnPlayer.getPlayerPosition ();
			pj.transform.position = tmp;
			GameObject player = Network.Instantiate (pj, pj.transform.position, pj.transform.rotation, 0) as GameObject;
			player.GetComponentInChildren<Light> ().color = PlayerInfoManager.Instance.getPlayer ().LightColor;
			return player;
		}

		void OnConnectedToServer()
		{
			Loading.getInstance ().Desactivar ();
			spawnPlayer.AgregarPlayer (Network.player, PlayerInfoManager.Instance.getPlayer ());
		}

		// Funcion que se ejecuta en un cliente cuando no puede conectarse a un server
		void OnFailedToConnect(NetworkConnectionError error)
		{
			Loading.getInstance ().Desactivar ();
			MenuManager.getInstance ().gameObject.SetActive (true);
			if (Network.peerType != NetworkPeerType.Disconnected && Network.maxConnections == Network.connections.Length)
				MensajeError.getInstance ().LanzarMensaje (Commons.msgServerFull, false);
			else
				MensajeError.getInstance ().LanzarMensaje (Commons.msgFailedConection, false);
		}

		// Funcion que se ejecuta en un cliente cuando se desconecta o pierde la conexion con el server
		void OnDisconnectedFromServer(NetworkDisconnection info)
		{
			MensajeError.getInstance ().LanzarMensaje (Commons.msgLostConection, true);
		}
	}
}