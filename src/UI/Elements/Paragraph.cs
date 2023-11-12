using Raylib_cs;

class Paragraph : UIElement
{
	public string Text { get; set; } = "";

	public Paragraph(string text)
	{
		// Apply values
		Text = text;

		// Set the height
		Height = FontSize;
	}

	public Paragraph()
	{
		// Set the height
		Height = FontSize;
	}

    public override void Update(int anchorX, int anchorY, int parentWidth)
    {
		// Update the positional values
        base.Update(anchorX, anchorY, parentWidth);
    }

    public override void Render()
    {
        // Draw the text
		Raylib.DrawText(Text, X, Y, FontSize, Colors.Text);
    }
}