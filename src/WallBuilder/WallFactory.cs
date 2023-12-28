using System.Numerics;
using Raylib_cs;

class WallFactory
{
	private static int currentWallPoint = 0;
	private static Vector2 currentWallPointA;
	private static Vector2 currentWallPointB;
	private static float snappingTolerance = 50f;

	// Undo stuff
	// TODO: Have multiple undo steps
	private static Wall previousWall;

	public static void Update()
	{
		// TODO: Add ctrl+z undo and redo

		// Check for if the user clicks to add a point
		if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
		{
			// Set the current point to the mouse position
			// divided by zoom to get rid of it
			Vector2 currentPoint = Raylib.GetMousePosition() / WallBuilder.Zoom;
			currentPoint = SnapPoint(currentPoint);

			// Set the point
			// TODO: Do this a different way
			//! very bad rn I think (please rewrite!!)
			currentWallPoint++;
			if (currentWallPoint == 1) currentWallPointA = currentPoint;
			else if (currentWallPoint == 2)
			{
				currentWallPointB = currentPoint;

				// Finished making a wall.
				// Add it to the list of walls, and the undo menu
				Wall wall = new Wall(currentWallPointA, currentWallPointB);
				WallBuilder.Walls.Add(wall);
				previousWall = wall;

				// Reset the wall thingy
				currentWallPoint = 0;
			}
		}

		// Check for if the user wants to cancel making a wall (esc)
		if (currentWallPoint == 1 && Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
		{
			currentWallPoint = 0;
		}

		// Check for if the user wants to undo (ctrl+z)
		// TODO: Make a list of actions to be undone so you can undo multiple at a time
		if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL) && Raylib.IsKeyDown(KeyboardKey.KEY_Z))
		{
			WallBuilder.Walls.Remove(previousWall);
		}
	}

	public static void Render()
	{
		// TODO: Remove this maybe
		if (currentWallPoint == 0) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add first point", Vector2.Zero, 30, (30 / 10), Color.WHITE);
		else if (currentWallPoint == 1) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add second point", Vector2.Zero, 30, (30 / 10), Color.WHITE);

		// Draw snapping circles around every point
		//! debug
		// TODO: Remove or make look different
		foreach (Wall wall in WallBuilder.Walls)
		{
			Raylib.DrawCircle((int)(wall.PointA.X * WallBuilder.Zoom), (int)(wall.PointA.Y * WallBuilder.Zoom), snappingTolerance / 2, new Color(0, 255, 0, 128));
			Raylib.DrawCircle((int)(wall.PointB.X * WallBuilder.Zoom), (int)(wall.PointB.Y * WallBuilder.Zoom), snappingTolerance / 2, new Color(255, 0, 0, 128));
		}

		// Draw the 'path' of the wall if we are currently 'dragging'
		if (currentWallPoint == 1) Raylib.DrawLineEx(currentWallPointA * WallBuilder.Zoom, Raylib.GetMousePosition(), 1f * WallBuilder.Zoom, Color.BLUE);
	}

	// Snap a point to other points
	//! only works sometimes, and it feels like it only works when more points are added
	//! Everything might be reversed or something idk
	private static Vector2 SnapPoint(Vector2 originalPoint)
	{
		// Loop over every single point in the walls and find the closest
		// point that is within the snapping distance.
		// TODO: Put computed distances into a cache or something to make it a bit faster. I doubt it will really do anything though
		List<Vector2> pointsWithinDistance = new List<Vector2>();
		foreach (Wall wall in WallBuilder.Walls)
		{
			// Get the distance between the two points and check for if its
			// within the snapping distance
			float distanceA = Distance(originalPoint, wall.PointA);
			float distanceB = Distance(originalPoint, wall.PointB);

			// Check for if the points are within the distance threshold
			if (distanceA <= snappingTolerance) pointsWithinDistance.Add(wall.PointA);
			if (distanceB <= snappingTolerance) pointsWithinDistance.Add(wall.PointB);
		}

		// Use the new point if it exists
		if (pointsWithinDistance.Count > 1)
		{
			// Get the closest point to the original point
			// by sorting the dictionary, then getting the value of the first item
			Vector2 snappedPoint = pointsWithinDistance.OrderBy(point => Distance(originalPoint, point)).First();
			return snappedPoint;
		}

		return originalPoint;
	}

	// Get the distance between two vectors
	private static float Distance(Vector2 thing, Vector2 target)
	{
		float distance = MathF.Pow((target.X - thing.X), 2) + MathF.Pow((target.Y - thing.Y), 2);
		return MathF.Sqrt(distance);
	}
}