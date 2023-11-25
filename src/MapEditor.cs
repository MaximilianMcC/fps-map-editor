using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

class MapEditor
{
	private Map map;

	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(1440, 1080, "m 3");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);


		//! debug
		map = new Map("./test.map");
		Editor.LoadMap(map);


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
		// Editor.Update();
		Preview.Update();
	}

	private void Render()
	{
		// Begin RayLib 2D drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		// Editor.Render();
		Preview.Render();

		Raylib.EndDrawing();
	}

}