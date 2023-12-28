using System.Numerics;
using Raylib_cs;

class WallFactory
{
	private static bool currentlyMakingWall = false;
	private static int currentWallPoint = 0;
	private static Vector2 currentWallPointA;
	private static Vector2 currentWallPointB;

	public static void Update()
	{
		// Check for if the user presses W to start building a wall.
		// When the click, the first point will be added. It will also
		// snap to the nearest wall maybe. Clicking will add the second
		// point. Walls could maybe be selected and moved around or
		// something.

		if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
		{
			// If we are in the middle of making a wall, cancel it
			currentlyMakingWall = !currentlyMakingWall;
			if (currentlyMakingWall) currentWallPoint = 0;
		}

		// Check for if the user clicks to add a point
		if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
		{
			// Set the current point to the mouse position
			// divided by zoom to get rid of it
			// TODO: Add snapping so the walls don't have any gaps
			Vector2 currentPoint = Raylib.GetMousePosition() / WallBuilder.Zoom;

			// Set the point
			// TODO: Do this a different way
			//! very bad rn I think (please rewrite!!)
			currentWallPoint++;
			if (currentWallPoint == 1) currentWallPointA = currentPoint;
			else if (currentWallPoint == 2) currentWallPointB = currentPoint;
			else
			{
				// Finished making a wall. Add it to the list of walls.
				Wall wall = new Wall(currentWallPointA, currentWallPointB);
				WallBuilder.Walls.Add(wall);

				// Reset the wall thingy
				currentlyMakingWall = false;
				currentWallPoint = 0;
			}
		}
	}

	public static void Render()
	{
		// TODO: Remove this maybe
		if (currentWallPoint == 0) Raylib.DrawTextEx(Ui.Fonts.Main, "Please press 'w' to make a new wall", Vector2.Zero, 30, (30 / 10), Color.WHITE);
		else if (currentWallPoint == 1) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add first point", Vector2.Zero, 30, (30 / 10), Color.WHITE);
		else if (currentWallPoint == 2) Raylib.DrawTextEx(Ui.Fonts.Main, "Please add second point", Vector2.Zero, 30, (30 / 10), Color.WHITE);


		// Draw the 'path' of the wall
		if (currentWallPoint == 1) Raylib.DrawLineEx(currentWallPointA * WallBuilder.Zoom, Raylib.GetMousePosition(), 1f * WallBuilder.Zoom, Color.BLUE);
	}
}