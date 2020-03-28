using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{
	public class Loading : MonoBehaviour 
	{
		public Sprite[] spritesLoading;
		private bool loadingOn = true;

		private static Loading instance;
		public static Loading getInstance()
		{
			return instance;
		}
		
		void Start()
		{
			instance = this;
			gameObject.SetActive (false);
		}

		IEnumerator waitLoading()
		{
			int index = 0;
			while(loadingOn)
			{
				if(gameObject.activeSelf)
					GetComponentInChildren<Image>().sprite = spritesLoading[index++];
				if(index == 12)
					index = 0;
				yield return new WaitForSeconds(0.1f);
			}
		}
		
		public void Activar()
		{
			loadingOn = true;
			gameObject.SetActive (true);
			StartCoroutine (waitLoading ());
		}
		
		public void Desactivar()
		{
			loadingOn = false;
			StopCoroutine (waitLoading ());
			gameObject.SetActive (false);
		}
	}
}