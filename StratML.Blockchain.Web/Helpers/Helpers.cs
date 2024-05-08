using Microsoft.AspNetCore.Components;
using System.Windows.Input;

namespace StratML.Blockchain.Web.Helpers
{
    public static class Helpers
    {
        public static EventCallback<T> BindCommand<T>(this ICommand command, object? parameter = null)
        {
            MulticastDelegate m1 = () => command.Execute(parameter);
            return new EventCallback<T>(null, m1);
        }
    }
}
