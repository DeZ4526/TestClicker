using UnityEngine.Events;

public interface IMoney
{
	void OnMoneyReload(UnityAction onReload);

	int GetMoney();
	void AddMoney(int money);
	void SetMoney(int money);
	void WithdrawMoney(int money);

}
