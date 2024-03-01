using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
	public List<Window> WindowsList = new List<Window>();

	public bool IsOpen<T>() where T : Window
	{
		var window = WindowsList.Find(w => w.GetType() == typeof(T));
		return window != null
			? window.IsVisible
			: false;
	}

	public bool Show<T>() where T : Window
	{
		var window = WindowsList.Find(w => w.GetType() == typeof(T));
		window?.Show();
		return window != null;
	}

	public bool Hide<T>() where T : Window
	{
		var window = WindowsList.Find(w => w.GetType() == typeof(T));

		window?.Hide();
		return window != null;
	}
}
