using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CommonsGame;

namespace DataManager
{
	public class DesafioInfoManager : MonoBehaviour 
	{
		void Awake()
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddBinaryData ("binary", new byte[1]);
			StartCoroutine (waitForRequest (new WWW (Commons.urlDesafio, form)));
		}

		IEnumerator waitForRequest(WWW consultarDesafios)
		{
			yield return consultarDesafios;
			if (consultarDesafios.error != null)
				Debug.Log(consultarDesafios.error);
			else 
			{
				string[] desafios = consultarDesafios.text.Split("-" [0]);
				PlayerInfoManager.Instance.getPlayer().Desafios = new Dictionary<int, DesafioInfo>(desafios.Length-1);
				for(int i = 0; i < desafios.Length-1; i++)
				{
					DesafioInfo desafio = new DesafioInfo(desafios[i], false, 0);
					PlayerInfoManager.Instance.getPlayer().Desafios.Add(i+1, desafio);
				}
				consultarDesafios.Dispose();
			}
		}
	}
}