using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using CommonsGame;

namespace GamePlay
{
	public class MusicPlayerController : MonoBehaviour 
	{
		public AudioMixerSnapshot fire1;
		public AudioMixerSnapshot fire2;
		public AudioMixerSnapshot fire3;
		public AudioMixerSnapshot fire4;

		private float bpm = 128;
		private float m_TransitionIn;
		private float m_TransitionOut;
		private float m_QuarterNote;

		private NetworkView netView;

		void Start () 
		{
			netView = GetComponent<NetworkView> ();
			m_QuarterNote = 60 / bpm;
			m_TransitionIn = m_QuarterNote;
			m_TransitionOut = m_QuarterNote * 32;
		}

		void OnTriggerEnter(Collider other)
		{
			if (netView.isMine)
			{
				switch(other.tag)
				{
				case Commons.tagShield:
					fire4.TransitionTo(m_TransitionIn);
					break;
				case Commons.tagIce1:
					fire3.TransitionTo(m_TransitionIn);
					break;
				case Commons.tagCyclone:
					fire4.TransitionTo(m_TransitionIn);
					break;
				case Commons.tagIce2:
					fire3.TransitionTo(m_TransitionIn);
					break;
				case Commons.tagOtherMusic:
					fire2.TransitionTo(m_TransitionIn);
					break;
				}
			}
		}

		public void ChangeMusic()
		{
			fire1.TransitionTo (m_TransitionOut);
		}

		void OnTriggerExit(Collider other)
		{
			if (netView.isMine && other.CompareTag (Commons.tagOtherMusic))
				ChangeMusic ();
		}
	}
}