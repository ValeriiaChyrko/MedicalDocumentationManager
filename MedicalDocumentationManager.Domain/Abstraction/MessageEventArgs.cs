namespace MedicalDocumentationManager.Domain.Abstraction;

public class MessageEventArgs : EventArgs
{
    public string Message { get; }

    public MessageEventArgs(string message)
    {
        Message = message;
    }
}