using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{

		public Item item;
		private Image itemIcon;
		public int slotNumber;
		Inventory inventory;

		// Use this for initialization
		void Start ()
		{
				inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
				itemIcon = gameObject.transform.GetChild (0).GetComponent<Image> ();

		}

		// Update is called once per frame
		void Update ()
		{
		
				if (inventory.allItems [slotNumber].itemName != null) {
			
						itemIcon.enabled = true;
						itemIcon.sprite = inventory.allItems [slotNumber].itemIcon;

				} else {

						itemIcon.enabled = false;
				}
		}

		public void OnPointerDown (PointerEventData data)
		{
				Debug.Log (transform.name);

		}

		public void OnPointerEnter (PointerEventData data)
		{
				if (inventory.allItems [slotNumber].itemName != null) {
						inventory.ShowTooltip (inventory.allSlots [slotNumber].GetComponent<RectTransform> ().localPosition, inventory.allItems [slotNumber]);
				}
		
		}

		public void OnPointerExit (PointerEventData data)
		{
				if (inventory.allItems [slotNumber].itemName != null) {
						inventory.HideTooltip ();
				}
		
		}
		
		public void OnDrag (PointerEventData data)
		{
				if (inventory.allItems [slotNumber].itemName != null) {
			inventory.ShowDraggedItem(inventory.allItems [slotNumber]);
				}
		}


}
