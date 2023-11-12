using Raylib_cs;

// TODO: Need to click into box to select/type
// TODO: Add I beam mouse cursor
// TODO: Add highlighting
// TODO: Add moving with ctrl
// TODO: Add copy/paste functionality 

class TextInput : UIElement
{
	public string Title { get; set; }
	public string Text { get; set; }

	// Typing stuff
	private int caretIndex = 0;
	private float caretX = 0;

	// Blinking caret stuff
	private const double caretBlinkTimeSeconds = 0.53;
	private bool caretShown = true;
	private double lastTimeCaretBlinked = Raylib.GetTime();

	// Positional spacing stuff
	private const int padding = 10;
	private const int padding2 = padding * 2;

	public TextInput(string title)
	{
		// Assign values
		Title = title;
		Text = "";

		// Set the height
		Height = padding + FontSize + padding + FontSize + padding2 + padding;
	}

	public override void Update(int anchorX, int anchorY, int parentWidth)
	{
		// Update X, Y, and Width
		base.Update(anchorX, anchorY, parentWidth);

		UpdateInput();
		UpdateCaretBlinking();
	}

	public override void Render()
	{
		int x, y;

		// Draw the title/header
		x = X;
		y = Y;
		Raylib.DrawText(Title, x, y, FontSize, Colors.Text);

		// Draw the text box
		y += FontSize + padding;
		Raylib.DrawRectangle(x, y, Width, FontSize + padding2, Colors.ElementBackground);
		Raylib.DrawRectangleLines(x, y, Width, FontSize + padding2, Colors.ElementOutline);

		// Draw the text
		y += padding;
		Raylib.DrawText(Text, x + padding, y, FontSize, Colors.Text);

		// Draw the blinking caret
		if (caretShown)
		{
			x += padding;
			Rectangle caret = new Rectangle(x + caretX, y, 3, FontSize);
			Raylib.DrawRectangleRec(caret, Colors.SecondaryText);
		}
	}

	// Actually type and stuff
	private void UpdateInput()
	{
		// Check for what they are doing
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
		{
			// Remove a character before caret
			if (caretIndex <= 0) return;
				Text = Text.Remove(caretIndex - 1, 1);
			caretIndex--;
		}
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DELETE))
		{
			// Remove a character in front of caret
			if (caretIndex >= Text.Length) return;
			Text = Text.Remove(caretIndex, 1);
		}
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
		{
			// Move the caret backwards to the left
			caretIndex--;
			if (caretIndex < 0) caretIndex = 0;
		}
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
		{
			// Move the caret forwards to the right
			caretIndex++;
			if (caretIndex > Text.Length) caretIndex = Text.Length;
		}
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_END))
		{
			// Go to the end of the input
			caretIndex = Text.Length;
		}
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
		{
			// Go to the beginning of the input
			caretIndex = 0;
		}
		else
		{
			// Get keyboard input for normal keys
			int inputKeycode = Raylib.GetCharPressed();
			if (inputKeycode == 0) return;
			
			// Add the new character to the text
			string input = char.ConvertFromUtf32(inputKeycode);
			Text = Text.Insert(caretIndex, input);
			caretIndex++;
		}

		// Update the caret position
		caretX = Raylib.MeasureTextEx(Raylib.GetFontDefault(), Text.Substring(0, caretIndex), FontSize, (FontSize / 10)).X;
		if (caretX < 0) caretX = 0;
	}

	// Make the caret blink
	private void UpdateCaretBlinking()
	{
		// Check for if we are allowed to draw the blinking caret
		double currentTime = Raylib.GetTime();
		double elapsedTime = currentTime - lastTimeCaretBlinked;
		if (elapsedTime > caretBlinkTimeSeconds)
		{
			caretShown = !caretShown;
			lastTimeCaretBlinked = currentTime;
		}
	}
}
