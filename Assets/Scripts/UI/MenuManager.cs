using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Multiplayer;
using DataManager;
using CommonsGame;
using UI;

namespace UI
{
	public class MenuManager : MonoBehaviour 
	{
		public GameObject[] personajes;
		public GameObject[] pickerColors;
		private int pjSelected = 0;

		public GameObject pnlUser;
		public GameObject pnlRegistrar;
		public GameObject pnlSelectNivel;
		public GameObject pnlSelectPj;
		public GameObject pnlJoinServer;
		public GameObject pnlCreditos;
		public GameObject pnlMsgExito;

		private Commons.Server serverSelected;

		private static MenuManager instance;
		public static MenuManager getInstance()
		{
			return instance;
		}

		void Start()
		{
			instance = this;
			serverSelected = Commons.Server.Hades;
		}

		public void GoHelp()
		{
			Application.ExternalEval ("window.open('http://newanimehd.blogspot.com/','Ayuda')");
		}

		public void OnClickCreditos()
		{
			SoundsManager.getInstance ().Play ();
			StartCoroutine (ActivarAnimaciones (pnlUser, true));
			StartCoroutine (ActivarAnimaciones (pnlCreditos, false));
		}

		// Muestra el panel para registrar un usuario
		public void OnClickRegistrar()
		{
			SoundsManager.getInstance ().Play ();
			StartCoroutine (ActivarAnimaciones (pnlUser, true));
			StartCoroutine (ActivarAnimaciones (pnlRegistrar, false));
		}

		public void activarSelectNivel()
		{
			SoundsManager.getInstance ().Play ();
			pnlSelectNivel.SetActive (true);
		}

		public void SelectNivel(int nivel)
		{
			Text nivelSelected = pnlRegistrar.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ();
			if (nivel == 1)
				nivelSelected.text = Commons.novato;
			else
				nivelSelected.text = Commons.experto;
			pnlSelectNivel.SetActive (false);
		}

		// Registra un nuevo usuario
		public void OnClickOk()
		{
			//Obtiene el componente InputField de los objetos hijos del pnlRegistrar en el mismo orden de ubicacion en el Editor
			// 0 => Usuario
			// 1 => Contraseña
			// 1 => Edad
			SoundsManager.getInstance ().Play ();
			InputField[] inputs = pnlRegistrar.GetComponentsInChildren<InputField> ();
			string name = inputs [0].text;
			string pass = inputs [1].text;
			string nivel = pnlRegistrar.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text;
			pnlRegistrar.SetActive (false);
			Loading.getInstance ().Activar ();
			StartCoroutine (waitForRegister (PlayerInfoManager.Instance.ValidaRegistrar (name, pass, nivel), name));
		}

		IEnumerator waitForRegister(WWW register, string name)
		{
			yield return register;
			string msgPlayerManager = PlayerInfoManager.Instance.Registrar (register);
			if (name.Equals (msgPlayerManager)) {
				pnlMsgExito.SetActive (true);
				Text mensaje = pnlMsgExito.GetComponentInChildren<Text> ();
				mensaje.text = "Bienvenid@ " + name + "!";
			} else {
				pnlRegistrar.SetActive (true);
				MensajeError.getInstance ().LanzarMensaje (msgPlayerManager, false);
			}
			Loading.getInstance ().Desactivar ();
		}

		// Funcion que valida el usuario y contraseña de usuario para conectarse al juego
		public void OnClickConectar()
		{
			//Obtiene el componente InputField de los objetos hijos del pnlRegistrar en el mismo orden de ubicacion en el Editor
			// 0 => Usuario
			// 1 => Contraseña
			SoundsManager.getInstance ().Play ();
			InputField[] inputs = pnlUser.GetComponentsInChildren<InputField> ();
			string name = inputs [0].text;
			string pass = inputs [1].text;
			pnlUser.SetActive (false);
			Loading.getInstance ().Activar ();
			StartCoroutine (waitForConnect (PlayerInfoManager.Instance.ValidaConectar (name, pass)));
		}

