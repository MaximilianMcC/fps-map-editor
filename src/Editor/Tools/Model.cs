// TODO: Rename
struct ModelInfo
{
	public string Name { get; set; }
	public string FilePath { get; set; }

	public ModelInfo(string filePath)
	{
		// Make the name
		// TODO: Do this better more safe way
		Name = filePath.Split("/")[filePath.LastIndexOf("/")].Replace(".obj", "").Trim();
		FilePath = filePath;
	}
}