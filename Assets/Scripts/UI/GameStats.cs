using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using CommonsGame;
using DataManager;
using CommonsMultiplayer;

namespace UI
{
	public class GameStats : MonoBehaviour 
	{
		public Image[] vidas;
		public GameObject pnlGanadores;
		public GameObject pnlStatsPlayer;
		private SpawnPlayerManager spawnPlayer;
		private int totalWinners;

		private static GameStats instance;
		public static GameStats getInstance()
		{
			return instance;
		}

		void Start()
		{
			instance = this;
			totalWinners = 0;
			pnlGanadores.SetActive (false);
			pnlStatsPlayer.GetComponentInChildren<Image> ().sprite = PlayerInfoManager.Instance.getPlayer ().IconPlayer;
			Text[] datos = pnlStatsPlayer.GetComponentsInChildren<Text> ();
			datos [0].text = PlayerInfoManager.Instance.getPlayer ().Rango;
			datos [1].text = PlayerInfoManager.Instance.getPlayer ().PlayerName;
			datos [2].text = PlayerInfoManager.Instance.getPlayer ().Nivel;
		}

		public void ActualizarVidas()
		{
			Destroy (vidas [PlayerInfoManager.Instance.getPlayer ().Lifes].gameObject);
			spawnPlayer.QuitarVidas (Network.player, PlayerInfoManager.Instance.getPlayer ().Lifes);
			if (PlayerInfoManager.Instance.getPlayer ().Lifes == 0)
				NetworkLevelLoader.Instance.LoadLevel (Commons.sceneEndGame);
		}

		public void MostrarGanadores(List<PlayerInfo> ganadores)
		{
			pnlGanadores.SetActive (true);
			string msg = "Ganadores:\n\n";
			for(int i = 0; i<ganadores.Count; i++)
				msg += i+1+". "+ganadores[i].PlayerName+"\n";
			totalWinners = ganadores.Count;
			pnlGanadores.GetComponentInChildren<Text>().text = msg;
		}

		public void ShowHideGanadores()
		{
			pnlGanadores.SetActive (!pnlGanadores.activeSelf);
		}

		public void setSpawnPlayer(SpawnPlayerManager spawnPlayer)
		{
			this.spawnPlayer = spawnPlayer;
		}

		public int getWinners()
		{
			return totalWinners;
		}
	}
}