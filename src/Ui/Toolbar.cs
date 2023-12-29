using System.Numerics;
using Raylib_cs;

class Toolbar
{
	// TODO: Make customizable by dragging out or something
	public static List<Tile> Tiles;
	public static Tile SelectedTile { get; set; }

	public const float Width = 75f;
	private static float Height = Raylib.GetScreenHeight();


	public static void Start()
	{
		// Make a list to get all of the tiles in the toolbar
		// and all of the tiles
		Tiles = new List<Tile>();
		new Tile("Straight Wall", "A straight wall", "./assets/tiles/straight.png", KeyboardKey.KEY_S);
	}

	public static void Update()
	{
		// Update the height
		Height = Raylib.GetScreenHeight();

		// Update all of the tiles
		foreach (Tile tile in Tiles) tile.Update();
	}

	public static void Render()
	{
		// Draw the background and a border on the right of it
		Raylib.DrawRectangleRec(new Rectangle(0, 0, Width, Height), Ui.WindowBackgroundColor);
		Raylib.DrawLineEx(new Vector2(Width, 0), new Vector2(Width, Height), 5f, Ui.WindowOutlineColor);

		// Draw all of the tiles on the toolbar
		float y = Ui.Padding;
		foreach (Tile tile in Tiles)
		{
			// Draw the actual tile
			float size = Width - Ui.Padding2;
			float scale  = size / tile.Icon.width;
			Raylib.DrawTextureEx(tile.Icon, new Vector2(Ui.Padding, y), 0f, scale, Color.WHITE); 

			// Draw a small outline around the tile
			// Make it blue if its selected
			Color color = (tile == SelectedTile) ? Color.BLUE : Ui.WindowOutlineColor;
			Raylib.DrawRectangleLinesEx(new Rectangle(Ui.Padding, y, size, size), 2f, color);

			// Increase the Y for drawing the next toolbar item
			y += (Ui.Padding + size);
		}
	}
}