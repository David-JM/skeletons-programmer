using UnityEngine;
using System.Collections;

namespace CommonsGame
{
	public class DontDestroy : MonoBehaviour 
	{
		void Awake () 
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}