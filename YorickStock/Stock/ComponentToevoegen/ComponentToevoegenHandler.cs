namespace SamStock.Stock.ComponentToevoegen
{
    public class ComponentToevoegenHandler : IComponentToevoegenHandler
    {
        private readonly IComponentToevoegenCommandExecutor _componentToevoegenCommandExecutor;

        public ComponentToevoegenHandler(IComponentToevoegenCommandExecutor componentToevoegenCommandExecutor)
        {
            _componentToevoegenCommandExecutor = componentToevoegenCommandExecutor;
        }

        public void Handle(ComponentToevoegenCommand command)
        {
            _componentToevoegenCommandExecutor.Execute(command);
        }
    }
}