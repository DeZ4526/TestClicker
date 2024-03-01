using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

[System.Serializable]
public class ShopItem
{
	[SerializeField] private string title;
	[SerializeField] private int price;
	[SerializeField] private Sprite ico;
	[SerializeField] private GameObject obj;
	[SerializeField] private UnityEvent onBuy;

	private bool _isBuy = false;

	public string Title { get => title;  }
	public int Price { get => price; }
	public GameObject Obj { get => obj; }
	public Sprite Ico { get => ico; }
	public bool IsBuy { get => _isBuy; }

	public void Buy()
	{
		Obj.SetActive(true);
		onBuy?.Invoke();
		_isBuy = true;
	}
}
