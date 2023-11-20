using System.Numerics;
using Raylib_cs;

class Editor
{
	public static Map Map { get; private set; }
	public static Camera3D Camera;

	public static void LoadMap(Map map)
	{
		Map = map;

		// Make a camera
		Raylib.DisableCursor();
		Camera = new Camera3D()
		{
			position = Vector3.One,
			target = Vector3.UnitY,
			up = Vector3.UnitY,
			fovy = 60,
			projection = CameraProjection.CAMERA_PERSPECTIVE
		};
	}

	public static void Update()
	{
		Raylib.UpdateCamera(ref Camera, CameraMode.CAMERA_FIRST_PERSON);
	}

	public static void Render3D()
	{
		Raylib.DrawCube(Vector3.Zero, 1f, 1f, 1f, Color.BROWN);
	}

	public static void Render2D()
	{
		Raylib.DrawText($"editijng \"{Map.Name}\" rn", 10, 10, 30, Color.BLACK);
		Raylib.DrawText($"{Camera.position}", 10, 50, 30, Color.BLACK);
	}
}