using System.Numerics;
using Raylib_cs;

class Window
{
	public string Title { get; set; }
	public const int TitleHeight = 45;

	public int X { get; private set; }
	public int Y { get; private set; }
	public int Width { get; private set; }
	public int Height { get; private set; }
	public int BodyY { get; private set; }
	public int BodyHeight { get; private set; }

	private bool canBeMoved = false;
	private bool beingDragged = false;
	private Vector2 dragOffset = Vector2.Zero;

	private const int padding = 20;

	private List<UIElement> elements = new List<UIElement>();

	public Window(string title, int width, int height, bool moveable)
	{
		// Assign values
		Title = title;
		Width = width;
		Height = height;
		canBeMoved = moveable;
	}

	// Update the window functions
	public void Update()
	{
		MoveAroundWindow();

		// Update all of the elements on the window
		for (int i = 0; i < elements.Count; i++)
		{
			elements[i].Update();
		}
	}

	// Render the base window
	public void Render()
	{
		// Draw the background and title
		Raylib.DrawRectangle(X, Y, Width, Height, new Color(13, 25, 38, 255));
		Raylib.DrawRectangle(X, Y, Width, TitleHeight, new Color(54, 54, 54, 255));
		Raylib.DrawText(Title, X + padding, Y + (padding / 2), 35, Color.LIGHTGRAY);

		
		// Draw all of the elements on the window
		for (int i = 0; i < elements.Count; i++)
		{
			elements[i].Render(0, 0);
		}
	}



	private void MoveAroundWindow()
	{
		// Check for if the window is allowed to be dragged
		if (!canBeMoved) return;

		// Check for if they are clicking on the title bar and dragging it
		Rectangle titleRectangle = new Rectangle(X, Y, Width, TitleHeight);
		if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), titleRectangle) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
		{
			// Setup dragging
			if (!beingDragged)
			{
				beingDragged = true;

				// Get the drag offset
				Vector2 mouse = Raylib.GetMousePosition();
				dragOffset = mouse - new Vector2(X, Y);
			}
			
			// Update the X and Y of the window to move it
			X = ((int)Raylib.GetMousePosition().X) - ((int)dragOffset.X);
			Y = ((int)Raylib.GetMousePosition().Y) - ((int)dragOffset.Y);
			BodyY = Y + TitleHeight;

		}
		else beingDragged = false;
	}




	public void AddElement(UIElement element)
	{
		elements.Add(element);
	}
}