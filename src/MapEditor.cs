using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

class MapEditor
{
	private Map map;

	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(960, 720, "m 3");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);


		//! debug
		map = new Map("./test.map");
		Editor.LoadMap(map);


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
		Editor.Update();
	}

	private void Render()
	{
		// Begin RayLib 2D drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		// 3D stuff
		Raylib.BeginMode3D(Editor.Camera);
		Editor.Render3D();
		Raylib.EndMode3D();

		// 2D stuff
		Editor.Render2D();


		Raylib.EndDrawing();
	}

}