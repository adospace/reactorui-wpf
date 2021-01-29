using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfReactorUI.Internals
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action to invoke on command.</param>
        public ActionCommand(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Occurs when the <see cref="System.Windows.Input.CommandManager"/> detects conditions that might change the ability of a command to execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        /// <returns>
        ///     Returns true if the command can execute, otherwise returns false.
        /// </returns>
        public bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute()
        {
            Execute(null);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        public void Execute(object? parameter)
        {
            this._action();
        }
    }
}
