namespace Rover.Logic
{
    public class CommandResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public CommandResult()
        {
            Message = string.Empty;
            Success = false;
        }

        public static implicit operator CommandResult(bool b)
        {
            return new CommandResult() { Success = b };
        }

        public static implicit operator bool(CommandResult commandResult)
        {
            if (commandResult!=null)
                return commandResult.Success;
            return false;
        }

        public static implicit operator CommandResult(string msg)
        {
            return new CommandResult() { Message = msg, Success = false };
        }
    }
}
