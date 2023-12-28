using Raylib_cs;

class MapEditor
{
	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(1440, 1080, "Map editor version 26 or something i forgot (restarting)");
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
		Editor.Start();
		Ui.Start();
	}

	private void Update()
	{
		Editor.Update();
		Ui.Update();
	}

	private void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);



		Editor.Render();
		Ui.Render();



		Raylib.EndDrawing();
	}

}