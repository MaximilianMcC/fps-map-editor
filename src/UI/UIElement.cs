class UIElement
{
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }

	public int FontSize = 25;

	public virtual void Update(int anchorX, int anchorY, int parentWidth)
	{
		// Apply the X, Y, and width values
		X = anchorX;
		Y = anchorY;
		Width = parentWidth;
	}


	public virtual void Render() { return; }
}