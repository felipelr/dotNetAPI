using Strab.Domain.Commands.Interfaces;

namespace Strab.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}