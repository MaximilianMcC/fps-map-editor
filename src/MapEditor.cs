using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

class MapEditor
{
	public void Run()
	{
		// Make the RayLib window
		Raylib.InitWindow(960, 720, "m 3");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

		// Set the ImGUI theme
		rlImGui.Setup(true);

		// Main loop
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}

		// Cleanup
		rlImGui.Shutdown();
		Raylib.CloseWindow();
	}

	private void Update()
	{
		
	}

	private void Render()
	{
		// Begin RayLib 2D drawing
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		Raylib.DrawText("map edior ", 10, 10, 30, Color.WHITE);

		// ImGUI
		rlImGui.Begin();
		ImGui.ShowDemoWindow();

		// End drawing
		rlImGui.End();
		Raylib.EndDrawing();
	}
}