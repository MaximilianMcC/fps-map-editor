using Raylib_cs;

class Button : UIElement
{
	public string Text { get; set; }

	private Rectangle button;
	private Action onPressed;

	// Positional spacing stuff
	private const int padding = 10;
	private const int padding2 = padding * 2;
	private int textX = 0;


	public Button(string text, Action runWhenPressed)
	{
		// Assign values
		Text = text;
		onPressed = runWhenPressed;

		// Set the height
		Height = FontSize + padding2;
	}

    public override void Update(int anchorX, int anchorY, int parentWidth)
    {
		// Update X, Y, and Width
		base.Update(anchorX, anchorY, parentWidth);

		// Make the buttons rectangle
		button = new Rectangle(X, Y, Width, Height);

		// Check for if its hovered over
		if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button))
		{
			// Change the cursor to the hand clicky one
			Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_POINTING_HAND);

			// Check for if the user clicks
			if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
			{
				// Run the method
				onPressed.Invoke();
			}
		}
		
		else Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_DEFAULT);

		// Update the text X position
		textX = (int)(Width - Raylib.MeasureTextEx(Raylib.GetFontDefault(), Text, FontSize, (FontSize / 10)).X) / 2;
    }

	public override void Render()
	{
		// Draw the button background
		Raylib.DrawRectangleRec(button, Colors.ElementBackground);
		Raylib.DrawRectangleLinesEx(button, 5, Colors.ElementOutline);

		// Draw the button text
		Raylib.DrawText(Text, X + textX, Y + padding, FontSize, Colors.Text);
	}
}