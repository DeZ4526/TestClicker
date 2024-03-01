using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
	[SerializeField] private TMP_Text titleText;
	[SerializeField] private TMP_Text priceText;
	[SerializeField] private Button buyButton;
	[SerializeField] private Image Ico;
	private ShopUI _shopUI;
	private ShopItem _item;

	public void Init(ShopItem item, ShopUI shopUI)
	{
		_shopUI = shopUI;
		_item = item;
		buyButton.interactable = !item.IsBuy;
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(Buy);
		titleText.text = item.Title;
		priceText.text = item.Price.ToString();
		Ico.sprite = item.Ico;
	}
	private void Buy()
		=> _shopUI.Buy(_item);
}
