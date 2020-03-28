using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DataManager;
using CommonsGame;
using GamePlay;

namespace UI
{
	public class DesafioManager : MonoBehaviour 
	{
		public GameObject[] trampas;
		public RectTransform[] espacios;
		public GameObject pnlAlgoritmo;
		public GameObject pnlGuia;

		private PlayerController playerController;
		private MusicPlayerController musicPlayer;
		private AlgoritmoInfoManag algoritmoManager;
		private AlgoritmoInfo algoritmoInfo;
		private Text guia;
		private int trampa;

		private static DesafioManager instance;
		public static DesafioManager getInstance()
		{
			return instance;
		}

		void Start()
		{
			instance = this;
			guia = pnlGuia.GetComponentInChildren<Text> ();
			algoritmoManager = new AlgoritmoInfoManag ();
			Desactivar ();
		}

		public void ActivarDesafio(int trampa)
		{
			this.trampa = trampa;
			gameObject.SetActive (true);
			pnlAlgoritmo.GetComponent<CanvasGroup> ().interactable = true;

			StartCoroutine (ActivarAnimaciones (false));
			StartCoroutine (waitForRequest (algoritmoManager.CrearFormAlgoritmo (trampa)));
		}

		IEnumerator ActivarAnimaciones(bool isHidden)
		{
			pnlAlgoritmo.GetComponent<Animator> ().SetBool (Commons.isHidden, isHidden);
			yield return new WaitForSeconds (1);
			pnlGuia.GetComponent<Animator> ().SetBool (Commons.isHidden, isHidden);
		}

		IEnumerator waitForRequest(WWW consultarAlgoritmo)
		{
			Text algoritmo = GetComponentInChildren<Text> ();
			yield return consultarAlgoritmo;
			algoritmoManager.ConsultarAlgoritmo (consultarAlgoritmo);
			WWW consultarVariables = algoritmoManager.CrearFormVariables ();
			yield return consultarVariables;
			algoritmoInfo = algoritmoManager.ConsultarVariables (consultarVariables);
			List<VariableAlgoritmo> variables = algoritmoInfo.Variables;
			for (int i=0; i<espacios.Length; i++) 
			{
				if(variables.Count <= i){
					espacios[i].gameObject.SetActive(false);
				}else{
					espacios [i].anchoredPosition = new Vector2 (variables [i].getPosX (), variables [i].getPosY ());
				}
			}
			algoritmo.text = algoritmoInfo.Algoritmo;
			guia.text = algoritmoInfo.Guia + " Debes completar todos los espacios correctamente, " +
				"de lo contrario no podras continuar a menos que sacrifiques una de tus vidas...";
		}
		
		public void Ok()
		{
			pnlAlgoritmo.GetComponent<CanvasGroup> ().interactable = false;
			SoundsManager.getInstance ().Play ();
			PlayerInfoManager.Instance.getPlayer ().Desafios[trampa].Intentos++;
			if (EvaluarAlgoritmo()) 
			{
				guia.text = "Excelente sigue asi...";
				PlayerInfoManager.Instance.getPlayer ().Desafios[trampa].Superado = true;
				PlayerInfoManager.Instance.getPlayer ().DesafiosSuperados++;
				TerminarDesafio(false);
				Invoke ("Ocultar", 2);
			}
			else 
			{
				guia.text = "Has fallado intenta de nuevo. "+algoritmoInfo.Guia;
				LimpiarInputs();
				pnlAlgoritmo.GetComponent<CanvasGroup> ().interactable = true;
			}
		}

		public void Cancelar()
		{
			pnlAlgoritmo.GetComponent<CanvasGroup> ().interactable = false;
			SoundsManager.getInstance ().Play ();
			guia.text = "Has perdido una de tus valiosas vidas, Mira cuidadosamente la solucion de este desafio y ten cuidado mas adelante...";
			PlayerInfoManager.Instance.getPlayer ().Desafios[trampa].Intentos++;
			PlayerInfoManager.Instance.getPlayer ().Desafios [trampa].Superado = false;
			AutoCompletarAlgoritmo ();
			TerminarDesafio (true);
			Invoke ("Ocultar", 15);
		}

		void TerminarDesafio(bool perderVida)
		{
			if (perderVida) {
				PlayerInfoManager.Instance.getPlayer ().Lifes--;
				GameStats.getInstance().ActualizarVidas();
			}
			
			switch(trampa)
			{
			case 1:
				trampas[0].GetComponent<NatureShieldTrick>().ActivarNatureShields(false);
				break;
			case 2:
				playerController.activarResurreccion(2);
				break;
			case 3:
				trampas[1].GetComponent<CycloneTrick>().Activar(false);
				playerController.FijarAnimacionMovimiento(Commons.IDDLE, true);
				break;
			case 4:
				playerController.activarResurreccion(4);
				break;
			}
			musicPlayer.ChangeMusic ();
		}

		bool EvaluarAlgoritmo()
		{
			InputField[] inputs = pnlAlgoritmo.GetComponentsInChildren<InputField> ();
			for (int i=0; i<inputs.Length; i++)
				if (inputs [i].text != algoritmoInfo.Variables [i].getValor ())
					return false;
			return true;
		}
		
		void AutoCompletarAlgoritmo()
		{
			InputField[] inputs = pnlAlgoritmo.GetComponentsInChildren<InputField> ();
			for (int i=0; i<inputs.Length; i++)
				inputs [i].text = algoritmoInfo.Variables [i].getValor ();
		}

		void Ocultar()
		{
			StartCoroutine (ActivarAnimaciones (true));
			LimpiarInputs ();
			ReactivarComponentes ();
			Invoke ("Desactivar", 3);
		}
		
		void ReactivarComponentes()
		{
			for (int i=0; i<espacios.Length; i++)
				espacios [i].gameObject.SetActive (true);
		}
		
		void LimpiarInputs()
		{
			InputField[] inputs = pnlAlgoritmo.GetComponentsInChildren<InputField> ();
			for (int i=0; i<inputs.Length; i++)
				inputs [i].text = "";
		}
		
		void Desactivar()
		{
			gameObject.SetActive (false);
		}

		public void setControllers(PlayerController playerController, MusicPlayerController musicManager)
		{
			this.playerController = playerController;
			this.musicPlayer = musicManager;
		}
	}	
}