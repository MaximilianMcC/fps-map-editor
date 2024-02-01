using System.Numerics;
using Raylib_cs;

class MapEditor
{
	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(1440, 1080, "making the ");
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
		Viewer.Start();
	}

	private void Update()
	{
		Viewer.Update();
	}

	private void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);
		Raylib.BeginMode3D(Viewer.Camera);

		

		Raylib.EndMode3D();
		Raylib.DrawText("Hello wofld.", 10, 10, 30, Color.WHITE);
		Raylib.EndDrawing();
	}

}