using System.Numerics;
using Raylib_cs;

class Editor
{
	public static Map Map { get; private set; }
	private static Grid Grid = new Grid(50, 2, Color.WHITE);

	// Camera settings
	public static Vector2 CameraPosition = Vector2.Zero;
	public static float CameraZoom = 1f;
	private const float zoomMultiplier = 0.1f;

	public static void LoadMap(Map map)
	{
		Map = map;
	}

	public static void Update()
	{
		// Reload the map if press F5
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5)) Map.Reload();

		MoveCamera();
	}


	public static void Render()
	{
		// Draw the actual editor
		Grid.Draw();

		// Draw the toolbar (left thingy)

		// Draw the properties (right thing)


		// Random garbage
		Raylib.DrawText($"{Raylib.GetFPS()} fps", 10, 10, 30, Color.BLACK);
		Raylib.DrawText($"editijng \"{Map.Name}\" v{Map.Version}", 10, 50, 30, Color.BLACK);
	}



	private static void MoveCamera()
	{
		// Check for if they want to move around
		// TODO: Also add mouse support
		// TODO: Maybe copy photoshop controls with the ctrl+alt+mouse thingy
		{
			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
			{

			}
		}

		// Check for if they want to zoom in
		// TODO: Display zoom level somewhere
		// TODO: Maybe copy photoshop controls with the ctrl+alt+mouse thingy
		{
			// Increase zoom
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ADD) || Raylib.IsKeyPressed(KeyboardKey.KEY_EQUAL) || Raylib.GetMouseWheelMove() == 1)
			{
				CameraZoom += zoomMultiplier;
				Console.WriteLine($"{CameraZoom}x zoom");
			}

			// Decrease zoom
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_SUBTRACT) || Raylib.IsKeyPressed(KeyboardKey.KEY_MINUS) || Raylib.GetMouseWheelMove() == -1)
			{
				CameraZoom -= zoomMultiplier;
				Console.WriteLine($"{CameraZoom}x zoom");
			}
		}
	}
}




struct Grid
{
	public float Size { get; set; } = 10f;
	public float Thickness { get; set; } = 1f;
	public Color Color { get; set; } = Color.WHITE;

	public Grid(float size, float lineThickness, Color color)
	{
		// Assign variables
		Size = size;
		Thickness = lineThickness;
		Color = color;
	}

	// TODO: Make it so that it can be zoomed and moved
	// TODO: I think RayLib has fancy 2D camera to do it all for me
	public void Draw()
	{
		// Change size according to zoom
		float size = Size;
		if (Editor.CameraZoom != 0) size = Size * Editor.CameraZoom;

		// Get how many rows and columns
		//! Rows and Columns might be reversed (idk)
		//? 1 is added to make sure everything is always a square
		// TODO: Use modulo (%) to try and remove the +1 part
		int rows = (int)(Raylib.GetScreenHeight() / (size) + 1);
		int columns = (int)(Raylib.GetScreenWidth() / (size) + 1);

		// Horizontal
		// TODO: Try do in a single for loop
		for (int i = 0; i < columns; i++)
		{
			// Get the start and end positions
			Vector2 start = new Vector2(i * size, 0);
			Vector2 end = new Vector2(i * size, Raylib.GetScreenHeight());

			// Draw the line
			Raylib.DrawLineEx(start, end, Thickness, Color);
		}

		// Vertical
		// TODO: Try do in a single for loop
		for (int i = 0; i < rows; i++)
		{
			// Get the start and end positions
			Vector2 start = new Vector2(0, i * size);
			Vector2 end = new Vector2(Raylib.GetScreenWidth(), i * size);

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