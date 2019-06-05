using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using OpenE6B.Annotations;
using System.Diagnostics.CodeAnalysis;

namespace OpenE6B.Classes
{
   public interface IAsyncCommand : ICommand
   {
        Task ExecuteAsync(object parameter);
        
    }

    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameter);
        public virtual async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        [ExcludeFromCodeCoverage]
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        [ExcludeFromCodeCoverage]
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    [ExcludeFromCodeCoverage]
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<Task<TResult>> _command;
        private NotifyTaskCompletion<TResult> _execution;

        [ExcludeFromCodeCoverage]
        public AsyncCommand(Func<Task<TResult>> command)
        {
            _command = command;
        }

        [ExcludeFromCodeCoverage]
        public override bool CanExecute(object parameter)
        {

            return Execution == null || Execution.IsCompleted;
        }

        [ExcludeFromCodeCoverage]
        public override async Task ExecuteAsync(object parameter)
        {
            Execution = new NotifyTaskCompletion<TResult>(_command());
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            RaiseCanExecuteChanged();
        }

        [ExcludeFromCodeCoverage]
        public NotifyTaskCompletion<TResult> Execution
        {
            get { return _execution; }
            private set
            {
                _execution = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [ExcludeFromCodeCoverage]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [ExcludeFromCodeCoverage]
    public static class AsyncCommand
    {
        public static AsyncCommand<object> Create(Func<Task> command)
        {
            return new AsyncCommand<object>(async () => { await command(); return null; });
        }

        public static AsyncCommand<TResult> Create<TResult>(Func<Task<TResult>> command)
        {
            return new AsyncCommand<TResult>(command);
        }
    }

}
