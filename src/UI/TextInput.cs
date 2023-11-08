using Raylib_cs;

class TextInput : UIElement
{
	public string Title { get; set; }
	public string Text { get; set; }

	public TextInput(string title)
	{
		// Assign values
		Title = title;
	}

	public override void Update()
	{
		Console.WriteLine("tex t");
	}

	public override void Render()
	{
		Raylib.DrawCircle(30, 30, 10, Color.BLACK);
	}
}