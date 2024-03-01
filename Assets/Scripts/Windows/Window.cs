using UnityEngine;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Window : MonoBehaviour
{
	[SerializeField] protected bool isShowOnStart = false;

	protected CanvasGroup _group;
	protected bool _isVisible = false;
	protected WindowsController _controller;
	[Inject]
	public void Init(WindowsController controller)
	{
		controller.WindowsList.Add(this);
		_controller = controller;
	}

	public virtual CanvasGroup Group
	{
		get
		{
			if (_group == null)
			{
				_group = GetComponent<CanvasGroup>();
			}

			return _group;
		}
	}

	public virtual bool IsVisible
	{
		get => _isVisible;
		set
		{
			_isVisible = value;
			SetVisible(value);
		}
	}

	protected virtual void OnEnable()
	{
		IsVisible = isShowOnStart;
	}

	protected virtual void OnDisable()
	{
		Hide();
	}

	protected virtual void SetVisible(bool isVisible)
	{
		Group.alpha = isVisible ? 1 : 0;
		Group.blocksRaycasts = isVisible;
		Group.interactable = isVisible;
	}

	public virtual void Show()
	{
		IsVisible = true;
	}

	public virtual void Hide()
	{
		IsVisible = false;
	}

	public virtual void ShowWithController()
	{
		_controller.WindowsList.ForEach(win => win.Hide());
		Show();
	}
}