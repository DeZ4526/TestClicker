using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MoneyUI : MonoBehaviour
{
	private TMP_Text _text;
	[Inject]
	private IMoney _money;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
		Debug.Log(_money);
		OnReload();
		_money.OnMoneyReload(OnReload);
	}

	private void OnReload()
	{
		_text.text = _money.GetMoney().ToString();
	}

}
