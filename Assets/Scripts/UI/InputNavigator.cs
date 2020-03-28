using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI
{
	public class InputNavigator : MonoBehaviour
	{
		private EventSystem system;
		
		void Start()
		{
			system = EventSystem.current;
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();				
				if (next != null)
				{					
					InputField inputfield = next.GetComponent<InputField>();
					if (inputfield != null)
						inputfield.OnPointerClick(new PointerEventData(system));

					system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
				}
			}
		}
	}
}