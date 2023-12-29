using Raylib_cs;

class Tile
{
	public string Name { get; private set; }
	public string Description { get; private set; }
	public Texture2D Icon { get; private set; }
	private KeyboardKey shortcutKey;

	// TODO: Unload image when done
	public Tile(string name, string description, string iconPath, KeyboardKey shortcutKey)
	{
		// Set values
		Name = name;
		Description = description;
		Icon = Raylib.LoadTexture(iconPath);
		this.shortcutKey = shortcutKey;

		// Add the tile to the toolbar
		Toolbar.Tiles.Add(this);
	}

	public void Update()
	{
		// Check for if we are being selected from a shortcut
		if (Raylib.IsKeyPressed(shortcutKey))
		{
			// Toggle the tool 
			if (Toolbar.SelectedTile == this) Toolbar.SelectedTile = null;
			else Toolbar.SelectedTile = this;
		}

		// Check for if we are selected. If we aren't then don't update
		if (Toolbar.SelectedTile != this) return;
	}

	public override string ToString()
	{
		return Name;
	}
}