		IEnumerator waitForConnect(WWW login)
		{
			yield return login;
			string msgPlayerManager = PlayerInfoManager.Instance.Conectar (login);
			if (Commons.msgTrue.Equals (msgPlayerManager)) {
				pnlSelectPj.SetActive (true);
				StartCoroutine (renderPnlSelectPersonaje (true));
			}
			else {
				pnlUser.SetActive (true);
				MensajeError.getInstance ().LanzarMensaje (msgPlayerManager, false);
			}
			Loading.getInstance ().Desactivar ();
		}

		IEnumerator renderPnlSelectPersonaje(bool render)
		{
			yield return new WaitForSeconds (2);
			personajes [pjSelected].SetActive (render);
		}

		public void SelectColor(int color)
		{
			SoundsManager.getInstance ().Play ();
			personajes [pjSelected].GetComponentInChildren<Light> ().color = pickerColors [color].GetComponent<Image> ().color;
		}

		// Funcion que realiza la conexion con el servidor seleccionado e inicia el juego
		public void OnClickNext() 
		{
			SoundsManager.getInstance ().Play ();
			if (pjSelected < 3) {
				pjSelected++;
				personajes [pjSelected].SetActive (true);
				personajes [pjSelected - 1].SetActive (false);
			}
		}

		// Funcion que realiza la conexion con el servidor seleccionado e inicia el juego
		public void OnClickPrev() 
		{
			SoundsManager.getInstance ().Play ();
			if (pjSelected > 0) {
				pjSelected--;
				personajes [pjSelected].SetActive (true);
				personajes [pjSelected + 1].SetActive (false);
			}			
		}

		// Funcion que realiza la conexion con el servidor seleccionado e inicia el juego
		public void OnClickOkPersonaje() 
		{
			SoundsManager.getInstance ().Play ();
			PlayerInfoManager.Instance.getPlayer ().Prefab = pjSelected;
			PlayerInfoManager.Instance.getPlayer ().LightColor = personajes [pjSelected].GetComponentInChildren<Light> ().color;

			StartCoroutine (ActivarAnimaciones (pnlSelectPj, true));
			StartCoroutine (ActivarAnimaciones (pnlJoinServer, false));
			StartCoroutine (renderPnlSelectPersonaje (false));
		}

		// Funcion ejecutada cuando se captura el event value Change del Toogle
		public void SelectServer(int server)
		{
			SoundsManager.getInstance ().Play ();
			if (server == 1)
				serverSelected = Commons.Server.Hades;
			else
				serverSelected = Commons.Server.Shadow;
		}
		
		// Funcion que realiza la conexion con el servidor seleccionado e inicia el juego
		public void OnClickJugar() 
		{
			SoundsManager.getInstance ().Play ();
			gameObject.SetActive (false);
			GameObject.FindWithTag (Commons.tagMultiplayer).GetComponent<MainClient> ().JoinServer (serverSelected);
		}
		
		public void Atras()
		{
			SoundsManager.getInstance ().Play ();
			pnlUser.SetActive (true);
			pnlRegistrar.SetActive (false);
			pnlSelectPj.SetActive (false);
			pnlJoinServer.SetActive (false);
			pnlCreditos.SetActive (false);
		}

		public void OnClickOkMsgExito()
		{
			SoundsManager.getInstance ().Play ();
			StartCoroutine (ActivarAnimaciones (pnlMsgExito, true));
			StartCoroutine (ActivarAnimaciones (pnlSelectPj, false));
			StartCoroutine (renderPnlSelectPersonaje (true));
		}

		IEnumerator ActivarAnimaciones(GameObject go, bool isHidden)
		{
			//Valida si se va a lanzar el panel
			if (!isHidden){
				yield return new WaitForSeconds (2);
				go.SetActive (true);
			}
			//Valida se se va a ocultar el panel
			if (isHidden) {
				Animator[] anims = go.GetComponentsInChildren<Animator> ();
				foreach(Animator a in anims)
					a.SetBool(Commons.isHidden, isHidden);
				yield return new WaitForSeconds (2);
				go.SetActive (false);
			}
		}
	}
}