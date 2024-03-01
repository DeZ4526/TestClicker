using System.Collections.Generic;
using UnityEngine;

public class ShopUI : Window
{
	[SerializeField] private ShopItemUI itemUI;
	[SerializeField] private ShopController shopController;

	[SerializeField] private Transform shopItemsContainer;

	private List<ShopItemUI> _itemsUI = new();
	
	public void Init()
	{
		_itemsUI.ForEach(i => Destroy(i.gameObject));
		_itemsUI.Clear();

		foreach (var item in shopController.Items)
		{
			var itemobj = Instantiate(itemUI, shopItemsContainer);
			itemobj.Init(item, this);
			_itemsUI.Add(itemobj);
		}
	}

	public void Buy(ShopItem item)
	{
		shopController.Buy(item);
		Hide();
	}
	public override void ShowWithController()
	{
		base.ShowWithController();
		Init();
	}
}
