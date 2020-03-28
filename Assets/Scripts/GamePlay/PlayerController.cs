using UnityEngine;
using System.Collections;
using DataManager;
using CommonsGame;

namespace GamePlay
{
	public class PlayerController : MonoBehaviour 
	{
		public float speedRun = 5;				// Velocidad de movimiento del personaje para correr
		public float speedWalk = 1;				// Velocidad de movimiento del personaje para caminar
		public float turningSpeed = 60;			// Velocidad de rotacion del personaje

		private bool move;
		private Animator anim;
		private NetworkView netView;

		void Start()
		{
			Move = true;
			netView = GetComponent<NetworkView> ();
			anim = GetComponentInChildren <Animator> ();
			if (netView.isMine) 
				StartCoroutine (LevantarSkeleton (false));
			else
				enabled = false;
		}
		
		void FixedUpdate() 
		{
			if (Move) {
				int animState = Commons.IDDLE;
				// Captura del teclado los axis horizontales y verticales (Teclas WSDA o flechas)
				float horizontal = Input.GetAxis (Commons.axisX);
				float vertical = Input.GetAxis (Commons.axisZ);
				transform.Rotate (0, horizontal * turningSpeed * Time.deltaTime, 0);
				
				if (vertical > 0) {
					animState = Commons.RUN;
					transform.Translate (0, 0, vertical * speedRun * Time.deltaTime);
				} else if (vertical < 0) {
					animState = Commons.WALK_BACK;
					transform.Translate (0, 0, vertical * speedWalk * Time.deltaTime);
				}
				FijarAnimacionMovimiento (animState, true);
			}
		}

		IEnumerator LevantarSkeleton(bool value)
		{
			FijarAnimacionMovimiento (Commons.SLEEPING, false);
			yield return new WaitForSeconds (2);
			FijarAnimacionMovimiento (Commons.WALKING_UP, false);
			yield return new WaitForSeconds (2);
			FijarAnimacionMovimiento (Commons.IDDLE, value);
		}

		public void activarResurreccion(int trampa)
		{
			switch(trampa)
			{
			case 2:
				transform.position = new Vector3(144f, 20f, 55f);
				transform.rotation = Quaternion.identity;
				transform.RotateAround(transform.position, transform.up, 45f);
				break;
			case 4:
				transform.position = new Vector3(364f, 20f, 135f);
				transform.rotation = Quaternion.identity;
				transform.RotateAround(transform.position, transform.up, 180f);
				break;
			}
			StartCoroutine(LevantarSkeleton(true));
		}

		public void FijarAnimacionMovimiento(int animState, bool moveOn)
		{
			Move = moveOn;
			// Verifica que se haya efectuado un cambio de estado en la animacion actual
			if (animState != anim.GetInteger (Commons.animState)) {
				anim.SetInteger (Commons.animState, animState);
				netView.RPC ("SetAnimation", RPCMode.Others, animState);
			}
		}

		[RPC]
		void SetAnimation(int value){
			anim.SetInteger (Commons.animState, value);
		}

		public bool Move{ get; set; }
	}
}