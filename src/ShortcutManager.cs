using Raylib_cs;

class ShortcutManager
{
	private static Dictionary<KeyboardKey[], Action> shortcuts = new Dictionary<KeyboardKey[], Action>();
	
	// Add a new shortcut. Shortcut format is like this:
	// "CTRL+C", "CTRL+SHIFT+S". No spaces
	public static void AddShortcut(Action method, params KeyboardKey[] shortcutKeys)
	{
		shortcuts.Add(shortcutKeys, method);
	}



	// Handle all shortcuts
	public static void Listen()
	{
		foreach (KeyValuePair<KeyboardKey[], Action> shortcut in shortcuts)
		{
			bool[] pressedKeys = new bool[shortcut.Key.Length];

			// Check for if the current shortcut keys are being pressed
			for (int i = 0; i < shortcut.Key.Length; i++)
			{
				KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
				if (key != KeyboardKey.KEY_NULL)
				{
					Console.WriteLine(key);
					pressedKeys[i] = (key == shortcut.Key[i]);
				}

			}

			// Check for if all of the keys necessary were pressed, then
			// run the attached method
			if (pressedKeys.All(element => element))
			{
				Console.WriteLine("runnig");
				shortcut.Value.Invoke();
			}
		}
	}
}