using System.Numerics;
using Raylib_cs;

class PropertiesPanel
{
	public MapElement SelectedItem { get; set; } = null;

	// Positional stuff
	public const int Width = 350;
	public const int FontSize = 25;
	private const int Padding = 10;
	private const int Padding2 = Padding * 2;

	// Drawing stuff
	private string title;

	public PropertiesPanel()
	{
		
	}


	public void Update()
	{
		// Show editor settings if no map element is selected
		if (SelectedItem == null)
		{
			title = "Editor Settings";
		}
	}
	

	public void Draw()
	{
		// Positional stuff
		int beginX = Raylib.GetScreenWidth() - Width;
		int x, y = 0;

		// Draw the background and a border
		Raylib.DrawRectangle(beginX, 0, Width, Raylib.GetScreenHeight(), Colors.Background);
		Raylib.DrawRectangle(beginX - 5, 0, 5, Raylib.GetScreenHeight(), Colors.BackgroundTertiary);

		// Draw the title and a line under it
		y += Padding;
		Raylib.DrawText(title, beginX + Padding, y, FontSize, Colors.Text);
		y += FontSize + Padding;
		Raylib.DrawLineEx(new Vector2(beginX, y), new Vector2(Raylib.GetScreenWidth(), y), 2f, Colors.BackgroundTertiary);
		y += Padding;


	}
}