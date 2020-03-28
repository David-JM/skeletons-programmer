using UnityEngine;
using System.Collections;
using DataManager;

namespace Multiplayer
{
	public class StatsPlayer : MonoBehaviour 
	{
		private string playerNameRango;
		private NetworkPlayer netPlayer;

		void Start()
		{
			NetworkView netView = GetComponent<NetworkView> ();
			if (netView.isMine) 
			{
				netView.group = 1;
				netView.RPC ("setNetworkPlayer", RPCMode.Server, Network.player);
				netView.RPC ("setStats", RPCMode.OthersBuffered, PlayerInfoManager.Instance.getPlayer().PlayerName, PlayerInfoManager.Instance.getPlayer().Rango);
			}
		}

		[RPC]
		void setNetworkPlayer(NetworkPlayer netPlayer){
			this.netPlayer = netPlayer;
		}
		
		[RPC]
		void setStats(string playerName, string rango){
			playerNameRango = rango + "\n" + playerName;
		}
		
		public NetworkPlayer getNetPlayer(){
			return netPlayer;
		}

		public string getPlayerName_rango(){
			return playerNameRango;
		}
	}
}