using Raylib_cs;

class RightPanel
{
	public const float WIDTH = 350;
	
	public static void Start()
	{
		
	}

	public static void Update()
	{

	}

	public static void Draw()
	{
		// Draw the main panel background
		float anchorX = Raylib.GetScreenWidth() - WIDTH;
		Rectangle panel = new Rectangle(anchorX, 0, WIDTH, Raylib.GetScreenHeight());
		Raylib.DrawRectangleRec(panel, Ui.Colors.Background);
	}
}