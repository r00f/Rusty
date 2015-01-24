using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
		public List<GameObject> allSlots = new List<GameObject> ();
		public List<Item> allItems = new List<Item> ();
		public GameObject slots;
		ItemDatabase database;
		private int slotX = -110;
		private int slotY = 110;
		public GameObject tooltip;
		public GameObject draggedItem;
		public bool draggingItem = false;
		private GameObject ui;
		public Camera camera;
		
		// Use this for initialization
		void Start ()
		{
				int slotAmount = 0;
				database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
				ui = GameObject.FindGameObjectWithTag ("UI");
			

				for (int y = 1; y < 6; y++) {

						for (int x = 1; x < 6; x++) {

								GameObject slot = (GameObject)Instantiate (slots);
								slot.GetComponent<SlotScript> ().slotNumber = slotAmount;
								allSlots.Add (slot);
								allItems.Add (new Item ());
								slot.transform.SetParent (this.transform, false);
								slot.GetComponent<RectTransform> ().localPosition = new Vector3 (slotX, slotY, 0);
								slot.name = "Slot" + y + "." + x;
								slotX += 55;
								if (x == 5) {
										slotY -= 55;
										slotX = -110;
								}
								slotAmount++;
						}
				}
				AddItem (0);
				AddItem (1);
				AddItem (2);
				Debug.Log (allItems [0].itemName);
				Debug.Log (allItems [1].itemName);
				Debug.Log (allItems [2].itemName);
		}

	public void Update() 
	{
		RectTransform uiRecttransform = ui.GetComponent<RectTransform>();
		float uiScale = ui.GetComponent<CanvasScaler>().scaleFactor;

		if (draggingItem) {

						//to do: allign x/y pos of draggedItem with cursor.
		
						Vector3 mousePos = Input.mousePosition;
						mousePos.x -= ((uiRecttransform.rect.width * uiScale)/2);
						mousePos.y -= ((uiRecttransform.rect.height * uiScale)/2);
						Vector3 output;
						RectTransformUtility.ScreenPointToWorldPointInRectangle(uiRecttransform, mousePos, camera, out output);
						draggedItem.GetComponent<RectTransform>().localPosition = output;

				}

		}

		public void ShowTooltip (Vector3 toolPosition, Item item)
		{
				tooltip.SetActive (true);
				tooltip.GetComponent<RectTransform> ().localPosition = new Vector3 (toolPosition.x + 250, toolPosition.y, toolPosition.z);
				tooltip.transform.GetChild (0).GetComponent<Text> ().text = item.itemName;
				tooltip.transform.GetChild (2).GetComponent<Text> ().text = item.itemDescription;
		}
	
		public void ShowDraggedItem (Item item)
		{
				draggedItem.SetActive (true);
				draggedItem.GetComponent<Image> ().sprite = item.itemIcon;
				draggingItem = true;
		
		}
	
		public void HideTooltip ()
		{
				tooltip.SetActive (false);
		}

		void AddItem (int id)
		{

				for (int i = 0; i < database.items.Count; i++) {

						if (database.items [i].itemID == id) {
								Item item = database.items [i];
								AddToEmptySlot (item);
								break;

						}
		
				}

		}

		void AddToEmptySlot (Item item)
		{
				for (int i = 0; i < allItems.Count; i++) {

						if (allItems [i].itemName == null) {
								allItems [i] = item;
								break;

						}

				}
		}
}
