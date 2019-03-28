using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NorthView.Helpers
{
    public class RelayCommand : ICommand
    {
        #region Fields
        readonly Action<object> _exec;
        readonly Action exec;
        readonly Predicate<object> _canExec;

        #endregion

        #region Ctors
        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            :this(execute,null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _exec = execute ?? throw new ArgumentNullException("execute");
            _canExec = canExecute;
        }

       
        #endregion

        #region Command Members
        public bool CanExecute(object parameter) => _canExec == null ? true : _canExec(parameter); 
        public event EventHandler CanExecuteChanged;

        public void Execute(object param)
        {
            _exec(param);
        }

        public void RemoveAllEvents()
        {
            CanExecuteChanged = null;
        }
        #endregion
    }
}
