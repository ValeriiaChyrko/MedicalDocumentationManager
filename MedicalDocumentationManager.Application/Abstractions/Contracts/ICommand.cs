namespace MedicalDocumentationManager.Application.Abstractions.Contracts;

public interface ICommand : IBaseCommand
{
}

public interface ICommand<TResponse> : IBaseCommand
{
}