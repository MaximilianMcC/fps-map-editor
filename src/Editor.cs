using System.Net;
using Raylib_cs;

class Editor
{
	public static List<Window> Windows { get; set; }

	public void Run()
	{
		// Setup the Raylib window
		Raylib.InitWindow(1280, 720, "m");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(60);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

		// Store all of the windows
		Windows = new List<Window>();

		// Main program loop
		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}
		
		// Close window when done
		Raylib.CloseWindow();
	}


	private void Start()
	{
		// Register all shortcuts
		ShortcutManager.AddShortcut(() => new CreateNewMap(), KeyboardKey.KEY_LEFT_CONTROL, KeyboardKey.KEY_N);
	}

	private void Update()
	{
		// Update all of the shortcuts
		ShortcutManager.Listen();

		// Update all the windows
		for (int i = 0; i < Windows.Count; i++) Windows[i].Update();
	}

	private void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);


		// Draw all the windows
		for (int i = 0; i < Windows.Count; i++) Windows[i].Render();



		Raylib.EndDrawing();
	}
}