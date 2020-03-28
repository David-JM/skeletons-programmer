using UnityEngine;
using System.Collections;
using CommonsGame;
using CommonsMultiplayer;
using Multiplayer;
using UI;
using UnityStandardAssets.Cameras;

namespace GamePlay
{
	public class GameController : MonoBehaviour 
	{
		public GameObject freeLookCamera;
		public GameObject followCamera;
		public GameObject gameHelp;

		private bool isPlaying = false;
		private GameObject player;
		private PlayerController playerController;
		private SpawnPlayerManager spawnPlayer;

		void Awake()
		{
			GameObject multiPlayer = GameObject.FindWithTag (Commons.tagMultiplayer);
			player = multiPlayer.GetComponent<MainClient> ().InstanciarPersonaje ();
			playerController = player.GetComponent<PlayerController> ();
			spawnPlayer = multiPlayer.GetComponent<SpawnPlayerManager> ();
			freeLookCamera.SetActive (true);
			freeLookCamera.GetComponent<AbstractTargetFollower> ().SetTarget (player.transform);
			Invoke ("ActivarHelp", 8);
		}

		void ActivarHelp()
		{
			gameHelp.SetActive (true);
		}

		void Update ()
		{
			if (!spawnPlayer.GameOn && isPlaying){
				NetworkLevelLoader.Instance.LoadLevel (Commons.sceneEndGame);
			}
			else if (Network.peerType != NetworkPeerType.Disconnected && !spawnPlayer.GameOn) {
				string msg = "Jugadores online: " + spawnPlayer.getPlayers ().Count + " / " + Commons.numPlayers + "\n\n"
					+ spawnPlayer.ListarPlayers () + "\nEsperando por mas jugadores...";
				LobbyManager.getInstance ().Activar(msg);
			} else if (spawnPlayer.GameOn && !isPlaying)
				StartCoroutine (waitForStartGame ());

			if (Input.GetKeyUp (KeyCode.C) && isPlaying) 
			{
				playerController.Move = !playerController.Move;
				if(playerController.Move)
				{
					followCamera.SetActive(true);
					freeLookCamera.SetActive(false);
				}
				else
				{
					followCamera.SetActive(false);
					freeLookCamera.SetActive(true);
					freeLookCamera.transform.position = player.transform.position;
					playerController.FijarAnimacionMovimiento(Commons.IDDLE, false);
				}
			}

			if (spawnPlayer.getGanadores ().Count != GameStats.getInstance ().getWinners ())
				GameStats.getInstance ().MostrarGanadores (spawnPlayer.getGanadores ());

			if (Input.GetKeyUp (KeyCode.G))
				GameStats.getInstance ().ShowHideGanadores ();

			if (Input.GetKeyUp (KeyCode.H))
				gameHelp.SetActive (!gameHelp.activeSelf);

			if (Input.GetKeyUp (KeyCode.Escape))
				GameMenu.getInstance ().Activar ();
		}

		IEnumerator waitForStartGame()
		{
			isPlaying = true;
			for (int i = 5; i > 0; i--)
			{
				LobbyManager.getInstance ().Activar ("El juego comenzara en\n\n"+i);
				yield return new WaitForSeconds (1);
			}
			LobbyManager.getInstance ().Desactivar ();
			freeLookCamera.SetActive (false);
			followCamera.SetActive (true);
			followCamera.GetComponent<CameraFollow> ().StartCamera (player.transform);
			playerController.Move = true;
			DesafioManager.getInstance ().setControllers (playerController, player.GetComponent<MusicPlayerController> ());
			GameStats.getInstance ().setSpawnPlayer (spawnPlayer);
		}
	}
}