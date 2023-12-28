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
		// Load all the assets and whatnot
		Ui.Init("./assets/");

		// Editor.Start();
		// Preview.Start();
		WallBuilder.Start();
	}

	private void Update()
	{
		// Switch between map editor and obj preview with 'p'
		// if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
		// {
		// 	previewEnabled = !previewEnabled;

		// 	// Change the window title
		// 	if (previewEnabled) Raylib.SetWindowTitle("Map editor (obj preview)");
		// 	else Raylib.SetWindowTitle("Map editor");
		// }

		// // Update either the editor or preview
		// if (previewEnabled) Preview.Update();
		// else Editor.Update();
		WallBuilder.Update();
	}

	private void Render()
	{
		// Begin RayLib drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		// if (previewEnabled) Preview.Render();
		// else Editor.Render();
		WallBuilder.Render();

		Raylib.EndDrawing();
	}

}