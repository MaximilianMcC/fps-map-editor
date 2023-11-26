using System.Numerics;
using Raylib_cs;

class Preview
{
	private const string objPath = "./preview.obj";
	private static Model model;

	private static DateTime lastModified;
	
	private static Camera3D camera;
	private static bool paused = false;

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
	}

	public static void Update()
	{
		// Update camera
		if (!paused) Raylib.UpdateCamera(ref camera, CameraMode.CAMERA_FIRST_PERSON);
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
		{
			paused = !paused;
			if (paused) Raylib.EnableCursor();
			else Raylib.DisableCursor();
		}

		// Check for if the OBJ file has been saved
		// If it has then reload the model
		DateTime currentModified = File.GetLastWriteTime(objPath);
		if (currentModified > lastModified)
		{
			// Update the obj file
			Console.WriteLine("File saved. Updating OBJ model");
			lastModified = currentModified;

			// Unload the old model, then load the new one
			Raylib.UnloadModel(model);
			model = Raylib.LoadModel(objPath);

			Console.WriteLine("Updated model\n");
		}

	}

	public static void Render()
	{
		Raylib.BeginMode3D(camera);
		Raylib.DrawGrid(10, 1);
		Raylib.DrawModel(model, new Vector3(0f, 0.5f, 0f), 1f, Color.WHITE);
		Raylib.DrawModelWires(model, new Vector3(0f, 0.5f, 0f), 1f, Color.RED);
		Raylib.EndMode3D();

		Raylib.DrawText("Obj preview live", 10, 10, 30, Color.WHITE);
		Raylib.DrawText($"{camera.position}", 10, 40, 30, Color.WHITE);
		Raylib.DrawText($"{Raylib.GetFPS()} FPS", 10, 80, 30, Color.WHITE);
	}
}