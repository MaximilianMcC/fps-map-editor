using System.Numerics;
using System.Text.RegularExpressions;
using Raylib_cs;

class Editor
{
	//! debug
	static Vector2 e;

	public static void Start()
	{
		
	}

	public static void Update()
	{
		Grid.UpdateGridCamera();
		AddTiles();
	}

	public static void Render()
	{
		// Draw the background
		Raylib.ClearBackground(Ui.EditorBackgroundColor);
		Grid.DrawGrid();

		Raylib.DrawRectangle((int)e.X, (int)e.Y, 100, 100, Color.BEIGE);
	}




	private static void AddTiles()
	{
		// Check for if the user clicks. If they do, then translate the mouse position
		// into grid coordinates, and add the tile to the grid at that position
		if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
		{
			Vector2 mousePosition = Raylib.GetMousePosition();
			Vector2 gridPosition = Grid.GetGridPosition(mousePosition);

			//!debug
			e = gridPosition;
		}
	}




	private class Grid
	{
		// Camera stuff
		private static float zoom = 1;
		private static float gridSpacing = 100f;
		private static Vector2 cameraPosition = Vector2.Zero;
		private const float cameraSpeed = 150f;
		private const float zoomMultiplier = 0.1f;


		// Turn screen coordinates to grid coordinates
		public static Vector2 GetGridPosition(Vector2 screenPosition)
		{
				
		}


		// Update the grid camera stuff
		public static void UpdateGridCamera()
		{
			// Check for if they want to move around
			// TODO: Also add mouse support
			// TODO: Maybe copy photoshop controls with the ctrl+alt+mouse thingy			
			// TODO: Add diagonal movement and normalize it
			float movement = cameraSpeed * Raylib.GetFrameTime();
			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) cameraPosition.X -= movement;
			else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) cameraPosition.X += movement;
			else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) cameraPosition.Y -= movement;
			else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) cameraPosition.Y += movement;

			// Check for if they want to zoom in
			//! zooming out too far can crash program
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_EQUAL) || Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ADD) || Raylib.GetMouseWheelMove() == 1) zoom += zoomMultiplier;
			else if (Raylib.IsKeyPressed(KeyboardKey.KEY_MINUS) || Raylib.IsKeyPressed(KeyboardKey.KEY_KP_SUBTRACT) || Raylib.GetMouseWheelMove() == -1) zoom -= zoomMultiplier;
		}


		// Draw a grid
		// TODO: Don't make multiple requests to get the width and height
		public static void DrawGrid()
		{
			// Change size according to zoom
			float size = gridSpacing;
			if (zoom != 0) size = size * zoom;

			// Change the offset according to camera position
			Vector2 offset = new Vector2(cameraPosition.X % size, cameraPosition.Y % size);

			// Get how many rows and columns
			//! Rows and Columns might be reversed (idk)
			//? 5 is added to make sure everything is always a square
			int rows = (int)(Raylib.GetScreenHeight() / size) + 5;
			int columns = (int)(Raylib.GetScreenWidth() / size) + 5;

			// Horizontal
			// TODO: Try do in a single for loop
			for (int i = 0; i < columns; i++)
			{
				// Get the start and end positions
				Vector2 start = new Vector2((i * size) - offset.X + Toolbar.Width, 0);
				Vector2 end = new Vector2((i * size) - offset.X + Toolbar.Width, Raylib.GetScreenHeight());

				// Draw the line
				// TODO: Don't hardcode thickness
				Raylib.DrawLineEx(start, end, 2f, Ui.EditorGridColor);
			}

			// Vertical
			// TODO: Try do in a single for loop
			for (int i = 0; i < rows; i++)
			{
				// Get the start and end positions
				Vector2 start = new Vector2(0, (i * size) - offset.Y);
				Vector2 end = new Vector2(Raylib.GetScreenWidth(), (i * size) - offset.Y);

				// Draw the line
				// TODO: Don't hardcode thickness
				Raylib.DrawLineEx(start, end, 2f, Ui.EditorGridColor);
			}
		}
	}
}