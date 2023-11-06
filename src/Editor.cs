using Raylib_cs;

class Editor
{
	public void Run()
	{
		// Setup the Raylib window
		Raylib.InitWindow(1920, 1080, "m");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

		// Main program loop
		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}
		
		// Close window when done
		Raylib.CloseWindow();
	}


	private void Start()
	{
		// Register all shortcuts
		ShortcutManager.AddShortcut(CreateNewMap, KeyboardKey.KEY_LEFT_CONTROL, KeyboardKey.KEY_N);
	}

	private void Update()
	{
		ShortcutManager.Listen();
	}

	private void Render()
	{
		Raylib.BeginDrawing();


		Raylib.DrawText("editing the map rn", 0, 0, 50, Color.BLUE);


		Raylib.EndDrawing();
	}










	// Create a new map
	private void CreateNewMap()
	{
		Console.WriteLine("Making new map rn");
	}
}