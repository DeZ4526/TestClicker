using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Zenject.SpaceFighter;

public class WheelFortuneWindow : Window
{

	[SerializeField] private Image[] images = new Image[4];
	[SerializeField] private RectTransform whell;
	[SerializeField] private int price;
	
	[Inject] private IMoney _money;
	[Inject] private ShopController _shopController;
	
	private List<ShopItem> _shopItems;
	private float _timer;
	public bool InitFortune()
	{
		_shopItems = GetItems();
		if(images.Length == 4)
		{
			for (int i = 0; i < 4; i++)
			{
				images[i].sprite = _shopItems.Count > i ? _shopItems[i].Ico : null;
			}
			return true;
		}
		return false;
	}
	private void Update()
	{
		if (_timer > 0)
		{
			whell.Rotate(0, 0, _timer * Time.deltaTime * 10);
			_timer -= Time.deltaTime;
			if(_timer <= 0)
			{
				var z = whell.rotation.eulerAngles.z;

				if((z < 45 || z > 315 || z == 315) && _shopItems.Count > 1)
				{
					_shopItems[1].Buy();
				}
				else if ((z > 45 && z < 135 || z == 45) && _shopItems.Count > 2)
				{
					_shopItems[2].Buy();
				}
				else if ((z > 135 && z < 225 || z == 135) && _shopItems.Count > 3)
				{
					_shopItems[3].Buy();
				}
				else if ((z > 225 && z < 315 || z == 225) && _shopItems.Count > 4)
				{
					_shopItems[4].Buy();
				}
				StartCoroutine(HideWindow());
			}
		}
	}
	IEnumerator HideWindow()
	{
		yield return new WaitForSeconds(2);
		Hide();
	}
	public override void Show()
	{
		if (InitFortune() && _money.GetMoney() >= price)
		{
			_money.WithdrawMoney(price);
			base.Show();
			_timer = Random.Range(10, 20);
		}
	}

	private List<ShopItem> GetItems()
	{
		List<ShopItem> items = new List<ShopItem>();
		foreach (var item in _shopController.Items)
		{
			if (!item.IsBuy)
			{
				items.Add(item);
			}
		}
		return items;
	}
}
