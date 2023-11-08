class UIElement
{
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }

	public virtual void Update() { return; }
	public virtual void Render() { return; }
}