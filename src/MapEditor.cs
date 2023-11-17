using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

class MapEditor
{
	// TODO: Put this in another class or something
	private string mapName = "";
	private string mapPath = "";

	private Map map;

	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(960, 720, "m 3");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);


		//! debug
		Map map = new Map("./test.map");


		// Main loop
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}

		// Cleanup
		Raylib.CloseWindow();
	}

	private void Update()
	{
		// TODO: Make ImGUI dialogue stuff
	}

	private void Render()
	{
		// Begin RayLib 2D drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		Raylib.DrawText("map edior ", 10, 10, 30, Color.WHITE);

		Raylib.EndDrawing();
	}

}