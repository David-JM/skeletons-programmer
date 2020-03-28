using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using CommonsGame;

namespace DataManager
{
	public class AlgoritmoInfoManag
	{
		private AlgoritmoInfo algoritmoInfo;
		
		public WWW CrearFormAlgoritmo(int trampa)
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_trampa", trampa);
			form.AddField ("myform_numAlgoritmo", Random.Range (1, 3) == 1 ? 1 : 2);
			form.AddField ("myform_nivel", PlayerInfoManager.Instance.getPlayer ().Nivel);
			form.AddBinaryData ("binary", new byte[1]);
			return new WWW (Commons.urlAlgoritmo, form);
		}
		
		public void ConsultarAlgoritmo(WWW consultarAlgoritmo)
		{
			algoritmoInfo = new AlgoritmoInfo ();
			if (consultarAlgoritmo.error != null) {
				Debug.Log(consultarAlgoritmo.error);
			} else {
				string[] datos = consultarAlgoritmo.text.Split("-" [0]);
				algoritmoInfo.ID = int.Parse(datos[0]);
				algoritmoInfo.Algoritmo = datos[1];
				algoritmoInfo.Guia = datos[2];
				consultarAlgoritmo.Dispose();
			}
		}

		public WWW CrearFormVariables()
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_idAlgoritmo", algoritmoInfo.ID);
			form.AddBinaryData ("binary", new byte[1]);
			return new WWW (Commons.urlVariables, form);
		}
		
		public AlgoritmoInfo ConsultarVariables(WWW consultarVariables)
		{
			if (consultarVariables.error != null) {
				Debug.Log(consultarVariables.error);
			} else {
				string[] datos = consultarVariables.text.Split("/" [0]);
				algoritmoInfo.Variables = new List<VariableAlgoritmo>(datos.Length-1);
				for(int i=0; i<datos.Length-1; i++)
				{
					string[] var = datos[i].Split("," [0]);
					VariableAlgoritmo variable = new VariableAlgoritmo(var[0], float.Parse(var[1]), float.Parse(var[2]));
					algoritmoInfo.Variables.Add(variable);
				}
				consultarVariables.Dispose();
			}
			return algoritmoInfo;
		}
	}
}