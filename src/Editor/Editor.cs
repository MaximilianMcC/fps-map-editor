using System.Numerics;
using Raylib_cs;

class Editor
{
	public static Map Map { get; private set; }

	// Layout stuff
	private static Grid Grid;
	private static Toolbar Toolbar;
	private static PropertiesPanel PropertiesPanel;

	// Camera settings
	public static Vector2 CameraPosition = Vector2.Zero;
	public static float CameraZoom = 1f;
	private const float zoomMultiplier = 0.1f;
	private const float cameraSpeed = 150f;

	public static void LoadMap(Map map)
	{
		Map = map;

		// Tools
		// TODO: Load different tools depending on the map
		Tool[] tools = new Tool[]
		{
			new Tool("Move", "Move stuff", "./assets/icon/move.png", KeyboardKey.KEY_V),
			new Tool("Vertex Selection", "Move stuff", "./assets/icon/move.png", KeyboardKey.KEY_ONE),
			new Tool("Edge Selection", "Move stuff", "./assets/icon/move.png", KeyboardKey.KEY_TWO),
			new Tool("Face selection", "Move stuff", "./assets/icon/move.png", KeyboardKey.KEY_THREE)
		};

		// Layout stuff
		Grid = new Grid(50, 1f, Color.WHITE);
		Toolbar = new Toolbar(tools);
		PropertiesPanel = new PropertiesPanel();
	}

	public static void Update()
	{
		// Reload the map if press F5
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5)) Map.Reload();

		// Camera
		MoveCamera();

		// UI
		Toolbar.Update();
		PropertiesPanel.Update();
	}


	public static void Render()
	{
		// Draw the actual editor
		Grid.Draw();

		// Draw the toolbar (left thingy)
		Toolbar.Draw();

		// Draw the properties (right thing)
		PropertiesPanel.Draw();


		// Random garbage
		Raylib.DrawText($"{Raylib.GetFPS()} fps", 120, 10, 30, Color.BLACK);
		Raylib.DrawText($"editijng \"{Map.Name}\" v{Map.Version}", 120, 50, 30, Color.BLACK);
	}



	private static void MoveCamera()
	{
		// Check for if they want to move around
		// TODO: Also add mouse support
		// TODO: Maybe copy photoshop controls with the ctrl+alt+mouse thingy
		{
			float movement = cameraSpeed * Raylib.GetFrameTime();
			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) CameraPosition.X -= movement;
			if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) CameraPosition.X += movement;
			if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) CameraPosition.Y -= movement;
			if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) CameraPosition.Y += movement;
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