using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MoneyAddUI : MonoBehaviour
{
	private Button _button;
	[Inject] private IMoney _money;
	[Inject] private IDifferenceSettings _difSettings;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_button.onClick.RemoveAllListeners();
		_button.onClick.AddListener(AddMoney);
	}

	public void AddMoney()
	{
		_money.AddMoney(_difSettings.GetValue());
	}

}