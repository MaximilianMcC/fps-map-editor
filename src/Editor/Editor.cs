using System.Numerics;
using Raylib_cs;

class Editor
{
	private static Camera3D camera;
	private static bool cameraMovement = true;

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
		Raylib.EndMode3D();

		// Draw 2D stuff
		LeftPanel.Draw();
		RightPanel.Draw();

		// Draw camera info
		Raylib.DrawText($"{Raylib.GetFPS()} fps\n{camera.position}", (int)LeftPanel.WIDTH + 10, 10, 30, Ui.Colors.Text);
	}
}