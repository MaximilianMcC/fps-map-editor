using Raylib_cs;

class MapEditor
{
	private bool previewEnabled;

	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(1440, 1080, "Map editor");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

		// Main loop
		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}

		// Cleanup
		Raylib.CloseWindow();
	}

	private void Start()
	{
		Preview.Start();
	}

	private void Update()
	{
		// Switch between map editor and obj preview with 'p'
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_P)) previewEnabled = !previewEnabled;
		if (previewEnabled) Preview.Update();
		else Editor.Update();
	}

	private void Render()
	{
		// Begin RayLib 2D drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		if (previewEnabled) Preview.Render();
		else Editor.Render();

		Raylib.EndDrawing();
	}

}