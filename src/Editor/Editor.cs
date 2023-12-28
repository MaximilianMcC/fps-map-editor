using System.Numerics;
using Raylib_cs;

class Editor
{

	private static Camera3D camera;
	private static bool cameraMovement = true;

	public static List<Placeable> Placeables { get; set; }
	public static Placeable SelectedThing = null; // TODO: Make custom getter that returns it based on index list

	public static void Start()
	{
		camera = new Camera3D()
		{
			position = Vector3.UnitY,
			target = Vector3.One,
			up = Vector3.UnitY,
			fovy = 60,
			projection = CameraProjection.CAMERA_PERSPECTIVE
		};
		Raylib.DisableCursor();

		LeftPanel.Start();
		RightPanel.Start();

		// Load in all of the models
		// TODO: Do this somewhere else
		Placeables = new List<Placeable>();
		string[] modelPaths = Directory.GetFiles("./map-assets/models", "*.obj");
		foreach (string modelPath in modelPaths)
		{
			Placeable placeable = new Placeable(modelPath);
			Placeables.Add(placeable);
		}
		if (Placeables.Count > 1) SelectedThing = Placeables[0];
		Console.WriteLine(SelectedThing);
	}

	public static void Update()
	{
		// Update camera
		if (!cameraMovement) Raylib.UpdateCamera(ref camera, CameraMode.CAMERA_FIRST_PERSON);
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
		{
			cameraMovement = !cameraMovement;
			if (cameraMovement) Raylib.EnableCursor();
			else Raylib.DisableCursor();
		}

		// Update panels
		LeftPanel.Update();
		RightPanel.Update();
	}

	public static void Render()
	{
		Raylib.BeginMode3D(camera);

		// Draw 3D stuff
		Raylib.DrawGrid(10, 1);
		SelectedThing.Render();
		Raylib.EndMode3D();

		// Draw 2D stuff
		LeftPanel.Draw();
		RightPanel.Draw();

		// Draw camera info
		Raylib.DrawText($"{Raylib.GetFPS()} fps\n{camera.position}", (int)LeftPanel.WIDTH + 10, 10, 30, Ui.Colors.Text);
	}
}