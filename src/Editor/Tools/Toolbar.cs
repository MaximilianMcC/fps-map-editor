using System.Numerics;
using Raylib_cs;

struct Toolbar
{
	public const int Width = 50;
	private const int Padding = 10;
	private const int Padding2 = Padding * 2;
	private const int IconSize = Width - Padding2;

	public Tool[] Tools { get; set; }
	public int SelectedToolIndex { get; set; } = 0;
	public Tool SelectedTool
	{
		get { return Tools[SelectedToolIndex]; }
		set { Tools[SelectedToolIndex] = value; }
	}

	public Toolbar(Tool[] tools)
	{
		Tools = tools;
	}

	// Update the toolbar
	public void Update()
	{
		// Check for shortcuts
		for (int i = 0; i < Tools.Length; i++)
		{
			if (Raylib.IsKeyPressed(Tools[i].ShortcutKey))
			{
				SelectedToolIndex = i;
				Console.WriteLine("Selected " + Tools[i].Name);
			}
		}
	}

	// Draw the toolbar
	public void Draw()
	{
		// Draw the background and a border
		Raylib.DrawRectangle(0, 0, Width, Raylib.GetScreenHeight(), Colors.Background);
		Raylib.DrawRectangle(Width, 0, 5, Raylib.GetScreenHeight(), Colors.BackgroundTertiary);

		// Draw all the icons
		Vector2 position = new Vector2(Padding);
		for (int i = 0; i < Tools.Length; i++)
		{
			// If the current icon is selected then draw a box under it
			if (i == SelectedToolIndex)
			{
				Raylib.DrawRectangleRoundedLines(new Rectangle(position.X - 5, position.Y - 5, IconSize + 10, IconSize + 10), 0.5f, 5, 2f, Colors.Fancy);
			}

			// Draw the icon
			float scale = IconSize / (float)Tools[i].Icon.width;
			Raylib.DrawTextureEx(Tools[i].Icon, position, 0, scale, Color.WHITE);

			// Draw a line to separate the different items
			position.Y += Padding + IconSize;
			Raylib.DrawLineEx(new Vector2(0f, position.Y), new Vector2(Width, position.Y), 2f, Colors.BackgroundTertiary);
			position.Y += Padding;
		}
	}
}


// TODO: Get a way to unload the texture from here. Use a resource manager or something
struct Tool
{
	public string Name { get; set; }
	public string Description { get; set; }
	public KeyboardKey ShortcutKey { get; set; }
	public Texture2D Icon { get; set; }

	public Tool(string name, string description, string iconTexturePath, KeyboardKey shortcutKey)
	{
		Name = name;
		Description = description;
		ShortcutKey = shortcutKey;

		Icon = Raylib.LoadTexture(iconTexturePath);
	}
}