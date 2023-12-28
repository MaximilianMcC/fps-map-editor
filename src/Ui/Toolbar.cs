using System.Numerics;
using Raylib_cs;

class Toolbar
{
	// TODO: Make customizable by dragging out or something
	public const float Width = 75f;
	private static float Height = Raylib.GetScreenHeight();



	public static void Start()
	{
		
	}

	public static void Update()
	{
		// Update the height
		Height = Raylib.GetScreenHeight();
	}

	public static void Render()
	{
		// Draw the background and a border on the right of it
		Raylib.DrawRectangleRec(new Rectangle(0, 0, Width, Height), Ui.WindowBackgroundColor);
		Raylib.DrawLineEx(new Vector2(Width, 0), new Vector2(Width, Height), 5f, Ui.WindowOutlineColor);
	}
}