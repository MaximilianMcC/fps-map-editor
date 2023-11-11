using System.Net;
using Raylib_cs;

class Editor
{
	private List<Window> windows = new List<Window>();

	public void Run()
	{
		// Setup the Raylib window
		Raylib.InitWindow(1280, 720, "m");
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
		
		// Close window when done
		Raylib.CloseWindow();
	}


	private void Start()
	{
		// Register all shortcuts
		ShortcutManager.AddShortcut(CreateNewMap, KeyboardKey.KEY_LEFT_CONTROL, KeyboardKey.KEY_N);
	}

	private void Update()
	{
		// Update all of the shortcuts
		ShortcutManager.Listen();

		// Update all the windows
		for (int i = 0; i < windows.Count; i++) windows[i].Update();

	}

	private void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);


		// Draw all the windows
		for (int i = 0; i < windows.Count; i++) windows[i].Render();



		Raylib.EndDrawing();
	}










	// Create a new map
	private void CreateNewMap()
	{
		Console.WriteLine("Creating a new map");

		// Make a new window
		Window window = new Window("New map", 10, 10, 500, 600, true);
		windows.Add(window);

		// Add text input for getting the map name
		TextInput textInput = new TextInput("Map Name:");
		window.AddElement(textInput);

		// Add create button for actually making the map
		Button button = new Button("Create", Test);
		window.AddElement(button);
	}

	private void Test()
	{
		Console.WriteLine("Clicked");
	}
}