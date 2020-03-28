using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using CommonsMultiplayer;
using DataManager;
using CommonsGame;

namespace UI
{
	public class DatosPartida : MonoBehaviour 
	{
		public GameObject[] winners;

		public GameObject pnlResumen;
		public GameObject pnlDetalleDesafios;
		public GameObject pnlDetalleLogros;

		public Text[] resumenDatosPartida;
		public GameObject[] desafiosSuperados;
		public GameObject[] logrosDesbloqueados;
		public Sprite[] medallas;

		private SpawnPlayerManager spawnPlayer;
		public class LogroInfo
		{
			public string nombre; 
			public int medalla;
			public LogroInfo(string nombre, string medalla){
				this.nombre = nombre;
				this.medalla = int.Parse(medalla);
			}
		}
		private int numLogros = 0;
		private List<LogroInfo> logros;

		
		void Start()
		{
			logros = new List<LogroInfo> (3);
			spawnPlayer = GameObject.FindWithTag (Commons.tagMultiplayer).GetComponent<SpawnPlayerManager> ();
			//Ganadores partida
			for(int i = 0; i<spawnPlayer.getGanadores().Count ;i++)
			{
				Text[] datos = winners [i].GetComponentsInChildren<Text> ();
				datos[0].text = (i+1).ToString();
				datos[1].text = spawnPlayer.getGanadores()[i].PlayerName;
				datos[2].text = spawnPlayer.getGanadores()[i].Rango;
				datos[3].text = spawnPlayer.getGanadores()[i].Nivel;
				datos[4].text = spawnPlayer.getGanadores()[i].Lifes.ToString();
			}

			EvaluarLogros ();

			//Resumen partida
			resumenDatosPartida [0].text = PlayerInfoManager.Instance.getPlayer ().DesafiosSuperados 
				+ " de " + PlayerInfoManager.Instance.getPlayer ().Desafios.Count;
			resumenDatosPartida [2].text = "Puntos obtenidos: " + spawnPlayer.getPuntos ();

			CleanScene.Instance.Clean ();
			Network.Disconnect ();
		}

		void EvaluarLogros()
		{
			Debug.Log ("Entro a EvaluarLogros");
			if (spawnPlayer.getGanadores () [0].PlayerName.Equals (PlayerInfoManager.Instance.getPlayer ().PlayerName)) {
				StartCoroutine(guardarLogros ("Invencible", 1));
			}
			if (spawnPlayer.getPuntos () > 0 && PlayerInfoManager.Instance.getPlayer ().Lifes == 3) {
				StartCoroutine(guardarLogros ("Resistente", 1));
			}
			int cont = 0;
			foreach (KeyValuePair<int, DesafioInfo> desafio in PlayerInfoManager.Instance.getPlayer().Desafios){
				if(desafio.Value.Intentos == 1 && desafio.Value.Superado)
					cont++;
			}
			if (cont > 0)
				StartCoroutine (guardarLogros ("Eficaz", cont));
		}

		IEnumerator guardarLogros(string logro, int contador)
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_user", PlayerInfoManager.Instance.getPlayer ().PlayerName);
			form.AddField ("myform_logro", logro);
			form.AddField ("myform_cont", contador);
			form.AddBinaryData ("binary", new byte[1]);
			WWW guardar = new WWW (Commons.urlLogros, form);
			yield return guardar;
			if (guardar.error != null) {
				Debug.Log(guardar.error);
			} else {
				string[] datos = guardar.text.Split("-" [0]);
				Debug.Log(guardar.text);
				if(datos.Length>1){
					numLogros++;
					logros.Add(new LogroInfo(datos[0], datos[1]));
				}
				guardar.Dispose();
			}
			resumenDatosPartida [1].text = numLogros.ToString ();
		}
		public void VerDetalleLogros()
		{
			pnlResumen.SetActive (false);
			pnlDetalleLogros.SetActive (true);

			for (int i =0; i<logros.Count; i++) {
				logrosDesbloqueados [i].GetComponentInChildren<Text> ().text = logros[i].nombre;
				logrosDesbloqueados [i].GetComponentInChildren<Image> ().sprite = medallas[logros[i].medalla-1];
			}
		}

		public void VerDetalleDesafios()
		{
			pnlResumen.SetActive (false);
			pnlDetalleDesafios.SetActive (true);
			//Detalle desafios superados
			foreach (KeyValuePair<int, DesafioInfo> desafio in PlayerInfoManager.Instance.getPlayer().Desafios)
			{
				Text[] datos = desafiosSuperados[desafio.Key-1].GetComponentsInChildren<Text>();
				datos[0].text = desafio.Value.Descripcion;
				datos[1].text = desafio.Value.Intentos.ToString();
				datos[2].text = desafio.Value.Superado?"Si":"No";
			}
		}

		public void Atras()
		{
			pnlResumen.SetActive (true);
			pnlDetalleDesafios.SetActive (false);
			pnlDetalleLogros.SetActive (false);
		}

		public void volverMenu()
		{
			Application.LoadLevel (Commons.sceneMenu);
		}
	}
}