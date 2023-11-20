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
		// Update camera
		Raylib.UpdateCamera(ref Camera, CameraMode.CAMERA_FIRST_PERSON);

		// Reload the map
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5)) Map.Reload();
	}

	public static void Render3D()
	{
		// Loop through each thing in the map
		foreach (Location thing in Map.Things)
		{
			//! These are done up here so that the reference can be gotten
			Model model = thing.Model;
			Texture2D texture = thing.Texture;

			// Add the texture
			Raylib.SetMaterialTexture(ref model, 0, MaterialMapIndex.MATERIAL_MAP_ALBEDO, ref texture);

			// Render it
			Raylib.DrawModelEx(model, thing.Position, thing.Rotation, 0, Vector3.One, Color.WHITE);
		}
	}

	public static void Render2D()
	{
		Raylib.DrawText($"{Raylib.GetFPS()} fps", 10, 10, 30, Color.BLACK);
		Raylib.DrawText($"editijng \"{Map.Name}\" rn", 10, 50, 30, Color.BLACK);
		Raylib.DrawText($"{Camera.position}", 10, 100, 30, Color.BLACK);
	}
}