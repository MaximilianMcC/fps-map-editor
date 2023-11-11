using Raylib_cs;

class TextInput : UIElement
{
	public string Title { get; set; }
	public string Text { get; set; }

	// Typing stuff
	private int fontSize = 30;
	private int caretIndex = 0;
	private float caretX = 0;

	// Blinking caret stuff
	private const double caretBlinkTimeSeconds = 0.53;
	private bool caretShown = true;
	private double lastTimeCaretBlinked = Raylib.GetTime();

	public TextInput(string title)
	{
		// Assign values
		Title = title;
		Text = "";
	}

	public override void Update()
	{
		// Check for what they are doing
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
		{
			// Remove a character before caret
			if (caretIndex < 0) return;
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
		caretX = Raylib.MeasureTextEx(Raylib.GetFontDefault(), Text.Substring(0, caretIndex), fontSize, (fontSize / 10)).X;
		if (caretX < 0) caretX = 0;
	}

	public override void Render(int x, int y)
	{
		// Draw the text
		// TODO: Place relative to the window
		Raylib.DrawText(Text, 0, 0, fontSize, Color.BLACK);

		// Check for if we are allowed to draw the blinking caret
		double currentTime = Raylib.GetTime();
		double elapsedTime = currentTime - lastTimeCaretBlinked;
		if (elapsedTime > caretBlinkTimeSeconds)
		{
			caretShown = !caretShown;
			lastTimeCaretBlinked = currentTime;
		}

		// Draw the blinking caret
		if (caretShown)
		{
			Rectangle caret = new Rectangle(caretX, 0, 3, fontSize);
			Raylib.DrawRectangleRec(caret, Color.BEIGE);
		}

	}
}
