using UnityEngine;
using System.Collections;

public class Item {
	
	public string itemName;
	public string itemDescription;
	public int itemID;
	public ItemType itemType;
	public int itemPower;
	public int itemSpeed;
	public Sprite itemIcon;
	public GameObject itemModel;

	public enum ItemType {
		Weapon,
		Consumable,
		Currency
	}

	public Item(string name, int id, string desc, ItemType type, int power, int speed)
	{
		itemName = name;
		itemID = id;
		itemDescription = desc;
		itemType = type;
		itemPower = power;
		itemSpeed = speed;
		itemIcon = Resources.Load<Sprite> ("" + name);
		}

	public Item()
	{

	}
}
