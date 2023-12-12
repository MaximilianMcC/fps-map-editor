using System.Numerics;
using Raylib_cs;

class Editor
{
	private static Camera3D camera;
	private static bool paused;

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
	}

	public static void Render()
	{
		Raylib.BeginMode3D(camera);

		// Draw 3D stuff
		Raylib.DrawGrid(10, 1);
		Raylib.EndMode3D();

		// Draw 2D stuff
	}
}