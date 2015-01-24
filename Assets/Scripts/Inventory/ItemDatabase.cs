using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{

		public List<Item> items = new List<Item> ();

		// Use this for initialization
		void Start ()
		{

				items.Add (new Item ("Cog", 0, "A shiny cog, valuable to robots.", Item.ItemType.Currency, 1, 1));
				items.Add (new Item ("Wrench", 1, "A trusty wrench.", Item.ItemType.Weapon, 1, 1));
				items.Add (new Item ("Battery", 2, "A battery to charge things.", Item.ItemType.Consumable, 1, 1));
				Debug.Log (items.Count);
		}
}
	
