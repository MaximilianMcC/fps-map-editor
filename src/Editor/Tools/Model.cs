// TODO: Rename
struct ModelInfo
{
	public string Name { get; set; }
	public string FilePath { get; set; }

	public ModelInfo(string filePath)
	{
		// Make the name
		// TODO: Do this better more safer/faster way (this kinda crook rn!!)
		Name = char.ToUpper(Path.GetFileName(filePath).Replace(".obj", "")[0]) + Path.GetFileName(filePath).Replace(".obj", "").Substring(1);
		FilePath = filePath;
	}
}