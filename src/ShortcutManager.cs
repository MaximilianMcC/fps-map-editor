using Raylib_cs;

class ShortcutManager
{
	private static Dictionary<KeyboardKey[], Action> shortcuts = new Dictionary<KeyboardKey[], Action>();
	private static Dictionary<KeyboardKey[], bool> shortcutTriggered = new Dictionary<KeyboardKey[], bool>();

	// Add a new shortcut
	public static void AddShortcut(Action method, params KeyboardKey[] shortcutKeys)
	{
		shortcuts.Add(shortcutKeys, method);
		shortcutTriggered.Add(shortcutKeys, false);
	}

	// Handle all shortcuts
	public static void Listen()
	{
		foreach (KeyValuePair<KeyboardKey[], Action> shortcut in shortcuts)
		{
			// Check for if the current shortcut keys are being pressed
			int pressedKeys = 0;
			for (int i = 0; i < shortcut.Key.Length; i++)
			{
				if (Raylib.IsKeyDown(shortcut.Key[i])) pressedKeys++;
			}

			// Check for if all of the keys necessary were pressed, then
			// run the attached method
			if (pressedKeys == shortcut.Key.Length)
			{
				// Only trigger the action if it hasn't been triggered yet
				if (!shortcutTriggered[shortcut.Key])
				{
					shortcut.Value.Invoke();
					shortcutTriggered[shortcut.Key] = true;
				}
			}
			else
			{
				// Reset the flag when the keys are released
				shortcutTriggered[shortcut.Key] = false;
			}
		}
	}



}