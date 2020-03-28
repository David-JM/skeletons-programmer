using UnityEngine;
using System.Collections;
using CommonsGame;

namespace GamePlay
{
	public class NatureShieldTrick : MonoBehaviour 
	{
		public Animator[] animShields;
		public BoxCollider[] shields;

		public void ActivarNatureShields(bool activar)
		{
			foreach (Animator a in animShields)
				a.SetBool (Commons.isActive, activar);
			shields[0].enabled = activar;
			shields[1].enabled = activar;
		}
	}
}