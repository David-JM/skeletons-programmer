using UnityEngine;
using System.Collections;
using CommonsMultiplayer;
using CommonsGame;
using Multiplayer;

namespace UI
{
	public class StatsPlayerManager : MonoBehaviour 
	{
		public GameObject rangoNameText;
		
		void Start()
		{
			NetworkView netView = GetComponent<NetworkView> ();
			if (netView.isMine)
				enabled = false;
			else
				StartCoroutine (waitForRPC ());
		}

		IEnumerator waitForRPC()
		{
			StatsPlayer stats = GetComponent<StatsPlayer> ();
			yield return new WaitForSeconds (3);
			rangoNameText.GetComponent<TextMesh> ().text = stats.getPlayerName_rango ();
			if (stats.getPlayerName_rango () == null) {
				yield return new WaitForSeconds (3);
				rangoNameText.GetComponent<TextMesh> ().text = stats.getPlayerName_rango ();
			}
		}

		void Update()
		{
			Quaternion cameraRotation = Camera.main.transform.rotation;
			rangoNameText.transform.rotation = cameraRotation;
		}

		/*
		void Update()
		{
			Vector3 direction = Camera.main.transform.forward;  // Calculate Ray direction
			Debug.DrawRay (Camera.main.transform.position, direction, Color.red);
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50f)){
				Debug.Log("Name = "+hit.collider.name+"--- Tag = "+hit.collider.tag);
				//if(hit.collider.tag.Equals(Commons.tagPlayer))
					//showStats = true;
			}
			Vector3 cameraRelativePosition = Camera.main.transform.InverseTransformPoint (target.position);
			if (cameraRelativePosition.z > 0) {
				Debug.Log("Esta en frente de la camara");
			}
			else
				Debug.Log("NO ESTA en frente de la camara");
		}

		void OnGUI()
		{
			if(showStats)
			{
				Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
				Vector3 screenPosition = Camera.main.WorldToScreenPoint (worldPosition);
				GUI.Label(new Rect(screenPosition.x-labelWidth/2, Screen.height - screenPosition.y - labelTop, labelWidth, labelHeight), stats.getPlayerName_rango(), myStyle);
			}
		}
		*/
	}
}