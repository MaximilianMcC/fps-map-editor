using Raylib_cs;

class Ui
{
	// Font stuff
	// TODO: Maybe change font
	public const float FontSize = 30f;
	public const float FontSpacing = (FontSize / 10);
	
	// Padding stuff
	public const float Padding = 10f;
	public const float Padding2 = Padding * 2;
	public const float PaddingHalf = Padding / 2;

	// Colors
	public static readonly Color WindowBackgroundColor = new Color(32, 32, 32, 255);
	public static readonly Color WindowOutlineColor = new Color(64, 64, 64, 255);
	public static readonly Color EditorBackgroundColor = new Color(32, 24, 32, 255);
	public static readonly Color EditorGridColor = new Color(128, 128, 128, 255);


	public static void Start()
	{
		Toolbar.Start();
	}

	public static void Update()
	{
		Toolbar.Update();
	}

	public static void Render()
	{
		Toolbar.Render();
	}
}