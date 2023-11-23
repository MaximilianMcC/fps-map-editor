using System.Numerics;
using Raylib_cs;

struct Grid
{
	public float Size { get; set; } = 10f;
	public float Thickness { get; set; } = 1f;
	public Color Color { get; set; } = Colors.Text;

	public Grid(float size, float lineThickness, Color color)
	{
		// Assign variables
		Size = size;
		Thickness = lineThickness;
		Color = color;
	}

	// TODO: Make it so that it can be zoomed and moved
	public void Draw()
	{
		// Change size according to zoom
		float size = Size;
		if (Editor.CameraZoom != 0) size = Size * Editor.CameraZoom;

		// Change the offset according to camera position
		Vector2 offset = new Vector2(Editor.CameraPosition.X % size, Editor.CameraPosition.Y % size);

		// Get how many rows and columns
		//! Rows and Columns might be reversed (idk)
		//? 5 is added to make sure everything is always a square
		// TODO: Use modulo (%) to try and remove the +1 part!
		int rows = (int)(Raylib.GetScreenHeight() / size) + 5;
		int columns = (int)(Raylib.GetScreenWidth() / size) + 5;

		// Horizontal
		// TODO: Try do in a single for loop
		for (int i = 0; i < columns; i++)
		{
			// Get the start and end positions
			Vector2 start = new Vector2((i * size) - offset.X, 0);
			Vector2 end = new Vector2((i * size) - offset.X, Raylib.GetScreenHeight());

			// Draw the line
			Raylib.DrawLineEx(start, end, Thickness, Color);
		}

		// Vertical
		// TODO: Try do in a single for loop
		for (int i = 0; i < rows; i++)
		{
			// Get the start and end positions
			Vector2 start = new Vector2(0, (i * size) - offset.Y);
			Vector2 end = new Vector2(Raylib.GetScreenWidth(), (i * size) - offset.Y);

			// Draw the line
			Raylib.DrawLineEx(start, end, Thickness, Color);
		}
	}

	public Vector2 GetClosestGridPoint(Vector2 position)
	{
		// 'snap' to grid
		return Vector2.Zero;
	}
}