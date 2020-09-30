namespace SupportChat.Popup
{
	public interface IBrowser
	{
		string Name { get; }
		void Run(string url);
		void SetPath(string path);
	}
}
