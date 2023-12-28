using Raylib_cs;

class MapEditor
{
	private bool previewEnabled;

	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(1440, 1080, "Map editor version 26 or something i forgot");
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

	}

	private void Update()
	{

	}

	private void Render()
	{
		// Begin RayLib drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		

		Raylib.EndDrawing();
	}

}