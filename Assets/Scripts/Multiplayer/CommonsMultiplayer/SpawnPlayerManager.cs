using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataManager;

namespace CommonsMultiplayer
{
	public class SpawnPlayerManager : MonoBehaviour 
	{
		private NetworkView netview;

		private float playerPositionZ;
		private bool gameOn;
		private Dictionary <NetworkPlayer, PlayerInfo> players;
		private List <PlayerInfo> ganadores;
		private int puntos;

		void Start()
		{
			players = new Dictionary<NetworkPlayer, PlayerInfo> ();
			ganadores = new List<PlayerInfo> ();
			netview = GetComponent<NetworkView> ();
		}

		public void AgregarPlayer (NetworkPlayer netPlayer, PlayerInfo playerInfo)
		{
			AgregarPlayerRPC (netPlayer, playerInfo.PlayerName, playerInfo.Nivel, playerInfo.Rango, playerInfo.Lifes);
			netview.RPC ("AgregarPlayerRPC", RPCMode.OthersBuffered, netPlayer, playerInfo.PlayerName, playerInfo.Nivel, playerInfo.Rango, playerInfo.Lifes);
		}

		[RPC]
		void AgregarPlayerRPC(NetworkPlayer netPlayer, string playerName, string nivel, string rango, int lifes)
		{
			PlayerInfo player = new PlayerInfo ();
			player.PlayerName = playerName;
			player.Nivel = nivel;
			player.Rango = rango;
			player.Lifes = lifes;
			players.Add (netPlayer, player);
		}

		public void EliminarPlayer (NetworkPlayer netPlayer)
		{
			EliminarPlayerRPC (netPlayer);
			netview.RPC ("EliminarPlayerRPC", RPCMode.OthersBuffered, netPlayer);
		}
		
		[RPC]
		void EliminarPlayerRPC(NetworkPlayer netPlayer)
		{
			players.Remove (netPlayer);
		}

		public void QuitarVidas(NetworkPlayer netPlayer, int lifes)
		{
			QuitarVidasRPC (netPlayer, lifes);
			netview.RPC ("QuitarVidasRPC", RPCMode.OthersBuffered, netPlayer, lifes);
		}

		[RPC]
		void QuitarVidasRPC(NetworkPlayer netPlayer, int lifes)
		{
			players [netPlayer].Lifes = lifes;
		}

		public void EnviarPlayerPosition (NetworkPlayer netPlayer, float playerPosZ)
		{
			netview.RPC ("EnviarPlayerPositionRPC", netPlayer, playerPosZ);
		}

		[RPC]
		void EnviarPlayerPositionRPC(float playerPosZ)
		{
			playerPositionZ = playerPosZ;
		}

		public void SetGameState (bool value, NetworkPlayer netPlayer)
		{
			netview.RPC ("SetGameStateRPC", netPlayer, value);
		}

		public void SetGameState (bool value)
		{
			netview.RPC ("SetGameStateRPC", RPCMode.Others, value);
		}
		
		[RPC]
		void SetGameStateRPC(bool value)
		{
			GameOn = value;
		}

		public void AgregarGanador (NetworkPlayer netPlayer, int puntos)
		{
			AgregarGanadorRPC (netPlayer);
			netview.RPC ("AgregarGanadorRPC", RPCMode.OthersBuffered, netPlayer);
			netview.RPC ("SetPuntosRPC", netPlayer, puntos);
			SetGameState (false, netPlayer);
		}
		
		[RPC]
		void AgregarGanadorRPC(NetworkPlayer netPlayer)
		{
			ganadores.Add (players [netPlayer]);
		}

		[RPC]
		void SetPuntosRPC(int value)
		{
			puntos = value;
		}
		
		public string ListarPlayers()
		{
			string playersOn = "";
			foreach (KeyValuePair<NetworkPlayer, PlayerInfo> player in players)
				playersOn += player.Value.PlayerName + " - " + player.Value.Nivel + "\n";
			return playersOn;
		}

		public Dictionary <NetworkPlayer, PlayerInfo> getPlayers(){
			return players;
		}

		public List<PlayerInfo> getGanadores(){
			return ganadores;
		}

		public float getPlayerPosition(){
			return playerPositionZ;
		}

		public int getPuntos(){
			return puntos;
		}

		public bool GameOn{ get; set; }
	}
}