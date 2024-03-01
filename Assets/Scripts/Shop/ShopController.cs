using UnityEngine;
using Zenject;

public class ShopController : MonoBehaviour
{
	[Inject] private IMoney _money;
	[SerializeField] private ShopItem[] items;

	public ShopItem[] Items { get => items; }

	public bool Buy(ShopItem item)
	{
		if(_money.GetMoney() >= item.Price)
		{
			_money.WithdrawMoney(item.Price);
			item.Buy();
			
			return true;
		}
		return false;
	}
}
