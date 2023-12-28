using System.Numerics;
using Raylib_cs;

class WallFactory
{
	private static int currentWallPoint = 0;
	private static Vector2 currentWallPointA;
	private static Vector2 currentWallPointB;
	private static float snappingTolerance = 50f;

	public static void Update()
	{
		// TODO: Add ctrl+z undo and redo

		// Check for if the user clicks to add a point
		if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
		{
			// Set the current point to the mouse position
			// divided by zoom to get rid of it
			Vector2 currentPoint = Raylib.GetMousePosition() / WallBuilder.Zoom;

			// Loop over every single point in the walls and find the closest
			// point that is within the snapping distance.
			// TODO: Put computed distances into a cache or something to make it a bit faster. I doubt it will really do anything though
			Dictionary<float, Vector2> pointsWithinDistance = new Dictionary<float, Vector2>();
			foreach (Wall currentWall in WallBuilder.Walls)
			{
				// Get the distance between the two points and check for if its
				// within the snapping distance
				float distance = Distance(currentWall.PointA, currentPoint);
				if (distance <= snappingTolerance && !pointsWithinDistance.ContainsKey(distance))
					pointsWithinDistance.Add(distance, currentWall.PointA);

				// Same thing again but for point B
				// TODO: Put in method or something
				distance = Distance(currentWall.PointB, currentPoint);
				if (distance <= snappingTolerance && !pointsWithinDistance.ContainsKey(distance))
					pointsWithinDistance.Add(distance, currentWall.PointB);
			}

			// Use the new point if it exists
			if (pointsWithinDistance.Count > 1)
			{
				// Get the closest point to the original point
				// by sorting the dictionary, then getting the value of the first item
				Vector2 snappedPoint = pointsWithinDistance.OrderBy(distance => distance.Key).First().Value;
				currentPoint = snappedPoint;
			}


			// Set the point
			// TODO: Do this a different way
			//! very bad rn I think (please rewrite!!)
			currentWallPoint++;
			if (currentWallPoint == 1) currentWallPointA = currentPoint;
			else if (currentWallPoint == 2)
			{
				currentWallPointB = currentPoint;

				// Finished making a wall. Add it to the list of walls.
				Wall wall = new Wall(currentWallPointA, currentWallPointB);
				WallBuilder.Walls.Add(wall);

				// Reset the wall thingy
				currentWallPoint = 0;
			}
		}
	}

	public static void Render()
	{
		// TODO: Remove this maybe
		if (currentWallPoint == 0) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add first point", Vector2.Zero, 30, (30 / 10), Color.WHITE);
		else if (currentWallPoint == 1) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add second point", Vector2.Zero, 30, (30 / 10), Color.WHITE);


		// Draw the 'path' of the wall
		if (currentWallPoint == 1) Raylib.DrawLineEx(currentWallPointA * WallBuilder.Zoom, Raylib.GetMousePosition(), 1f * WallBuilder.Zoom, Color.BLUE);
	}


	// Get the distance between two vectors
	private static float Distance(Vector2 thing, Vector2 target)
	{
		float distance = MathF.Pow((target.X - thing.X), 2) + MathF.Pow((target.Y - thing.Y), 2);
		return MathF.Sqrt(distance);
	}
}