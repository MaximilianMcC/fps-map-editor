using System.Numerics;
using Raylib_cs;

class WallBuilder
{

	private static List<Wall> walls;
	private static float zoom = 1f;

	public static void Start()
	{
		// Make a new list to hold all of the walls
		walls = new List<Wall>();

		// Add walls
		// TODO: Remove and do from UI (map editor)
		walls.Add(new Wall(new Vector2(10, 10), new Vector2(40, 50)));
		walls.Add(new Wall(new Vector2(40, 50), new Vector2(100, 50)));
		walls.Add(new Wall(new Vector2(10, 10), new Vector2(10, 100)));
		walls.Add(new Wall(new Vector2(10, 100), new Vector2(65, 120)));
		walls.Add(new Wall(new Vector2(65, 120), new Vector2(100, 50)));
	}

	public static void Update()
	{
		// Check for if we want to increase, or decrease the zoom
		// TODO: Do somewhere else in a Camera class or something
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ADD) || Raylib.IsKeyPressed(KeyboardKey.KEY_EQUAL)) zoom += 0.5f;
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_KP_SUBTRACT) || Raylib.IsKeyPressed(KeyboardKey.KEY_MINUS)) zoom -= 0.5f;
	}

	public static void Render()
	{
		// Draw lines between the two points of the walls to show an outline thing
		foreach (Wall wall in walls)
		{
			Raylib.DrawLineEx(wall.PointA * zoom, wall.PointB * zoom, 2f * zoom, Color.WHITE);
		}
	}
}