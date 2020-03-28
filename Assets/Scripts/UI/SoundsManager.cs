using UnityEngine;
using System.Collections;

namespace UI
{
	public class SoundsManager : MonoBehaviour 
	{
		private AudioSource clickSound;

		private static SoundsManager instance;
		public static SoundsManager getInstance()
		{
			return instance;
		}

		void Start () 
		{
			instance = this;
			clickSound = GetComponent<AudioSource> ();
		}

		public void Play()
		{
			clickSound.Play ();
		}
	}
}
