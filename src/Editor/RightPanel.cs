using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

class RightPanel
{
	public const float WIDTH = 350;
	public const float PADDING = 10;
	public const float PADDING2 = PADDING * 2;
	private static float elementY = PADDING;
	
	private static Axis currentAxis = Axis.X;
	
	public static void Start()
	{
		
	}

	public static void Update()
	{
		// Check for if the selected thing has transform controls
		// if (Editor.SelectedThing != null)
		if (true)
		{
			// TODO: Add ui for this and stuff
			// Change the axis
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_X)) currentAxis = Axis.X;
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_Y)) currentAxis = Axis.Y;
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_Z)) currentAxis = Axis.Z;

			// Increase the current axis by 1
			else if (Raylib.IsKeyDown(KeyboardKey.KEY_KP_ADD) || Raylib.IsKeyDown(KeyboardKey.KEY_EQUAL))
			{
				if (currentAxis == Axis.X) Editor.SelectedThing.Position += Vector3.UnitX;
				if (currentAxis == Axis.Y) Editor.SelectedThing.Position += Vector3.UnitY;
				if (currentAxis == Axis.Z) Editor.SelectedThing.Position += Vector3.UnitZ;
			}

			// Decrease the current axis by 1
			else if (Raylib.IsKeyDown(KeyboardKey.KEY_KP_SUBTRACT) || Raylib.IsKeyDown(KeyboardKey.KEY_MINUS))
			{
				if (currentAxis == Axis.X) Editor.SelectedThing.Position -= Vector3.UnitX;
				if (currentAxis == Axis.Y) Editor.SelectedThing.Position -= Vector3.UnitY;
				if (currentAxis == Axis.Z) Editor.SelectedThing.Position -= Vector3.UnitZ;
			}
		}
	}

	public static void Draw()
	{
		// Draw the main panel background
		float anchorX = Raylib.GetScreenWidth() - WIDTH;
		Rectangle panel = new Rectangle(anchorX, 0, WIDTH, Raylib.GetScreenHeight());
		Raylib.DrawRectangleRec(panel, Ui.Colors.Background);

		// Check for if the selected thing has transform controls
		// if (Editor.SelectedThing is Placeable)
		if (true)
		{
			// Draw a title
			Raylib.DrawTextEx(Ui.Fonts.Main, "Transform Controls", new Vector2(anchorX + PADDING, elementY), 20f, (20f / 10f), Ui.Colors.Text);

			// Draw a background to contain everything
			Rectangle background = new Rectangle(anchorX + PADDING, elementY, WIDTH - PADDING2, 100);
			Raylib.DrawRectangleRec(background, Ui.Colors.BackgroundSecondary);

			// Draw the x, y, and z number things for the position
			// TODO: Put in method

			// Draw the left subtraction button

			// Draw the number

			// Draw the right addition button

			// Draw the currently selected axis
			Color color;
			color = (currentAxis == Axis.X) ? Color.RED : Color.GRAY;
			Raylib.DrawTextPro(Ui.Fonts.Main, "x", new Vector2(anchorX + PADDING, PADDING), Vector2.Zero, 0f, 30f, (30f / 10f), color);

			color = (currentAxis == Axis.Y) ? new Color(139, 220, 0, 255) : Color.GRAY;
			Raylib.DrawTextPro(Ui.Fonts.Main, "y", new Vector2(anchorX + PADDING + 30, PADDING), Vector2.Zero, 0f, 30f, (30f / 10f), color);

			color = (currentAxis == Axis.Z) ? new Color(40, 144, 255, 255) : Color.GRAY;
			Raylib.DrawTextPro(Ui.Fonts.Main, "z", new Vector2(anchorX + PADDING + 60, PADDING), Vector2.Zero, 0f, 30f, (30f / 10f), color);
		}
	}
}