using System.Numerics;
using Raylib_cs;

class RightPanel
{
	public const float WIDTH = 350;
	public const float PADDING = 10;
	public const float PADDING2 = PADDING * 2;
	private static float elementY = PADDING;
	
	public static void Start()
	{
		
	}

	public static void Update()
	{
		// Check for if the selected thing has transform controls
		if (Editor.SelectedThing is Placeable)
		{
			// Show transform controls
			// (x, y, z, rotation, scale)

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
		}
	}
}