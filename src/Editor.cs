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
	}


	private void Start()
	{

	}

	private void Update()
	{

	}

	private void Render()
	{
		Raylib.BeginDrawing();


		Raylib.DrawText("editing the map rn", 0, 0, 50, Color.BLUE);


		Raylib.EndDrawing();
	}
}