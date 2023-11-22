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
		// Reload the map if press F5
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5)) Map.Reload();
	}


	public static void Render()
	{
		Raylib.DrawText($"{Raylib.GetFPS()} fps", 10, 10, 30, Color.BLACK);
		Raylib.DrawText($"editijng \"{Map.Name}\" rn", 10, 50, 30, Color.BLACK);
	}
}