using UnityEngine;
using System.Collections;
using CommonsGame;

namespace CommonsMultiplayer
{
	public class ServersConfig : MonoBehaviour 
	{	
		private WWWForm form;
		void Start () 
		{
			form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddBinaryData ("binary", new byte[1]);
			ConsultarConfiguracion ();
		}

		public void ConsultarConfiguracion()
		{
			StartCoroutine (waitForRequest (new WWW (Commons.urlConsultarConfigServer, form)));
		}

		IEnumerator waitForRequest(WWW configServer)
		{
			yield return configServer;
			if (configServer.error != null)
				Debug.Log (configServer.error);
			else {
				string[] datos = configServer.text.Split("-" [0]);
				Commons.ipServer = datos[0];
				Commons.portHades = datos[1];
				Commons.portShadow = datos[2];
			}
			configServer.Dispose ();
		}
	}
}