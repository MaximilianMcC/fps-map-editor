using System.Numerics;
using Raylib_cs;

class WallBuilder
{
	public static List<Wall> Walls;
	public static float Zoom = 5f;

	public static void Start()
	{
		// Make a new list to hold all of the walls
		Walls = new List<Wall>();
	}

	public static void Update()
	{
		// Check for if we want to increase, or decrease the zoom
		// TODO: Do somewhere else in a Camera class or something
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ADD) || Raylib.IsKeyPressed(KeyboardKey.KEY_EQUAL)) Zoom += 0.5f;
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_SUBTRACT) || Raylib.IsKeyPressed(KeyboardKey.KEY_MINUS)) Zoom -= 0.5f;

		WallFactory.Update();
	}

	public static void Render()
	{
		// Draw lines between the two points of the walls to show an outline thing
		foreach (Wall wall in Walls)
		{
			// Times everything by zoom to zoom in/out because 1m is 1px in 2D
			Raylib.DrawLineEx(wall.PointA * Zoom, wall.PointB * Zoom, 1f * Zoom, Color.WHITE);
		}

		WallFactory.Render();
	}
}