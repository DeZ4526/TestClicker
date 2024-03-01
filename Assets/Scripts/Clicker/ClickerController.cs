using UnityEngine;
using UnityEngine.Events;

public class ClickerController : MonoBehaviour, IMoney, IDifferenceSettings
{
	[SerializeField] private int money;
	private UnityEvent _onReload = new UnityEvent();
	private int _difValue = 1;
	public int Money 
	{ 
		get => money;
		set
		{
			money = value < 0 ? 0 : value;
			_onReload?.Invoke();
		}
	}

	public void AddMoney(int money)
		=> Money += money;

	public int GetMoney()
		=> money;

	public int GetValue()
		=> _difValue;

	public void OnMoneyReload(UnityAction onReload)
		=> _onReload.AddListener(onReload);

	public void SetMoney(int money)
		=> Money = money;

	public void SetValue(int value)
		=> _difValue = value;

	public void UpValue(int value)
	=> _difValue += value;

	public void WithdrawMoney(int money)
		=> Money -= money;

}
